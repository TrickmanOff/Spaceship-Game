using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Shield
    }

    public static int GetCost(ItemType itemType)
    {
        switch(itemType)
        {
            default:
            case ItemType.Shield: return 40;
        }
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch(itemType)
        {
            default:
            case ItemType.Shield: return GameAssets.instance.shield.GetComponent<SpriteRenderer>().sprite;
        }
    }
}
