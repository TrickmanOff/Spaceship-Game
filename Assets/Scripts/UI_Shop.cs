using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateItemButton(Item.ItemType.Shield, Item.GetSprite(Item.ItemType.Shield), "Shield", Item.GetCost(Item.ItemType.Shield), 0);
        //CreateItemButton(Item.GetSprite(Item.ItemType.Shield), "Shield", Item.GetCost(Item.ItemType.Shield), 1);
        //CreateItemButton(Item.GetSprite(Item.ItemType.Shield), "Shield", Item.GetCost(Item.ItemType.Shield), 2);
        Hide();
    }

    private void CreateItemButton(Item.ItemType itemType, Sprite itemIcon, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 130f;
        float shopItemWidth = 65f;
        shopItemRectTransform.anchoredPosition = new Vector2(((positionIndex % 2) == 0 ? -1 : 1) * shopItemWidth, -shopItemHeight * (positionIndex/2));

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemIcon").GetComponent<Image>().sprite = itemIcon;

        shopItemTransform.gameObject.SetActive(true);

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () =>
        {
            //clicked on shop item
            TryBuyItem(itemType);
        };
    }
    
    private void TryBuyItem(Item.ItemType itemType)
    {
        Debug.Log("Trying to buy " + itemType);
        //condition for shield
        if (itemType == Item.ItemType.Shield && shopCustomer.ShieldOn()) return;

        if (shopCustomer.TrySpendGoldAmount(Item.GetCost(itemType)))
        {
            shopCustomer.BoughtItem(itemType);
        }
    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
