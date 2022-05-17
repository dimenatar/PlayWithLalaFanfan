using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CatchFoodEndPanel : MonoBehaviour
{
    [SerializeField] private ObjectActiveManager _activeManager;
    [SerializeField] private Points _points;
    [SerializeField] private PointsAndMoneyCollector _scoreAndMoneyCollector;
    [SerializeField] private DuckHealth _duckHealth;
    [SerializeField] private UserMoney _userMoney;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _money;
    [SerializeField] private TextMeshProUGUI _currentPoints;
    [SerializeField] private TextMeshProUGUI _maxPoints;
    [SerializeField] private TextMeshProUGUI _newRecord;
    [SerializeField] private Vector2 _releasedPos;

    private void Awake()
    {
        _duckHealth.OnDied += ShowPanel;
    }

    public void ShowPanel()
    {
        EnablePanel();
        _panel.GetComponent<RectTransform>().DOAnchorPos(_releasedPos, 0.4f).SetUpdate(true);
    }

    private void EnablePanel()
    {
        _money.text = _userMoney.MoneyAmount.ToString();
        if (_points.Score > _scoreAndMoneyCollector.Points.HighestFoodCatchPoints) // если побил рекорд
        {
            _maxPoints.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            _newRecord.gameObject.SetActive(false);
            _maxPoints.text = _scoreAndMoneyCollector.Points.HighestFoodCatchPoints.ToString();
        }
        _currentPoints.text = _points.Score.ToString();
        Time.timeScale = 0;
    }
}
