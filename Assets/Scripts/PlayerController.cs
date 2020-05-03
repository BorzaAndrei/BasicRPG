using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float moveSpeed;

    public Animator animator;

    public static PlayerController instance;

    public string areaTransitionName;

    private Vector3 bottomLeft;
    private Vector3 topRight;

    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
            
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {
            playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

            animator.SetFloat("moveX", playerRB.velocity.x);
            animator.SetFloat("moveY", playerRB.velocity.y);

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeft.x, topRight.x), Mathf.Clamp(transform.position.y, bottomLeft.y, topRight.y), transform.position.z);

        }
        else
        {
            playerRB.velocity = Vector2.zero;
        }
    }

    public void SetBounds(Vector3 bottomL, Vector3 topR)
    {
        bottomLeft = bottomL + new Vector3(0.5f, 1f, 0f);
        topRight = topR + new Vector3(-0.5f, -1f, 0f);
    }
}
