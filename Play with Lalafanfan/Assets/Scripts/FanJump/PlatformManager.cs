using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject _firstPlatform;
    [SerializeField] private int _startPlatofrmAmount;
    [SerializeField] private float _startYOffset;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _addAmountToYOffset;

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
        for (int i = 0; i < _startPlatofrmAmount; i++)
        {
            GameObject platform = Instantiate(_firstPlatform, new Vector2(Random.Range(-_xOffset/2, _xOffset/2), _YPos), Quaternion.identity);
            platform.GetComponent<Platform>().OnHitsDeadZone += RelocatePlatform;
            _YPos += _currentYOffset;
        }
    }

    private void RelocatePlatform(GameObject platform)
    {
        platform.transform.position = new Vector2(Random.Range(-_xOffset / 2, _xOffset / 2), _YPos);
        platform.GetComponent<Platform>().AddJumpMultiplicator(_addAmountToYOffset);
        _YPos += _addAmountToYOffset;
    }
}
