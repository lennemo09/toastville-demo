using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string areaToLoad;
    public string currentAreaName;
    public string destinationAreaName;
    public AreaEntrance entrance;

    // Start is called before the first frame update
    void Start()
    {
        entrance.currentAreaName = currentAreaName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D enterer)
    {
        if (enterer.tag == "Player")
        {
            Debug.Log("Player exited area " + currentAreaName + " to " + destinationAreaName);
            PlayerController.instance.currentAreaName = destinationAreaName;
            SceneManager.LoadScene(areaToLoad);
        }
    }
}
