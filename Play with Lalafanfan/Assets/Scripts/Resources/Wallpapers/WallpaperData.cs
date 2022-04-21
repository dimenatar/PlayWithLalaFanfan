using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WallpaperData : ResourceData, IResource
{
    public WallpaperData(string name, int price, string iconResourceName) : base(name, price, iconResourceName) { }
}
