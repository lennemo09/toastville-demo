using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string currentAreaName;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player's current area: " + PlayerController.instance.currentAreaName);
        Debug.Log("Entrance current area:" + currentAreaName);

        if (currentAreaName == PlayerController.instance.currentAreaName)
        {
            Debug.Log("Moving player to: " + transform.position);
            PlayerController.instance.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
