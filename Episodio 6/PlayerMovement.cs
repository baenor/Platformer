using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    Rigidbody2D body;
    Animator anim;

    //Variabili upgradabili 
    [SerializeField]
    float moveSpeed = 3f;
    [SerializeField]
    float jumpForce = 1.4f;

    bool isJumping = false;


    public float length = 0.2f;
    public LayerMask mappa;

    public int maxJumps = 2;
    int jumps = 0;

    bool isGrounded = false;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckGrounded();
        Movement();
        Jumping();
	}

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(Vector2.right.x * moveSpeed * h, body.velocity.y);

        body.velocity = velocity;

        if(velocity.x < 0)
        {
            body.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(velocity.x > 0)
        {
            body.transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("IsMoving", Mathf.Abs(h));
    }

    void CheckGrounded()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, length, mappa))
        {
            //Sono sul terreno. Lo sto calpestando
            isGrounded = true;
            jumps = 0; 
            anim.SetBool("isJumping", false);
        }
        else
        {
            //Sto volando, saltando, sto cadendo...
            isGrounded = false;
        }
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumps++;
                anim.SetBool("isJumping", true);
            }
            else
            {
                if(jumps < maxJumps)
                {
                    body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    jumps++;
                    anim.SetBool("isJumping", true);

                }
            }
        }

    }
}
