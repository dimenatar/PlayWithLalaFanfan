using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private UserMoney _userMoney;
    [SerializeField] private TextMeshProUGUI _moneyText;

    private void Awake()
    {
        _userMoney.OnMoneyAmountChanged += SetMoneyAmountText;
    }

    private void SetMoneyAmountText(int amount)
    {
        _moneyText.transform.DOScale(_moneyText.transform.localScale * 1.2f, 0.1f).OnComplete(() => _moneyText.transform.DOScale(_moneyText.transform.localScale / 1.2f, 0.4f));
        _moneyText.text = amount.ToString();
    }
}
