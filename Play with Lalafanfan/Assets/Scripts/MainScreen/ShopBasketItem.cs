using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBasketItem : MonoBehaviour
{
    private Vector3 _destination;
    private float _flyHeight;
    private float _animation;
    private float _multiplier;
    private bool _isEnoughSpaceForItem;

    public void Initialise(Vector3 destination, float flyHeight, bool isEnoughSpaceForItem)
    {
        _destination = destination;
        _flyHeight = flyHeight;
        _isEnoughSpaceForItem = isEnoughSpaceForItem;
        StartCoroutine(nameof(MoveItemToBasket));
    }

    private IEnumerator MoveItemToBasket()
    {
        while (true)
        {
            _multiplier += Time.deltaTime * 1.5f;
            _animation += Time.deltaTime;
            _animation %= 4f;
            transform.position = MathParabola.Parabola(transform.position, _destination, _flyHeight, _animation * _multiplier);
            if (Mathf.Abs(transform.position.y - _destination.y) <= 0.3f)
            {
                StopCoroutine(nameof(MoveItemToBasket));
                if (!_isEnoughSpaceForItem)
                {
                    Destroy(gameObject);
                }
            }
            //Debug.Log(Mathf.Abs(transform.position.y - _destination.y) + " расстояние");

            yield return new WaitForEndOfFrame();
        }
    }
}
