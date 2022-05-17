using DG.Tweening;
using TMPro;
using UnityEngine;

public class RunnerEndPanel : MonoBehaviour
{
    [SerializeField] private ObjectActiveManager _activeManager;
    [SerializeField] private Points _points;
    [SerializeField] private PointsAndMoneyCollector _scoreAndMoneyCollector;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private UserMoney _userMoney;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _money;
    [SerializeField] private TextMeshProUGUI _currentPoints;
    [SerializeField] private TextMeshProUGUI _maxPoints;
    [SerializeField] private TextMeshProUGUI _newRecord;

    private void Awake()
    {
        _playerMovement.OnPlayerHitObstacle += _activeManager.Deactivate;
        _playerMovement.OnPlayerHitObstacle += ShowPanel;
    }

    public void ShowPanel()
    {
        EnablePanel();
        _panel.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 0.4f).SetUpdate(true);
    }

    private void EnablePanel()
    {
        _money.text = _userMoney.MoneyAmount.ToString();
        if (_points.Score > _scoreAndMoneyCollector.Points.HighestRunnerPoints) // если побил рекорд
        {
            _maxPoints.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            _newRecord.gameObject.SetActive(false);
            _maxPoints.text = _scoreAndMoneyCollector.Points.HighestRunnerPoints.ToString();
        }
        _currentPoints.text = _points.Score.ToString();
        _panel.SetActive(true);
        Time.timeScale = 0;
    }
}
