using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToFullWidth : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = new Vector3((float)(Camera.main.orthographicSize * 2.0 * Screen.width / Screen.height), transform.localScale.y, transform.localScale.z);
    }
}
