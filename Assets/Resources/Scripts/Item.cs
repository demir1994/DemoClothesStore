using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string ItemName = "";
    public int sellingPrice;
    public SpriteRenderer cosmeticID;
    public float armorValue;
    public bool isOwned;

    public Image cosmeticImg;
    public Text itemNameTxt;
    public Text priceTxt;

    public Item thisItem;

    public string itemType;

    public ItemType type;
    public enum ItemType
    {
        Hood,
        Torso,
        Waistband,
        Boots,
        Leggings
    }

    private void Awake()
    {
        cosmeticImg.sprite = cosmeticID.sprite;
        priceTxt.text = sellingPrice.ToString();
        itemNameTxt.text = ItemName;

    }

    public void EquipItem()
    {
        if (itemType == ItemType.Hood.ToString())
        {
            Player.player.Clothes_UpdateHood(cosmeticID.sprite);
            print("Hood equiped");
        }

        if (itemType == ItemType.Torso.ToString())
        {
            Player.player.Clothes_UpdateTorso(cosmeticID.sprite);
            print("Torso equiped");
        }

        if (itemType == ItemType.Waistband.ToString())
        {
            Player.player.Clothes_UpdateWaistband(cosmeticID.sprite);
            print("Waistband equiped");
        }

        //switch (type)
        //{
        //    case ItemType.Hood:
        //        Player.player.Clothes_UpdateHood(cosmeticID.sprite);
        //        print("Hood equiped");
        //        break;
        //    case ItemType.Torso:
        //        Player.player.Clothes_UpdateTorso(cosmeticID.sprite);
        //        print("Torso equiped");
        //        break;
        //    case ItemType.Waistband:
        //        Player.player.Clothes_UpdateWaistband(cosmeticID.sprite);
        //        print("Waistband equiped");
        //        break;
        //    default:
        //        Debug.LogError("Unrecognized Option");
        //        break;
        //}

    }

    /// <summary>
    /// Selling items
    /// </summary>
    public void SellItem()
    {
        // currency = sellingPrice % 5 or similar formula?
        // unequip this from character

        GameManager.instance.TradingManager(sellingPrice, false, true);

        print("Selling item..." + '%' + thisItem.name);
        Destroy(thisItem.gameObject);
    }

}
