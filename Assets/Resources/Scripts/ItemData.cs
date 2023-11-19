using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public string ItemName = "";
    public int price;
    public SpriteRenderer cosmeticID;
    public float armorValue;

    public ItemType itemType;

    [SerializeField]
    public enum ItemType
    {
        Hood,
        Torso,
        Waistband,
        Boots,
        Leggings
    }

    public bool isOwned;

    public Item item;

    /// <summary>
    /// Buying items
    /// </summary>
    public void Buy()
    {
        //if (Buyable)
        //{

        if (price <= GameManager.instance.availableGold)
        {
            GameManager.instance.TradingManager(price, true, false);
            item.ItemName = ItemName;
            item.sellingPrice = price;
            item.armorValue = armorValue;
            item.cosmeticID = cosmeticID;
            item.isOwned = true;
            item.itemType = itemType.ToString();

            Instantiate(item, GameManager.instance.inventory_ContentRow.transform);

        }
    }

}
