using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FoodBackpackItem : MonoBehaviour
{
    public delegate void ItemClick(FoodData _data);
    public event ItemClick OnItemClick;

    private FoodData _data;

    public void Initialise(FoodData data)
    {
        _data = data;
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        OnItemClick.Invoke(_data);
    }
}
