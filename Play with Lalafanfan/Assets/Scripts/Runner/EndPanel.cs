using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private ObjectActiveManager _activeManager;
    [SerializeField] private Points _points;
    [SerializeField] private ScoreAndMoneyCollector _scoreAndMoneyCollector;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private UserMoney _userMoney;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Text _money;
    [SerializeField] private Text _currentPoints;
    [SerializeField] private Text _maxPoints;
    [SerializeField] private Text _newRecord;

    private void Awake()
    {
        _playerMovement.OnPlayerHitObstacle += _activeManager.Deactivate;
        _playerMovement.OnPlayerHitObstacle += ShowPanel;
    }

    public void ShowPanel()
    {
        Invoke(nameof(EnablePanel), 0.5f);
    }

    private void EnablePanel()
    {
        _money.text = _userMoney.MoneyAmount.ToString();
        if (_points.Score > _scoreAndMoneyCollector.HighestRunnerPoints)
        {
            _maxPoints.transform.parent.gameObject.SetActive(false);
            _newRecord.gameObject.SetActive(false);
        }
        else
        {
            _maxPoints.text = _scoreAndMoneyCollector.HighestRunnerPoints.ToString();
            _currentPoints.text = _points.Score.ToString();
        }
        _panel.SetActive(true);
        Time.timeScale = 0;
    }
}
