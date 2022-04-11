using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BackpackItemLoader : MonoBehaviour
{
    [SerializeField] private Backpack _backpack;
    [SerializeField] private Image _background;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _content;
    [SerializeField] private FoodSatiety _foodSatiety;

    private Dictionary<int, string> _listOfMethodsToCall = new Dictionary<int, string> { { 0, nameof(SwitchToFood) },
                                                       {1, nameof(SwitchToAppearance) }, { 2, nameof(SwitchToWallpaper)} };
    private int _index;

    private void Awake()
    {
        _backpack.OnFoodEmpty += RemoveFoodItem;
    }

    public void Initialise()
    {
        SwitchToFood();
    }

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
        ClearContent();
        var food = _backpack.Pack.Food;
        foreach (var item in food)
        {
            GameObject listItem = Instantiate(_prefab, _content.transform);
            listItem.transform.Find("Food").GetComponent<Image>().sprite = Resources.Load<Sprite>(item.Key.IconResourceName);
            listItem.transform.Find("Amount").Find("Value").GetComponent<Text>().text = GetFoodAmount(item.Key);
            //listItem.transform.Find("Table").Find("FeedForce").GetComponent<Text>().text = item.Key.FedForce.ToString();
            listItem.AddComponent<FoodBackpackItem>();
            listItem.GetComponent<FoodBackpackItem>().Initialise(item.Key);
            listItem.GetComponent<FoodBackpackItem>().OnItemClick += SpentFood;
            listItem.GetComponent<FoodBackpackItem>().OnItemClick += ReduceFoodAmountOnText;
        }
    }

    private void SwitchToAppearance()
    {
        ClearContent();
        var appearance = _backpack.Pack.Appereances;
        foreach (var item in appearance)
        {
            GameObject listItem = Instantiate(_prefab, _content.transform);
            listItem.GetComponent<Image>().sprite = Resources.Load<Sprite>(item.IconResourceName);
        }
    }

    private void SwitchToWallpaper()
    {
        ClearContent();
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
        _background.sprite = Resources.Load<Sprite>(data.IconResourceName);
    }

    private void RemoveFoodItem(FoodData data)
    {
        Debug.Log("remove");
        for (int i = 0; i < _content.transform.childCount; i++)
        {
            if (_content.transform.GetChild(i).GetComponent<FoodBackpackItem>().Data == data)
            {
                Destroy(_content.transform.GetChild(i).gameObject);
            }
        }
    }

    private void ReduceFoodAmountOnText(FoodData data)
    {
        Transform child;
        for (int i = 0; i < _content.transform.childCount; i++)
        {
            child = _content.transform.GetChild(i);
            if (child.GetComponent<FoodBackpackItem>().Data == data)
            {
                child.transform.Find("Amount").Find("Value").GetComponent<Text>().text = GetFoodAmount(data);
            }
        }
    }

    private void SpentFood(FoodData data)
    {
        _backpack.ReduceFood(data);
        _foodSatiety.Feed(data.FedForce);
    }

    private string GetFoodAmount(FoodData data)
    {
        int foodAmount = _backpack.GetFoodItemAmount(data) + 1;
        return foodAmount >= 100 ? "99+" : foodAmount.ToString();
    }
}
