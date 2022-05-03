using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowHorizontal : MonoBehaviour
{
    [SerializeField] private RectTransform _parent;
    [SerializeField] private RectTransform _target;

    private Vector2 _delta = Vector2.zero;

    private void Update()
    {
        if (_delta != Vector2.zero)
        {
            _delta = _parent.anchoredPosition - _delta;
            _target.anchoredPosition += new Vector2(_delta.x, 0);
        }
        _delta = _parent.anchoredPosition;
    }
}
