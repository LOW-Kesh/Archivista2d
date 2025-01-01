using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContMenuManager : MonoBehaviour
{
    static public ContMenuManager contMenuManager;
    [SerializeField]
    private GameObject viewContent;

    public void SpawnItemsInCont(GameObject[] spawnList)
    {
        foreach (GameObject item in spawnList)
        {
            Instantiate(item, viewContent.transform.position, Quaternion.identity, viewContent.transform);
        }
    }
}
