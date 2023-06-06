using UnityEngine;

[System.Serializable]

public class ItemDetails
{
    public ItemType itemType;
    public int itemCode;
    public string itemDescription;
    public short itemUseGridRadius;
    public float itemUseRadius;
    public bool canBePickedUp;
    public bool canBeDropped;
    public bool isStartingItem;
    public bool canBeCarried;
}
