using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObjectScript : MonoBehaviour
{
    [SerializeField]
    private GameObject intertactUI;

    
    public void WithinRange()
    {
        Instantiate(intertactUI, gameObject.transform.position, Quaternion.identity);
    }

    void FixedUpdate()
    {
        
    }
}
