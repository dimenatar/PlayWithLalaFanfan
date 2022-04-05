using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class UserBackpack 
{
    public Dictionary<FoodData, int> Food { get; set; } = new Dictionary<FoodData, int>();
    public List<WallpaperData> Wallpapers { get; set; } = new List<WallpaperData>();
    public List<AppereanceData> Appereances { get; set; } = new List<AppereanceData>();
}
