using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResource 
{
    public string IconResourceName { get; }
    public void PurchaseItem(UserMoney userMoney);
    public void AddToBackpack(Backpack backpack);
}
