using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;

public class InteratciveAuraScript : MonoBehaviour
{
    public int holdSec;
    public float ObsSpeed;
    public LayerMask wallLayer;

    [SerializeField]
    private CircleCollider2D interactRadius;

    private float Orgradius;

    private void Start()
    {
        Orgradius = interactRadius.radius;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            interactRadius.radius += ObsSpeed;
        }
        else
        {
            interactRadius.radius = Orgradius;
        }
    }
    IEnumerator ProccessingTime(int holdSec)
    {
        yield return new WaitForSeconds(holdSec);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interactable")
        {
            //LayerMask layerMask = LayerMask.
            Vector2 direction = new Vector2(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y);
            if (!Physics2D.Raycast(gameObject.transform.position, direction, interactRadius.radius, wallLayer))
            {
                collision.gameObject.GetComponent<InteractibleObjectScript>().WithinRange();
            }
        }
    }
}
