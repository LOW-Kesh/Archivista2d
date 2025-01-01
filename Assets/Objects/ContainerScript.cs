using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    public CircleCollider2D interactRadiusCollider;
    public bool containerOpen;
    public GameObject[] LootTypeList;
    private GameObject[] LootList;

    [SerializeField]
    private GameObject containerMenu;

    public int lootAmountMin;
    public int lootAmountMax;
    private int lootAmount;

    private bool unopened;
    private bool interactRange;
    //public SpriteRenderer interactIcon;


    private void Start()
    {
        containerOpen = false;
        unopened = true;
        lootAmount = Random.Range(lootAmountMin, lootAmountMax);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactRange = true;
        containerOpen = false;
        containerMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (interactRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && !containerOpen)
            {
                containerMenu.gameObject.SetActive(true);

                if (unopened)
                {
                    unopened = false;
                    InstantiateContainerItems(lootAmount);
                    Debug.Log("Loot instantiated for container " + gameObject.name);
                }
                MoveListToMenu();
                StartCoroutine(ContToggle(true));
            }
            if (Input.GetKeyDown(KeyCode.E) && containerOpen)
            {
                containerMenu.gameObject.SetActive(false);
                MoveListToMenu();
                StartCoroutine(ContToggle(false));
            }
            
        }
    }

    private IEnumerator ContToggle(bool toggle)
    {
        yield return null;
        containerOpen = toggle;
    }

    private void MoveListToMenu()
    {
        ContMenuManager.contMenuManager.SpawnItemsInCont(LootList);
        Debug.Log("Items Moved");
    }

    private void InstantiateContainerItems(int spawnCount)
    {
        //will determine whats in the container using some other data as a source

        int j = 0;
        for (int i = 0; i < spawnCount; i++)
        {
            LootList = new GameObject[spawnCount];
            LootList[j] = LootTypeList[Random.Range(0, LootTypeList.Length)];
            j++;
        }
    }
}
