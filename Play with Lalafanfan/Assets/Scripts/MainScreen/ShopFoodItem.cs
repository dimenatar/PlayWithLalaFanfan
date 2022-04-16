using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class ShopFoodItem : MonoBehaviour
{
    public delegate void ItemClick(FoodData data, Vector3 position);
    public event ItemClick OnItemClick;

    private FoodData _data;

    public void Initialise(FoodData data)
    {
        _data = data;
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        Vector3 position = GetComponent<RectTransform>().transform.position;
        position = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 22));
        OnItemClick.Invoke(_data, position);
    }
}
