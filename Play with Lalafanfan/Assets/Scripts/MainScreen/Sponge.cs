using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sponge : MonoBehaviour
{
    [SerializeField] private Vector3 _defaultPosition;
    [SerializeField] private EnergyController _energyController;
    [SerializeField] private WashingBubbleSpawner _washingBubbleSpawner;
    [SerializeField] private GameObject _duck;
    [SerializeField] private Camera _main;
    [SerializeField] private float _washingDelay;

    private bool _isCalculcatedDepth;
    private bool _isMovingSponge;
    private Transform _spongeTransform;
    private float _depth;


    private void Start()
    {
        _spongeTransform = transform;
    }

    private void Update()
    {
        //if (Input.touchCount > 0)
        MoveSponge();
    }

    private void MoveSponge()
    {
        if (Input.GetMouseButton(0))
        {
            if (!_isMovingSponge)
            {
                if (IsHoweringUIObject(this.gameObject))
                {
                    _isMovingSponge = true;
                }
            }
            else
            {
                _spongeTransform.position = Input.mousePosition;
            }
            if (IsHoweringObject(_duck))
            {
                Vector3 worldPosition = GetBubbleWorldPosition();
                StartCoroutine(nameof(WashDuck));
                Debug.Log(worldPosition);
                _washingBubbleSpawner.SpawnBubble(worldPosition);
            }
            else
            {
                StopCoroutine(nameof(WashDuck));
            }
        }
        else
        {
            if (_isMovingSponge)
            {
                ReturnSpongeToDefaultPosition();
                StopCoroutine(nameof(WashDuck));
            }
        }
    }

    private Vector3 GetBubbleWorldPosition()
    {
        Vector3 position = Input.mousePosition;
        if (!_isCalculcatedDepth)
        {
            _depth = _main.transform.localPosition.y - _duck.transform.position.y;
            _isCalculcatedDepth = true;
        }
        position.z = _depth;

        Vector3 worldPosition = _main.ScreenToWorldPoint(position);
        return worldPosition;
    }

    private void ReturnSpongeToDefaultPosition()
    {
        _isMovingSponge = false;
        transform.position = _defaultPosition;
    }

    private bool IsHoweringObject(GameObject gameObject)
    {
        var colliders = Physics.RaycastAll(_main.ScreenPointToRay(Input.mousePosition));
        foreach (var collider in colliders)
        {
            if (collider.collider.name == gameObject.name)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsHoweringUIObject(GameObject gameObject)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        if (raycastResults.Count > 0)
        {
            foreach (var go in raycastResults)
            {
                if (go.gameObject == gameObject)
                {
                    Debug.Log(go.gameObject.name);
                    return true;
                }
            }
        }
        return false;
    }

    private IEnumerator WashDuck()
    {
        while (true)
        {
            _energyController.WashDuck();
            yield return new WaitForSeconds(_washingDelay);
        }
    }
}
