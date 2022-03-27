using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopItemLoader : MonoBehaviour
{
    [SerializeField] private FoodBundle _foodBundle;
    [SerializeField] private AppearanceBundle _appearanceBundle;
    [SerializeField] private GameObject _content;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private UserMoney _money;
    [SerializeField] private ShopSumbitPurchasePanel _sumbitPurchasePanel;
    [SerializeField] private Backpack _backpack;
    [SerializeField] private Text _category;

    private int _categoryAmount;
    private int _categoryIndex;

    private void Start()
    {
        SwitchToFood();
    }

    public void SwitchToFood()
    {
        ClearContent();
        _categoryAmount = Enum.GetNames(typeof(FoodType)).Length;
        _categoryIndex = 0;
        LoadFoodBunle();
    }

    public void SwitchToAppearance()
    {
        ClearContent();
        _categoryAmount = Enum.GetNames(typeof(AppearanceType)).Length;
        _categoryIndex = 0;
        LoadAppearanseBundle();
    }

    public void ChangeFoodCategory(bool increaseIndex)
    {
        ClearContent();
        if (increaseIndex)
        {
            IncreaseCategory();
        }
        else
        {
            DecreaseCategory();
        }
        LoadFoodBunle();
    }

    private void DecreaseCategory()
    {
        if (_categoryIndex - 1 > 0)
        {
            _categoryIndex--;
        }
        else
        {
            _categoryIndex = _categoryAmount - 1;
        }
    }

    private void IncreaseCategory()
    {
        if (_categoryIndex + 1 < _categoryAmount)
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
        _category.text = FoodData.FoodTypeTranslate[requiredType];
        List<FoodData> currentFoodData = _foodBundle.Foods.Where(food => food.Type == requiredType).ToList();
        foreach (FoodData foodData in currentFoodData)
        {
            GameObject item = Instantiate(_itemPrefab, _content.transform);
            item.GetComponent<Image>().sprite = Resources.Load<Sprite>(foodData.IconResourceName);
            item.transform.Find("Table").Find("Price").GetComponent<Text>().text = foodData.Price.ToString();
            item.transform.Find("Table").Find("FeedForce").GetComponent<Text>().text = foodData.FedForce.ToString();
            item.AddComponent<ShopItem>();
            item.GetComponent<ShopItem>().Initialise(foodData);
            item.GetComponent<ShopItem>().OnItemClick += PurchaseItem;
        }
    }

    private void LoadAppearanseBundle()
    {
        AppearanceType requiredType = (AppearanceType)_categoryIndex;
        _category.text = AppereanceData.AppearanceTypeTranslate[requiredType];
        List<AppereanceData> currentAppearanceData = _appearanceBundle.Appearances.Where(appearance => appearance.Type == requiredType).ToList();
        foreach (AppereanceData appearanceData in currentAppearanceData)
        {
            GameObject item = Instantiate(_itemPrefab, _content.transform);
            item.GetComponent<Image>().sprite = Resources.Load<Sprite>(appearanceData.IconResourceName);
            item.transform.Find("Table").Find("Price").GetComponent<Text>().text = appearanceData.Price.ToString();
            item.transform.Find("Table").Find("FeedForce").gameObject.SetActive(false);
            item.AddComponent<ShopItem>();
            item.GetComponent<ShopItem>().Initialise(appearanceData);
            item.GetComponent<ShopItem>().OnItemClick += SubscribeToPanel;
        }
    }

    private void ClearContent()
    {
        for (int i = 0; i < _content.transform.childCount; i++)
        {
            Destroy(_content.transform.GetChild(i).gameObject);
        }
    }

    private void PurchaseItem(IResource resource)
    {
        resource.PurchaseItem(_money);
    }

    private void SubscribeToPanel(IResource resource)
    {
        _sumbitPurchasePanel.ShowPanel(resource);
    }
}
