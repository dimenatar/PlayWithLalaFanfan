using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BackpackItemLoader : MonoBehaviour
{
    [SerializeField] private Backpack _backpack;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _content;
    [SerializeField] private FoodSatiety _foodSatiety;

    private void Awake()
    {
        _backpack.OnFoodEmpty += RemoveFoodItem;
    }

    public void LoadFood()
    {
        ClearContent();
        var food = _backpack.Pack.Food;
        foreach (var item in food)
        {
            GameObject listItem = Instantiate(_prefab, _content.transform);
            listItem.transform.Find("Food").GetComponent<Image>().sprite = Resources.Load<Sprite>(item.Key.IconResourceName);
            listItem.transform.Find("Amount").Find("Value").GetComponent<Text>().text = GetFoodAmount(item.Key);
            listItem.AddComponent<FoodBackpackItem>();
            listItem.GetComponent<FoodBackpackItem>().Initialise(item.Key);
            listItem.GetComponent<FoodBackpackItem>().OnItemClick += SpentFood;
            listItem.GetComponent<FoodBackpackItem>().OnItemClick += ReduceFoodAmountOnText;
        }
    }

    private void ClearContent()
    {
        for (int i = 0; i < _content.transform.childCount; i++)
        {
            Destroy(_content.transform.GetChild(i).gameObject);
        }
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
        if (_foodSatiety.Feed(data.FedForce))
        {
            _backpack.ReduceFood(data);
        }
    }

    private string GetFoodAmount(FoodData data)
    {
        int foodAmount = _backpack.GetFoodItemAmount(data) + 1;
        return foodAmount >= 100 ? "99+" : foodAmount.ToString();
    }
}
