using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractibleObjectScript : MonoBehaviour
{
    [SerializeField]
    private GameObject intertactUI;
    public ContainerScript InteractRadius;
    public LayerMask wallLayer;
    private Vector2 position;
    private Vector3 playerPosition;
    private Vector2 Direction;
    public bool Discovered;

    private void Start()
    {
        Discovered = false;
        playerPosition = Vector2.zero;
        position = Vector2.zero;
    }

    public void WithinRange()
    {
        if (!Discovered)
        {
            playerPosition = GameObject.Find("Player").GetComponent<Transform>().position;
            position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Direction = (playerPosition - gameObject.transform.position).normalized;
            float dist = Vector2.Distance(gameObject.transform.position, playerPosition);
            if (!Physics2D.Raycast(gameObject.transform.position, Direction, dist, wallLayer))
            {
                Instantiate(intertactUI, gameObject.transform.position, Quaternion.identity);
                Discovered = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (Discovered) { Gizmos.color = Color.green; Gizmos.DrawRay(new Ray(position, new Vector3(Direction.x, Direction.y, 0))); }
        else if (!Discovered) { Gizmos.color = Color.red;  Gizmos.DrawRay(new Ray(position,new Vector3(Direction.x, Direction.y, 0))); }
    }
}
