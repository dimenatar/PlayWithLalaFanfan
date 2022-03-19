using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserMoney : MonoBehaviour
{
    public delegate void MoneyAmountChanged(int amount);
    public event MoneyAmountChanged OnMoneyAmountChanged;

    private int _moneyAmount;

    public int MoneyAmount => _moneyAmount;

    private void Start()
    {
        
    }

    public void SetMoneyAmount(int amount)
    {
        _moneyAmount = amount;
        OnMoneyAmountChanged.Invoke(_moneyAmount);
    }

    public void IncrementMoney()
    {
        _moneyAmount++;
        OnMoneyAmountChanged.Invoke(_moneyAmount);
    }

    public bool ReduceMoney(int amount)
    {
        if (_moneyAmount - amount < 0)
        {
            return false;
        }
        else
        {
            _moneyAmount -= amount;
            OnMoneyAmountChanged.Invoke(_moneyAmount);
            return true;
        }
    }

    public void AddMoney(int amount)
    {
        _moneyAmount += amount;
        OnMoneyAmountChanged.Invoke(_moneyAmount);
    }
}
