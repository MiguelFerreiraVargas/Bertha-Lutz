using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Inventoryy inventoryy;
    public GameObject slotPrefab;
    public Transform slotsParent;
    private List<GameObject> slots = new List<GameObject>();
    public GameObject inventoryPanel;
    private bool slotsCreated = false;


    private bool isOpen = false;

    void Start()
    {
        if (!slotsCreated)
        {
            for (int i = 0; i < 4 ; i++)
            {
                GameObject slot = Instantiate(slotPrefab, slotsParent);
                slots.Add(slot);
            }
            slotsCreated = true;
        }

        inventoryPanel.SetActive(isOpen);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            inventoryPanel.SetActive(isOpen);
            Debug.Log("Inventário alternado: " + isOpen);
        }
        for (int i = 0; i < slots.Count; i++)
        {
            Image icon = slots[i].transform.GetChild(0).GetComponent<Image>();

            if (i < inventoryy.items.Count)
            {
                icon.sprite = inventoryy.items[i].icon;
                icon.enabled = true;
            }
            else
            {
                icon.sprite = null;
                icon.enabled = false;
            }
        }
    }
}