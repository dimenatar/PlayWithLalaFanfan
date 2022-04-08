using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectsSpawner : MonoBehaviour
{
    [Range(0, 100)] [SerializeField] private int _chanceToSpawnJunk;
    [SerializeField] private float _startItemDelay;
    [SerializeField] private float _minItemDelay;
    [SerializeField] private float _delayOffset;
    [SerializeField] private GameObject _duck;
    [SerializeField] private List<Sprite> _foodImages;
    [SerializeField] private List<Sprite> _junkImages;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private DuckHealth _duckHealth;

    private float _spawnDelay;
    private float _leftXBorder;
    private float _rightXBorder;
    private float _topYPoint;

    private void Awake()
    {
        _duckHealth.OnDied += StopSpawn;
    }

    private void Start()
    {
        _spawnDelay = _startItemDelay;
        CalculateBorders();
        StartCoroutine(nameof(SpawnItem));
    }

    private IEnumerator SpawnItem()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            GameObject item = Instantiate(_itemPrefab, new Vector3(UnityEngine.Random.Range(_leftXBorder, _rightXBorder), _topYPoint, 0), Quaternion.identity);
            Item type = GetRandomType();
            item.GetComponent<FallingItem>().Type = type;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(type);
            if (_spawnDelay - _delayOffset > _minItemDelay)
            {
                _spawnDelay -= _delayOffset;
            }
            GameObject coin = _coinSpawner.SpawnCoinWithChance(new Vector3(UnityEngine.Random.Range(_leftXBorder, _rightXBorder), _topYPoint, 0));
            if (coin)
            {
                coin.transform.localScale /= 20;
                coin.AddComponent<FallingItem>();
                coin.GetComponent<FallingItem>().Type = Item.Coin;
            }
        }
    }

    private Sprite GetRandomSprite(Item item)
    {
        if (item == Item.Food)
        {
            return _foodImages[UnityEngine.Random.Range(0, _foodImages.Count)];
        }
        else
        {
            return _junkImages[UnityEngine.Random.Range(0, _junkImages.Count)];

        }
    }

    private Item GetRandomType()
    {
        return (Item)Convert.ToInt32(UnityEngine.Random.Range(0, 101) <= _chanceToSpawnJunk);
    }

    private void CalculateBorders()
    {
        var depth = _duck.transform.position.y - Camera.main.transform.position.y;
        var middleRight = new Vector3(Screen.width, Screen.height / 2, depth);
        var middleLeft = new Vector3(0, Screen.height / 2, depth);
        var topPoint = new Vector3(0, Screen.height, depth);

        _rightXBorder = Camera.main.ScreenToWorldPoint(middleRight).x - _itemPrefab.transform.localScale.x;
        _leftXBorder = Camera.main.ScreenToWorldPoint(middleLeft).x + _itemPrefab.transform.localScale.x;
        _topYPoint = Camera.main.ScreenToWorldPoint(topPoint).y + _itemPrefab.transform.localScale.y;
    }

    private void StopSpawn()
    {
        StopCoroutine(nameof(SpawnItem));
    }
}

public enum Item
{
    Food,
    Junk,
    Coin
}

