using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourceData 
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private string _iconResourceName;

    public string Name => _name;
    public int Price => _price;
    public string IconResourceName => _iconResourceName;
}
