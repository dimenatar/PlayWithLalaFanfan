using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JumpEndPanel : MonoBehaviour
{
    [SerializeField] private ObjectActiveManager _activeManager;
    [SerializeField] private Points _points;
    [SerializeField] private PointsAndMoneyCollector _scoreAndMoneyCollector;
    [SerializeField] private DuckJump _duckJump;
    [SerializeField] private UserMoney _userMoney;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _money;
    [SerializeField] private TextMeshProUGUI _currentPoints;
    [SerializeField] private TextMeshProUGUI _maxPoints;
    [SerializeField] private TextMeshProUGUI _newRecord;

    private void Awake()
    {
        _duckJump.OnDuckHitsDeadZone += ShowPanel;
    }

    public void ShowPanel()
    {
        EnablePanel();
        _panel.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 0.4f).SetUpdate(true);
    }

    private void EnablePanel()
    {
        _money.text = _userMoney.MoneyAmount.ToString();
        if (_points.Score > _scoreAndMoneyCollector.Points.HighestJumpPoints) // если побил рекорд
        {
            _maxPoints.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            _newRecord.gameObject.SetActive(false);
            _maxPoints.text = _scoreAndMoneyCollector.Points.HighestJumpPoints.ToString();
        }
        _currentPoints.text = _points.Score.ToString();
        _panel.SetActive(true);
        Time.timeScale = 0;
    }
}
