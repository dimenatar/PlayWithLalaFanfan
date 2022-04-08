using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItem : MonoBehaviour
{
    public Item Type { get; set; }

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = true;
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(0, -1.5f, 0);
    }
}
