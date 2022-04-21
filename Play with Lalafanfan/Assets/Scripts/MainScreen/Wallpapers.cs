using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallpapers : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> _walls;

    private WallpaperData _currentWallpaper;
    private List<WallpaperData> _availableWallpapers;

    public WallpaperData CurrentWallpaper => _currentWallpaper;
    public List<WallpaperData> AvailableWallpapers => _availableWallpapers;

    public void Initialise(WallpaperData currentWallpaper, List<WallpaperData> availableWallpapers)
    {
        _currentWallpaper = currentWallpaper;
        _availableWallpapers = availableWallpapers;
        SetCurrentWallpapers();
    }

    public void AddWallpaper(WallpaperData wallpaperData) => _availableWallpapers.Add(wallpaperData);

    public void UpdateCurrentWallpaper(WallpaperData wallpaperData)
    {
        _currentWallpaper = wallpaperData;
    }

    public void SetCurrentWallpapers()
    {
        Material material = Resources.Load<Material>(_currentWallpaper.IconResourceName);
        foreach (var item in _walls)
        {
            item.material = material;
        }
    }
}
