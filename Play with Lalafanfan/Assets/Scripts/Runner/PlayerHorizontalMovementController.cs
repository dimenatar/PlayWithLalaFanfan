using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerHorizontalMovementController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _button;
    [SerializeField] private float _strafeForce;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (IsHoweringObject())
            {
                _playerMovement.Strafe(_strafeForce);
            }
        }
    }

    private bool IsHoweringObject()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        if (raycastResults.Count > 0)
        {
            foreach (var go in raycastResults)
            {
                if (go.gameObject == _button)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
