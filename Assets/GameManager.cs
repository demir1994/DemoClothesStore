using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject clothes_shop;
    public GameObject inventory;
    public GameObject inventory_ContentRow;
    public Text goldTxt;

    public int availableGold;

    /// <summary>
    /// Sale buy/sell and conditions manager
    /// </summary>
    /// <param name="value"></param>
    /// <param name="buy"></param>
    /// <param name="sale"></param>
    public void TradingManager(int value, bool buy, bool sale)
    {
        if (sale)
        {
            availableGold += value;
            goldTxt.text = availableGold.ToString();
        }
        if (buy)
        {
            availableGold -= value;
            goldTxt.text = availableGold.ToString();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// Shop trigger enter/open
    /// </summary>
    /// <param name="isShop"></param>
    public void ShopEnter(bool isShop)
    {
        if (isShop)
        {
            clothes_shop.SetActive(true);
            inventory.SetActive(true);
        }
        else
        {
            clothes_shop.SetActive(false);
            inventory.SetActive(false);
        }
    }
}
