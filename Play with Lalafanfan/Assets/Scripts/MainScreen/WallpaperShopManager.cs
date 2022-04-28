using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WallpaperShopManager : MonoBehaviour
{
    [SerializeField] private Wallpapers _wallpapers;
    [SerializeField] private WallpaperBundle _wallpaperBundle;
    [SerializeField] private Button _wallpaperState;
    [SerializeField] private UserMoney _money;
    [SerializeField] private List<MeshRenderer> _walls;
    [SerializeField] private Color _setted;
    [SerializeField] private Color _canSet;
    [SerializeField] private Color _buy;

    private int _index;
    private int _maxIndex;
    private WallpaperButtonState _wallpaperButtonState;

    private void Awake()
    {

    }

    private void Start()
    {
        _maxIndex = _wallpaperBundle.Wallpapers.Count;
    }

    public void ButtonClick()
    {
        switch (_wallpaperButtonState)
        {
            case WallpaperButtonState.Buy:
                {
                    if (_money.ReduceMoney(_wallpaperBundle.Wallpapers[_index].Price))
                    {
                        _wallpapers.AddWallpaper(_wallpaperBundle.Wallpapers[_index]);
                        _wallpaperButtonState = WallpaperButtonState.CanSet;
                    }
                    break;
                }
            case WallpaperButtonState.CanSet:
                {
                    _wallpapers.UpdateCurrentWallpaper(_wallpaperBundle.Wallpapers[_index]);
                    _wallpaperButtonState = WallpaperButtonState.Setted;
                    break;
                }
        }
        SetButtonAppearance(_wallpaperBundle.Wallpapers[_index]);
    }

    public void ShopWallpaperShow() 
    {
        _index = 0;
        ShowWallpaperInfo(_wallpaperBundle.Wallpapers[_index]);
    }

    public void ExitFromShop()
    {
        _wallpapers.SetCurrentWallpapers();
    }

    public void PrevClick()
    {
        if (_index - 1 >= 0)
        {
            _index--;
        }
        else
        {
            _index = _maxIndex - 1;
        }
        ShowWallpaperInfo(_wallpaperBundle.Wallpapers[_index]);
    }

    public void NextClick()
    {
        if (_index + 1 < _maxIndex)
        {
            _index++;
        }
        else
        {
            _index = 0;
        }
        ShowWallpaperInfo(_wallpaperBundle.Wallpapers[_index]);
    }

    private void ShowWallpaperInfo(WallpaperData wallpaperData)
    {
        ApplyWallpapers(wallpaperData);
        if (_wallpapers.AvailableWallpapers.Where(wallpaper => wallpaper.Name == wallpaperData.Name).Count() > 0) // if wallpaper already bought by user
        {
            if (!_wallpapers.CurrentWallpaper.Name.Equals(wallpaperData.Name)) 
            {
                _wallpaperButtonState = WallpaperButtonState.CanSet;
            }
            else
            {
                _wallpaperButtonState = WallpaperButtonState.Setted;
            }
        }
        else
        {
            _wallpaperButtonState = WallpaperButtonState.Buy;
        }
        SetButtonAppearance(wallpaperData);
    }

    private void SetButtonAppearance(WallpaperData wallpaperData)
    {
        switch (_wallpaperButtonState)
        {
            case WallpaperButtonState.CanSet:
                {
                    _wallpaperState.GetComponent<Image>().color = _canSet;
                    _wallpaperState.transform.Find("Text").GetComponent<Text>().text = "Установить";
                    break;
                }
                case WallpaperButtonState.Buy:
                {
                    if (_money.MoneyAmount - wallpaperData.Price >= 0)
                    {
                        _wallpaperState.GetComponent<Image>().color = _buy;
                    }
                    else
                    {
                        _wallpaperState.GetComponent<Image>().color = _setted;
                    }

                    _wallpaperState.transform.Find("Text").GetComponent<Text>().text = "Купить";
                    break;
                }
            case WallpaperButtonState.Setted:
                {
                    _wallpaperState.GetComponent<Image>().color = _setted;
                    _wallpaperState.transform.Find("Text").GetComponent<Text>().text = "Установлено";
                    break;
                }
        }
    }

    private void ApplyWallpapers(WallpaperData wallpaperData)
    {
        Material wallpaper = Resources.Load<Material>(wallpaperData.IconResourceName);
        foreach (var item in _walls)
        {
            item.material = wallpaper;
        }
    }
}

public enum WallpaperButtonState
{
    Setted,
    CanSet,
    Buy
}

