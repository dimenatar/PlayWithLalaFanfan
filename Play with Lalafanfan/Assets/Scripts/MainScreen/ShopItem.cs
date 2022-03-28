using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class ShopItem : MonoBehaviour
{
    public delegate void ItemClick(IResource resource);
    public event ItemClick OnItemClick;

    private IResource _resource;

    public void Initialise(IResource resource)
    {
        _resource = resource;
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        OnItemClick.Invoke(_resource);
    }
}
