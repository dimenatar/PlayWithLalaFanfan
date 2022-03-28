using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AppearanceBackpackItem : MonoBehaviour
{
    public delegate void ItemClick(AppereanceData _data);
    public event ItemClick OnItemClick;

    private AppereanceData _data;

    public void Initialise(AppereanceData data)
    {
        _data = data;
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        OnItemClick.Invoke(_data);
    }
}
