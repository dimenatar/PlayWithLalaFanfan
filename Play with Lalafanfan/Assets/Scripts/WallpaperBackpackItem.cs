using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class WallpaperBackpackItem : MonoBehaviour
{
    public delegate void ItemClick(WallpaperData _data);
    public event ItemClick OnItemClick;

    private WallpaperData _data;

    public void Initialise(WallpaperData data)
    {
        _data = data;
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        OnItemClick.Invoke(_data);
    }
}
