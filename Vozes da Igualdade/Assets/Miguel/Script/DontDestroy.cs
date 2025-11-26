using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPersist : MonoBehaviour
{
    public static PlayerPersist Instance;
    [Tooltip("Nome do GameObject que será o spawn na cena (ex: PlayerSpawn)")]
    public string spawnNameInScene = "PlayerSpawn";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            // já existe outro player persistente -> destroi este clone
            if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }
    }

    private void OnDestroy()
    {
        // limpa o handler se este for o Instance
        if (Instance == this) SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        // garante tag correta
        gameObject.tag = "Player";
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // tenta posicionar o Player no spawn da cena (se existir)
        GameObject spawn = GameObject.Find(spawnNameInScene);
        if (spawn != null)
        {
            transform.position = spawn.transform.position;
        }
        else
        {
            // alternativa: procurar por tag "PlayerSpawn"
            GameObject spawnTag = GameObject.FindWithTag("PlayerSpawn");
            if (spawnTag != null)
                transform.position = spawnTag.transform.position;
        }
    }
}
