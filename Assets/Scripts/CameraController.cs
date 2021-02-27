using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Target for the camera to follow

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerController.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Set new Camera position (x,y,z) to (target's x, target's y, current z).
        // Can change current z to accomodate dynamic camera height e.g. fixed distance from player's Z.
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
