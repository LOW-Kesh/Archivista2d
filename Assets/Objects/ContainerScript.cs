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

    public bool unopened;
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
        containerMenu = UIMenuManager.UiMenuManager.GetContainerMenu();
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
                    LootList = InstantiateContainerItems(lootAmount);
                }
                MoveListToMenu();
                StartCoroutine(ContToggle(true));
            }
            if (Input.GetKeyDown(KeyCode.E) && containerOpen)
            {
                containerMenu.gameObject.SetActive(false);
                StartCoroutine(ContToggle(false));
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactRange = false;
        containerOpen = false;
        containerMenu.gameObject.SetActive(false);
    }

    private IEnumerator ContToggle(bool toggle)
    {
        yield return null;
        containerOpen = toggle;
    }

    private void MoveListToMenu()
    {
        containerMenu.GetComponent<ContMenuManager>().SpawnItemsInCont(LootList);
        Debug.Log("Items Moved");
    }

    private GameObject[] InstantiateContainerItems(int spawnCount)
    {
        //will determine whats in the container using some other data as a source

        int j = 0;

        LootList = new GameObject[spawnCount];
        for (int i = 0; i < spawnCount; i++)
        {
            LootList[j] = LootTypeList[Random.Range(0, LootTypeList.Length)];
            j++;
        }
        return LootList;
    }
}
