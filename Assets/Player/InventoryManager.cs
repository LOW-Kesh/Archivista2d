using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    GameObject InventoryMenu;
    private bool MenuOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !MenuOpen)
        {
            InventoryMenu.SetActive(true);
            MenuOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) &&  MenuOpen)
        {
            InventoryMenu.SetActive(false);
            MenuOpen = false;
        }
    }
}
