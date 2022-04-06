using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [Range(0, 100)]  [SerializeField] private float _chanceToSpawnMegaPlatform;
    [Range(0, 100)]  [SerializeField] private float _chanceToSpawnBrokenPlatform;
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private GameObject _firstPlatform;
    [SerializeField] private GameObject _brokenPlatformPrefab;
    [SerializeField] private GameObject _megaPlatformPrefab;
    [SerializeField] private int _startPlatformAmount;
    [SerializeField] private float _startYOffset;
    [SerializeField] private float _xOffset;

    private float _currentYOffset;
    private float _YPos;

    private void Start()
    {
        _currentYOffset = _startYOffset;
        InstantiatePlatforms();
    }

    private void InstantiatePlatforms()
    {
        _YPos = _firstPlatform.transform.position.y + _currentYOffset;
        _firstPlatform.GetComponent<Platform>().OnHitsDeadZone += RelocatePlatform;
        for (int i = 0; i < _startPlatformAmount; i++)
        {
            GameObject platform;
            if (ShouldSpawnBroken())
            {
                platform = Instantiate(_brokenPlatformPrefab, new Vector2(Random.Range(-_xOffset / 2, _xOffset / 2), _YPos), Quaternion.identity);
            }
            else if (ShouldSpawnMega())
            {
                platform = Instantiate(_megaPlatformPrefab, new Vector2(Random.Range(-_xOffset / 2, _xOffset / 2), _YPos), Quaternion.identity);
            }
            else
            {
                platform = Instantiate(_firstPlatform, new Vector2(Random.Range(-_xOffset/2, _xOffset/2), _YPos), Quaternion.identity);
            }
            platform.GetComponent<Platform>().OnHitsDeadZone += RelocatePlatform;
            platform.GetComponent<Platform>().OnHitsDeadZone += AddCoinToPlatform;
            AddCoinToPlatform(platform);
            _YPos += _currentYOffset + Random.Range(-_currentYOffset/10, _currentYOffset/10);
        }
    }

    private bool ShouldSpawnBroken() => Random.Range(0, 101) <= _chanceToSpawnBrokenPlatform;

    private bool ShouldSpawnMega() => Random.Range(0, 101) <= _chanceToSpawnMegaPlatform;

    private void RelocatePlatform(GameObject platform)
    {
        if (ShouldSpawnBroken())
        {
            Destroy(platform);
            platform = Instantiate(_brokenPlatformPrefab, new Vector2(Random.Range(-_xOffset / 2, _xOffset / 2), _YPos), Quaternion.identity);
        }
        else if (ShouldSpawnMega())
        {
            Destroy(platform);
            platform = Instantiate(_megaPlatformPrefab, new Vector2(Random.Range(-_xOffset / 2, _xOffset / 2), _YPos), Quaternion.identity);
        }
        platform.transform.position = new Vector2(Random.Range(-_xOffset / 2, _xOffset / 2), _YPos);
        platform.GetComponent<Platform>().CalculateJumpMultiplicator();
        _YPos += _currentYOffset + Random.Range(-_currentYOffset / 10, _currentYOffset / 10);
    }

    private void AddCoinToPlatform(GameObject platform)
    {
        if (!platform.transform.Find("Coin"))
        {
            GameObject coin = _coinSpawner.SpawnCoinWithChange(platform.transform.position);
            if (coin)
            {
                coin.name = "Coin";
                coin.transform.localScale /= 15;
                coin.transform.SetParent(platform.transform);
                coin.transform.localPosition += new Vector3(0, 10, 0);
            }
        }
    }
}
