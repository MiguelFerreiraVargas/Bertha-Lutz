using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Animação : MonoBehaviour
{
    public float fps = 10f;
    public float moveThreshold = 0.01f;

    [Header("Sprites por direção (0=E, 1=NE, 2=N, 3=NW, 4=W, 5=SW, 6=S, 7=SE)")]
    public List<Sprite> dir0_E, dir1_NE, dir2_N, dir3_NW, dir4_W, dir5_SW, dir6_S, dir7_SE;

    private List<List<Sprite>> dirs;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private int currentDir = 0;
    private int frame = 0;
    private float timer = 0;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        dirs = new List<List<Sprite>>() { dir0_E, dir1_NE, dir2_N, dir3_NW, dir4_W, dir5_SW, dir6_S, dir7_SE };
    }

    void Update()
    {
        Vector2 vel = rb.linearVelocity;
        bool moving = vel.sqrMagnitude > moveThreshold * moveThreshold;

        if (moving)
        {
            int dir = GetDirectionIndex(vel);
            if (dir >= 0) currentDir = dir;
            AnimateMove(currentDir);
        }
        else
        {
            var list = dirs[currentDir];
            if (list != null && list.Count > 0)
                sr.sprite = list[0];
        }
    }

    void AnimateMove(int dir)
    {
        var list = dirs[dir];
        if (list == null || list.Count == 0) return;

        timer += Time.deltaTime;
        if (timer >= 1f / fps)
        {
            timer -= 1f / fps;
            frame = (frame + 1) % list.Count;
            sr.sprite = list[frame];
        }
    }

    int GetDirectionIndex(Vector2 v)
    {
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360f;
        int idx = Mathf.FloorToInt((angle + 22.5f) / 45f) % 8;
        return idx;
    }
}
