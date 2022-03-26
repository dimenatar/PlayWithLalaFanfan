using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class UserBackpack 
{
    public Dictionary<FoodData, int> Food { get; set; }
}
