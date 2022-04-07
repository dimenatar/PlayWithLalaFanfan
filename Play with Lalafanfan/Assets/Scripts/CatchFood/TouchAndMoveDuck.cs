 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchAndMoveDuck : MonoBehaviour, IDragHandler
{
    private bool _isTouchingDuck;
    private float _xRightPoint;
    private float _xLeftPoint;

    private void Start()
    {
        CalculateBorders();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = eventData.pointerCurrentRaycast.worldPosition;
        float positionXInBounds = Mathf.Clamp(position.x, _xLeftPoint, _xRightPoint);
        transform.position = new Vector3(positionXInBounds, transform.position.y, transform.position.z);
    }

    private void CalculateBorders()
    {
        var depth = transform.position.y - Camera.main.transform.position.y;
        var middleRight = new Vector3(Screen.width, Screen.height / 2, depth);
        var middleLeft = new Vector3(0, Screen.height / 2, depth);

        _xRightPoint = Camera.main.ScreenToWorldPoint(middleRight).x - transform.localScale.x;
        _xLeftPoint = Camera.main.ScreenToWorldPoint(middleLeft).x + transform.localScale.x;
    }
}
