using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BackpackItemLoader : MonoBehaviour
{
    [SerializeField] private Backpack _backpack;
    [SerializeField] private Image _backGround;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _content;
    [SerializeField] private FoodSatiety _foodSatiety;

    private Dictionary<int, string> _listOfMethodsToCall = new Dictionary<int, string> { { 0, nameof(SwitchToFood) },
                                                       {1, nameof(SwitchToAppearance) }, { 2, nameof(SwitchToWallpaper)} };
    private int _index;

    public void ChangeIndex(bool increase)
    {
        if (increase)
        {
            IncreaseIndex();
        }
        else
        {
            DecreaseIndex();
        }
        Invoke(_listOfMethodsToCall[_index], 0);
    }

    private void IncreaseIndex()
    {
        if (_index + 1 < _listOfMethodsToCall.Count)
        {
            _index++;
        }
        else
        {
            _index = 0;
        }
    }

    private void DecreaseIndex()
    {
        if (_index - 1 > 0)
        {
            _index--;
        }
        else
        {
            _index = _listOfMethodsToCall.Count;
        }
    }

    private void SwitchToFood()
    {
        var food = _backpack.Pack.Food;
        foreach (var item in food)
        {
            GameObject listItem = Instantiate(_prefab, _content.transform);
            listItem.GetComponent<Image>().sprite = Resources.Load<Sprite>(item.Key.IconResourceName);
            listItem.AddComponent<FoodBackpackItem>();
            listItem.GetComponent<FoodBackpackItem>().OnItemClick += SpentFood;
        }
    }

    private void SwitchToAppearance()
    {
        var appearance = _backpack.Pack.Appereances;
        foreach (var item in appearance)
        {
            GameObject listItem = Instantiate(_prefab, _content.transform);
            listItem.GetComponent<Image>().sprite = Resources.Load<Sprite>(item.IconResourceName);
        }
    }

    private void SwitchToWallpaper()
    {
        var wallpaper = _backpack.Pack.Wallpapers;
        foreach (var item in wallpaper)
        {
            GameObject listItem = Instantiate(_prefab, _content.transform);
            listItem.GetComponent<Image>().sprite = Resources.Load<Sprite>(item.IconResourceName);
            listItem.AddComponent<WallpaperBackpackItem>();
            listItem.GetComponent<WallpaperBackpackItem>().OnItemClick += ReplaceWallpaper;
        }
    }

    private void ClearContent()
    {
        for (int i = 0; i < _content.transform.childCount; i++)
        {
            Destroy(_content.transform.GetChild(i).gameObject);
        }
    }

    private void ReplaceWallpaper(WallpaperData data)
    {
        _backGround.sprite = Resources.Load<Sprite>(data.IconResourceName);
    }

    private void SpentFood(FoodData data)
    {
        _foodSatiety.Feed(data.FedForce);
        _backpack.ReduceFood(data);
    }
}
