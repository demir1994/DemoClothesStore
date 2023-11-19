using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

# if UNITY_EDITOR
public class Shop_EditorWindow : EditorWindow
{

    public string ItemName = "";
    public int price;

    public enum ItemType
    {
        Hood,
        Torso,
        Waistband,
        Boots,
        Leggings
    }

    public ItemType type;

    void OnGUI()
    {
        GUILayout.Label("Item spawner", EditorStyles.boldLabel);
        type = (ItemType)EditorGUILayout.EnumPopup("Item type:", type);
        ItemName = EditorGUILayout.TextField("Item Name", ItemName);
        price = EditorGUILayout.IntField("Item Price", price);

        if (GUILayout.Button("Create new item"))
            InstantiatePrimitive(type);

        if (GUILayout.Button("Spawn Item"))
        {
            SpawnItem();
        }

        if (GUILayout.Button("Clothes integration utility by Demir Nezirovic"))
        {
            Application.OpenURL("https://dreamingskycom.wordpress.com/demir-portfolio/");
        }
    }

    void InstantiatePrimitive(ItemType op)
    {
        switch (op)
        {
            case ItemType.Hood:
                //Spawn torso item
                break;
            case ItemType.Torso:
                //Spawn torso item
                break;
            case ItemType.Waistband:
                //Spawn waistband item
                break;
            default:
                Debug.LogError("Unrecognized Option");
                break;
        }
    }

    [MenuItem("SHOP/Add buyable item")]
    public static void DisplayWindow()
    {
        GetWindow<Shop_EditorWindow>("Shop_EditorWindow");
    }

    public void SpawnItem()
    {
        // get sprite and add it
        // fit instantiated object
    }
}
#endif