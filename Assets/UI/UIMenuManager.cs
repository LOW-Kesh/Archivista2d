using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject containerMenu;
    public static UIMenuManager UiMenuManager;

    private void Start()
    {
        UiMenuManager = this;
    }
    public GameObject GetContainerMenu()
    {
        return containerMenu;
    }
}
