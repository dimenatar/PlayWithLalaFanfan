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
    [SerializeField] private List<Sprite> _foodImages;
    [SerializeField] private List<Sprite> _junkImages;
    [SerializeField] private GameObject _itemPrefab;

    private float _spawnDelay;

    private void Start()
    {
        _spawnDelay = _startItemDelay;
        StartCoroutine(nameof(SpawnItem));
    }

    private IEnumerator SpawnItem()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            GameObject item = Instantiate(_itemPrefab, new Vector3(), Quaternion.identity);
            Item type = GetRandomType();
            item.GetComponent<FallingItem>().Type = type;
            item.GetComponent<SpriteRenderer>().sprite = GetRandomSprite(type);
            if (_spawnDelay - _delayOffset > _minItemDelay)
            {
                _spawnDelay -= _delayOffset;
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
}

public enum Item
{
    Food,
    Junk
}

