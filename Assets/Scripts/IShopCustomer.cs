using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopCustomer
{
    bool ShieldOn();
    void BoughtItem(Item.ItemType itemType);
    bool TrySpendGoldAmount(int goldAmount);
}
