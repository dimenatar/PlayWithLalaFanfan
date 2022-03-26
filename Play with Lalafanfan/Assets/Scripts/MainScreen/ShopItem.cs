using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class ShopItem : MonoBehaviour
{
    private UserMoney _money;
    private IResource _recurce;

    public void Initialise(UserMoney money, IResource resource)
    {
        _money = money;
        _recurce = resource;
        GetComponent<Button>().onClick.AddListener(PurchaseEvent);
    }

    private void PurchaseEvent()
    {
        _recurce.PurchaseItem(_money);
    }
}
