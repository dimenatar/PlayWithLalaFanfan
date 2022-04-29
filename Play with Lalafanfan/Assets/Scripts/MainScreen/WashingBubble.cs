using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WashingBubble : MonoBehaviour
{
    public delegate void DisabledBubble(GameObject bubble);

    public event DisabledBubble OnDisabledBubble;

    private void Start()
    {

    }

    private void OnEnable()
    {
        transform.DOScale(transform.localScale * 2, 0.5f);
        Invoke(nameof(DisableBubble), 0.5f);
    }

    private void DisableBubble()
    {
        this.gameObject.SetActive(false);
        OnDisabledBubble?.Invoke(this.gameObject);
    }
}
