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

    private Vector3 _startScale;
    private Vector3 _animatedScale;

    private void Awake()
    {
        _userMoney.OnMoneyAmountChanged += SetMoneyAmountText;
        _startScale = _moneyText.transform.localScale;
        _animatedScale = _startScale * 1.2f;
    }

    private void SetMoneyAmountText(int amount)
    {
        _moneyText.transform.DOScale(_animatedScale, 0.1f).OnComplete(() => _moneyText.transform.DOScale(_startScale, 0.4f));
        _moneyText.text = amount.ToString();
    }
}
