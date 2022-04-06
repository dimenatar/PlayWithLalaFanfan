using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Range(0,100)] [SerializeField] private float _chance;
    [SerializeField] private GameObject _coinPrefab;

    public GameObject SpawnCoinWithChange(Vector3 position)
    {
        float chance = Random.Range(0, 101);
        if (chance <= _chance)
            return Instantiate(_coinPrefab, position, Quaternion.identity);
        else return null;
    }
}
