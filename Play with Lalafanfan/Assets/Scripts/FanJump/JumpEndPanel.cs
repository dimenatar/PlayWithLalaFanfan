using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private Text _money;
    [SerializeField] private Text _currentPoints;
    [SerializeField] private Text _maxPoints;
    [SerializeField] private Text _newRecord;

    private void Awake()
    {
        _duckJump.OnDuckHitsDeadZone += ShowPanel;
    }

    public void ShowPanel()
    {
        Invoke(nameof(EnablePanel), 0);
    }

    private void EnablePanel()
    {
        _money.text = _userMoney.MoneyAmount.ToString();
        Debug.Log(_points.Score);
        Debug.Log(_scoreAndMoneyCollector.Points);
        Debug.Log(_scoreAndMoneyCollector.Points.HighestJumpPoints);
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
