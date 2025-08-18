using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryController: MonoBehaviour
{
 public Inventoryy inventoryy;  
    public GameObject slotPrefab;   
    public Transform slotsParent;   
    private List<GameObject> slots = new List<GameObject>();
    public GameObject inventoryPanel;

    private bool isOpen = false; // inventário começa fechado

    void Start()
    {
        // Cria os slots no começo
        for (int i = 0; i < inventoryy.maxSlots; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotsParent);
            slots.Add(slot);
        }

        inventoryPanel.SetActive(isOpen); // começa fechado
    }

    void Update()
    {
        // Alterna abrir/fechar com tecla I
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            inventoryPanel.SetActive(isOpen);
                  Debug.Log("Inventário alternado: " + isOpen);
        }

        // Atualiza os ícones dos itens
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
                icon.enabled = false;
            }
        }
    }
}
