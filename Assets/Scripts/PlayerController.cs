using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playersRB;
    public Animator playerAnimator;

    public float moveSpeed;

    public static PlayerController instance;
    public string areaTransitionName;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        
        moveSpeed = 5f; // Default movespeed
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        playersRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        playerAnimator.SetFloat("moveX", playersRB.velocity.x);
        playerAnimator.SetFloat("moveY", playersRB.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            playerAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            playerAnimator.SetFloat("lastMoveY", 0f);
        }

        if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            playerAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            playerAnimator.SetFloat("lastMoveX", 0f);
        }
    }
}
