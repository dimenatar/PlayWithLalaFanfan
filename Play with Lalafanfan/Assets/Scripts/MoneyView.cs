using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private UserMoney _userMoney;
    [SerializeField] private Text _moneyText;

    private void Awake()
    {
        Debug.Log("awake");
        _userMoney.OnMoneyAmountChanged += SetMoneyAmountText;
    }

    private void SetMoneyAmountText(int amount)
    {
        _moneyText.text = amount.ToString();
    }
}
