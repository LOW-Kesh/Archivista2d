using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    public CircleCollider2D interactRadiusCollider;
    public bool containerOpen;

    [SerializeField]
    private GameObject containerMenu;

    public int lootAmountMin;
    public int lootAmountMax;
    private int lootAmount;
    //public SpriteRenderer interactIcon;


    private void Start()
    {
        containerOpen = false;
        lootAmount = Random.Range(lootAmountMin, lootAmountMax);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && !containerOpen)
        {
            containerOpen = true;
            InstantiateContainerItems(lootAmount);

        }
        if (Input.GetKeyDown(KeyCode.E) && containerOpen)
        {
            containerOpen = false;
        }
    }

    private void InstantiateContainerItems(int spawnCount)
    {
        //will determine whats in the container using some other data as a source
        

    }
}
