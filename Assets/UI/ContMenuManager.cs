using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ContMenuManager : MonoBehaviour
{
    public static ContMenuManager contMenuManager;
    [SerializeField]
    private GameObject viewContent;

    private GameObject[] oldItems = new GameObject[0];

    public void SpawnItemsInCont(GameObject[] spawnList)
    {
        //remove stufff already in menu

        //this is a better solution but i cant get it to work
        /*if (oldItems.Length > 0)
        {
            foreach (GameObject item in oldItems)
            {
                item.SetActive(false);
            }
            Debug.Log(oldItems.Length);
            oldItems = new GameObject[0];
        }*/

        oldItems = GameObject.FindGameObjectsWithTag("MenuItem");
        foreach (GameObject item in oldItems)
        {
            Destroy(item);
        }

        oldItems = new GameObject[spawnList.Length];
        //create new selection
        //int i = 0;
        foreach (GameObject item in spawnList)
        {
            Instantiate(item, viewContent.transform.position, Quaternion.identity, viewContent.transform);
            
            //oldItems[i] = item;
            //i++;
        }
        spawnList = new GameObject[0];
    }

}
