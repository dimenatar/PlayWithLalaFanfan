using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;


public class StarView : MonoBehaviour
{
    [SerializeField] private StarController _starController;
    [SerializeField] private TextMeshProUGUI _stars;

    private void Awake()
    {
        _starController.OnStarsUpdated += UpdateStarValue;
    }

    private void UpdateStarValue(int stars)
    {
        _stars.text = stars.ToString();
        _stars.transform.DOScale(_stars.transform.localScale * 1.3f, 0.1f).OnComplete(() => _stars.transform.DOScale(_stars.transform.localScale/1.3f, 1f));
    }
}
