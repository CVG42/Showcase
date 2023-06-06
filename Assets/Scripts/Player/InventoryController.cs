using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryButton;
    //[SerializeField] GameObject toolbarPanel;

    public void OpenInventory()
    {
        inventoryButton.SetActive(false);
        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
        //toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
    }
}
