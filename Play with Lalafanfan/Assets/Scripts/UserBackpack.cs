using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class UserBackpack 
{
    public UserBackpack()
    {
        WallpaperData defaultWallpaper = new WallpaperData("SkyBlue", 0, "SkyBlue");
        UpdateCurrentWallpaper(defaultWallpaper);
        Wallpapers.Add(defaultWallpaper);
    }

    private WallpaperData _currentWallpaper;

    public WallpaperData CurrentWallpaper => _currentWallpaper;
    public Dictionary<FoodData, int> Food { get; set; } = new Dictionary<FoodData, int>();
    public List<WallpaperData> Wallpapers { get; set; } = new List<WallpaperData>();
    public List<AppereanceData> Appereances { get; set; } = new List<AppereanceData>();

    public void AddWallpaper(WallpaperData data)
    {
        Wallpapers.Add(data);
    }

    public void UpdateCurrentWallpaper(WallpaperData data)
    {
        _currentWallpaper = data;
    }
}
