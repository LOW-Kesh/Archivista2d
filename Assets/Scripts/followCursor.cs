using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCursor : MonoBehaviour
{
    private void FixedUpdate()
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
