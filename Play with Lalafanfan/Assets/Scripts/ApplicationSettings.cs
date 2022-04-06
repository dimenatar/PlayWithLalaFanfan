using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationSettings : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Update()
    {
        //Debug.Log(1.0f / Time.deltaTime);
    }
}
