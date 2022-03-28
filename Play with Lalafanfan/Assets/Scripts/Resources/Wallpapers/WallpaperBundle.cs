using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Wallpaper Bundle", menuName = "Wallpaper Bundle", order = 43)]
public class WallpaperBundle : ScriptableObject
{
    [SerializeField] private List<WallpaperData> _wallpapers;

    public List<WallpaperData> Wallpapers => _wallpapers;
}
