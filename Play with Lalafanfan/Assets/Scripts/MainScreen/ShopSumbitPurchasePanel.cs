using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSumbitPurchasePanel : MonoBehaviour
{
    [SerializeField] private UserMoney _money;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _submitButton;

    private IResource _resource;

    public void ShowPanel(IResource resource)
    {
        _submitButton.onClick.RemoveAllListeners();
        _resource = resource;
        _submitButton.onClick.AddListener(SubscribeSubmitButton);
        _submitButton.onClick.AddListener(ClosePane);
        _panel.SetActive(true);
    }

    private void SubscribeSubmitButton()
    {
        _resource.PurchaseItem(_money);
    }

    public void ClosePane()
    {
        _panel.SetActive(false);
    }
}
