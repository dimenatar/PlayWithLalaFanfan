using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHealthView : MonoBehaviour
{
    [SerializeField] private DuckHealth _duckHealth;
    [SerializeField] private List<SpriteRenderer> _hearts;

    private int _heartIndex;

    private void Awake()
    {
        
    }


}
