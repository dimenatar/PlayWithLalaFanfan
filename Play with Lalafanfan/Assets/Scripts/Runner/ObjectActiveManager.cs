using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActiveManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsToDeactivate;
    [SerializeField] private List<GameObject> _objectsToActivate;

    public void Deactivate()
    {
        foreach (var item in _objectsToDeactivate)
        {
            item.SetActive(false);
        }
    }

    public void Activate()
    {
        foreach (var item in _objectsToActivate)
        {
            item.SetActive(true);
        }
    }
}
