using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoringnessView : MonoBehaviour
{
    [SerializeField] private UserBoringness _userBoringness;
    [SerializeField] private Image _boringness;
    [SerializeField] private Gradient _gradient;

    private void Awake()
    {
        _userBoringness.OnBoringnessChanged += ChangeView;
    }

    private void ChangeView(float boringness)
    {
        if (_userBoringness.MaxBoringness != 0)
        {
            _boringness.fillAmount = boringness / _userBoringness.MaxBoringness;
        }
        else
        {
            _boringness.fillAmount = 0;
        }
        _boringness.color = _gradient.Evaluate(_boringness.fillAmount);
    }
}
