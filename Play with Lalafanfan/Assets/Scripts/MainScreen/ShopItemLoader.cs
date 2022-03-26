using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopItemLoader : MonoBehaviour
{
    [SerializeField] private FoodBundle _foodBundle;
    [SerializeField] private GameObject _content;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private UserMoney _money;

    private int _categoryIndex;

    private void Start()
    {
        SwitchToFood();
    }

    public void SwitchToFood()
    {
        _categoryIndex = 0;
        LoadFoodBunle();
    }

    public void ChangeFoodCategory(bool increaseIndex)
    {
        if (increaseIndex)
        {
            IncreaseFoodCategory();
        }
        else
        {

        }
        LoadFoodBunle();
    }

    private void IncreaseFoodCategory()
    {
        if (_categoryIndex < _foodBundle.CategoryAmount)
        {
            _categoryIndex++;
        }
        else
        {
            _categoryIndex = 0;
        }
    }

    private void LoadFoodBunle()
    {
        FoodType requiredType = (FoodType)_categoryIndex;
        List<FoodData> currentFoodData = _foodBundle.Foods.Where(food => food.Type == requiredType).ToList();
        foreach (FoodData foodData in currentFoodData)
        {
            GameObject item = Instantiate(_itemPrefab, _content.transform);
            item.AddComponent<ShopItem>();
        }
    }
}
