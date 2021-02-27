using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playersRB;
    public Animator playerAnimator;

    public float moveSpeed;

    public static PlayerController instance;
    public string previousAreaName;
    public string currentAreaName;

    private float inputX;
    private float inputY;
    
    // Start is called before the first frame update
    void Start()
    {
        // If player is not on map
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject); // More than 1 player object, remove extra
        }
        
        moveSpeed = 5f; // Default movespeed
        DontDestroyOnLoad(gameObject); // Avoid spawning multiple players when loading scenes.
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
    }

    // Update is called once every 1/60 sec (by Unity's default)
    void FixedUpdate()
    {
        // If player is moving in both axis -> Maintain velocity (movespeed/sqrt(2) in each direction).
        if (inputX * inputY != 0f)
        {
            playersRB.velocity = new Vector2(inputX / Mathf.Sqrt(2), inputY / Mathf.Sqrt(2)) * moveSpeed;
        } else
        {
            playersRB.velocity = new Vector2(inputX, inputY) * moveSpeed;
        }
        
        playerAnimator.SetFloat("moveX", playersRB.velocity.x);
        playerAnimator.SetFloat("moveY", playersRB.velocity.y);

        // Used for idle animation by storing the last direction player has moved in
        if (Input.GetAxisRaw("Horizontal") != 0f)
        {
            playerAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            playerAnimator.SetFloat("lastMoveY", 0f);
        }
        if (Input.GetAxisRaw("Vertical") != 0f)
        {
            playerAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            playerAnimator.SetFloat("lastMoveX", 0f);
        }
    }
}
