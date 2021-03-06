using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DuckHealthView : MonoBehaviour
{
    [SerializeField] private DuckHealth _duckHealth;
    [SerializeField] private List<Image> _hearts;

    private int _heartIndex;

    private void Awake()
    {
        _duckHealth.OnHealthValueChanged += ReduceHealth;
    }

    private void ReduceHealth(int health)
    {
        for (int i = 0; i < _hearts.Count - health; i++)
        {
            if (_hearts[i].enabled)
            {
                _hearts[i].transform.DOScale(Vector3.zero, 0.4f).OnComplete(() => _hearts[i].enabled = false);
            }
        }       
    }
}
