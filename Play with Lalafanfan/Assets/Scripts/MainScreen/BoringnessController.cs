using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoringnessController : MonoBehaviour
{
    [SerializeField] private UserBoringness _boringness;
    [SerializeField] private float _startAddingAmount;
    [SerializeField] private float _startDecreaseAmountFromPlaymode;
    [SerializeField] private float _delayToIncrease;

    private bool _isInitialised;

    private void Awake()
    {
        _boringness.OnInitialise += Initialise;
        //SceneManager.sceneUnloaded += (Scene scene) => StopCoroutine(nameof(IncreaseBoringness));
    }

    private void OnEnable()
    {
        if (_isInitialised)
        {
            StartCoroutine(nameof(IncreaseBoringness));
        }
    }

    public void AddFromPlaymode() => _boringness.ReduceBoringness(_startDecreaseAmountFromPlaymode);

    private void Initialise()
    {
        Debug.Log("bo init");
        StartCoroutine(nameof(IncreaseBoringness));
        _isInitialised = true;
    }

    private IEnumerator IncreaseBoringness()
    { 
        while (true)
        {
            _boringness.IncreaseBoringness(_startAddingAmount);
            yield return new WaitForSeconds(_delayToIncrease);
        }
    }
}
