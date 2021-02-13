using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeStation : MonoBehaviour
{
    public UI_Shop uiShop;
    public float speed;
    public bool move = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        IShopCustomer shopCustomer = col.GetComponent<IShopCustomer>();
        if (shopCustomer != null)
        {
            uiShop.Show(shopCustomer);
            move = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        IShopCustomer shopCustomer = col.GetComponent<IShopCustomer>();
        if(shopCustomer != null)
        {
            uiShop.Hide();
            move = true;
        }
    }

    void Update()
    {
        if(move) 
            transform.Translate(new Vector2(0, speed * Time.deltaTime));
    }
}
