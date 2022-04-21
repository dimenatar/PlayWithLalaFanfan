using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameobjectAnimationBehindScreen : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsToAnimate;
    [SerializeField] private float _animationDurationIn = 0.5f;
    [SerializeField] private float _animationDurationOut = 0.5f;

    private List<Vector3> _defaultPositions;
    private bool _isInitialisedPositions = false;

    private void Start()
    {
        InitialisePositions();
    }

    /// <summary>
    /// Require box collider at all objects
    /// </summary>
    public void SendObjectsFromScreen()
    {
        Debug.Log("send of screen");
        foreach (var item in _objectsToAnimate)
        {
            float leftScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, item.transform.position.y - Camera.main.transform.position.y)).x;
            float width = item.GetComponent<BoxCollider>().bounds.size.x;
            item.transform.position = new Vector3(leftScreenPoint - width, item.transform.position.y, item.transform.position.z);
        }
    }

    public void AnimateOut()
    {
        foreach (var item in _objectsToAnimate)
        {
            float rightScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, item.transform.position.y - Camera.main.transform.position.y)).x;
            float width = item.GetComponent<BoxCollider>().bounds.size.x;
            item.transform.DOMove(new Vector3(rightScreenPoint + width, item.transform.position.y, item.transform.position.z), _animationDurationOut).OnComplete(() => item.SetActive(false));
        }
    }

    public void AnimateIn()
    {
        InitialisePositions();
        SendObjectsFromScreen();
        Debug.Log("animate in");
        for (int i = 0; i < _objectsToAnimate.Count; i++)
        {
            _objectsToAnimate[i].SetActive(true);
            _objectsToAnimate[i].transform.DOMove(_defaultPositions[i], _animationDurationIn);
        }
    }

    private void InitialisePositions()
    {
        if (!_isInitialisedPositions)
        {
            _isInitialisedPositions = true;
            _defaultPositions = new List<Vector3>();
            _objectsToAnimate.ForEach(obj => _defaultPositions.Add(obj.transform.position));
        }
    }
}
