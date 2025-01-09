using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ContMenuManager : MonoBehaviour
{
    public static ContMenuManager contMenuManager;
    [SerializeField]
    private GameObject viewContent;

    public void SpawnItemsInCont(GameObject[] spawnList)
    {
        GameObject[] removieitems = GameObject.FindGameObjectsWithTag("MenuItem");
        foreach (GameObject item in removieitems)
        {
            Destroy(item);
        }
        foreach (GameObject item in spawnList)
        {
            Instantiate(item, viewContent.transform.position, Quaternion.identity, viewContent.transform);
        }
    }

}
