using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class attachCamera : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private Camera Playercamera;
    public float CameraSize;
    private void Start()
    {
        player =  GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        //follow player
        Vector3 playerPos;
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = playerPos;

        if (Input.GetKey(KeyCode.Tab))
        {
            Playercamera.orthographicSize = CameraSize + 2;
        }
        else
        {
            Playercamera.orthographicSize = CameraSize;
        }
    }

    private void Update()
    {
        
    }
}
