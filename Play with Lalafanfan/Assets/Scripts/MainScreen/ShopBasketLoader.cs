using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopBasketLoader : MonoBehaviour
{
    [SerializeField] private GameObject _basket;
    [SerializeField] private Transform _storage;
    [SerializeField] private int _maxCapacity;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private float _yOffset;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private float _itemFlyHeight;
    [SerializeField] private int _rowCapacity;

    private int _itemAmount;
    private int _rowAmount;
    private int _currentRow;

    private Dictionary<float, bool> _basketItems = new Dictionary<float, bool>();

    private void Start()
    {
        InitialiseBasketDictionary();
    }

    public void AddItemToBasket(FoodData data, Vector3 startPosition)
    {
        GameObject item = Instantiate(_itemPrefab, startPosition, Quaternion.identity);
        item.transform.SetParent(_storage);
        item.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(data.IconResourceName);
        item.AddComponent<ShopBasketItem>();
        item.GetComponent<ShopBasketItem>().Initialise(GetItemPositionInBasket(), _itemFlyHeight, _itemAmount < _maxCapacity);
        _itemAmount++;
    }

    public void ClearBasket()
    {
        for (int i = 0; i < _storage.childCount; i++)
        {
            Destroy(_basket.transform.GetChild(i).gameObject);
        }
        _itemAmount = 0;
        _currentRow = 0;
        _rowAmount = 0;
    }

    private void InitialiseBasketDictionary()
    {
        float singleCellCapacity = Mathf.Abs(_leftPoint.position.x - _rightPoint.position.x) / _rowCapacity;
        float leftPointX = _leftPoint.position.x;
        for (int i = 0; i < _rowCapacity; i++)
        {
            _basketItems.Add(leftPointX + singleCellCapacity * i, false);
        }
    }

    private Vector3 GetItemPositionInBasket()
    {
        if (_itemAmount < _maxCapacity)
        {
            if (_rowAmount >= _rowCapacity)
            {
                _rowAmount = 0;
                foreach (var item in _basketItems.ToList())
                {
                    _basketItems[item.Key] = false;
                }
                _currentRow++;
            }
            _rowAmount++;
            var pair = _basketItems.ElementAt(Random.Range(0, _basketItems.Count));
            while (pair.Value == true)
            {
                pair = _basketItems.ElementAt(Random.Range(0, _basketItems.Count));
            }
            _basketItems[pair.Key] = true;
            float xPos = pair.Key;
            float yPos = _leftPoint.position.y + _currentRow * _yOffset;
            return new Vector3(xPos, yPos, _leftPoint.position.z);
        }
        else
        {
            var pair = _basketItems.ElementAt(Random.Range(0, _basketItems.Count));
            float yPos = _leftPoint.position.y + _yOffset;
            return new Vector3(pair.Key, yPos, _leftPoint.position.z);
        }
    }
}
