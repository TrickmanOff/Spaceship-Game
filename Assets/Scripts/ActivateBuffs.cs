using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBuffs : MonoBehaviour, IShopCustomer
{
    public GameObject player;

    void activateShield()
    {
        Debug.Log("Shield On clicked");
        Instantiate(GameAssets.instance.shield, new Vector2(-100, -100), Quaternion.identity);
    }

    public void BoughtItem(Item.ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case Item.ItemType.Shield: activateShield(); break;
        }
    }

    public bool TrySpendGoldAmount(int goldAmount)
    {
        if (DataManager.instance.gold >= goldAmount)
        {
            DataManager.instance.gold -= goldAmount;
            return true;
        }
        else
            return false;
    }

    public bool ShieldOn()
    {
        return player.GetComponent<PlayersGunManager>().shieldOn;
    }
}
