using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTowardCursor : MonoBehaviour
{
    [SerializeField]
    private GameObject cursorPointer;

    void FixedUpdate()
    {
        //turn towards mouse
        Vector2 lookhere = cursorPointer.transform.position;
        Vector3 direction = lookhere - new Vector2(transform.position.x, transform.position.y);
        float Zrotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, Zrotation);
    }
}
