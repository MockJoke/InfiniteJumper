using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float[] jumpForces = { 10f, 20f};
    [HideInInspector] public int jumpCount;
    [HideInInspector] public int lifeCount = 2;

    private Rigidbody2D playerRb;
    private Collider2D playerCollider;

    private Animator animator;

    //private Button jumpButton;
    //private Button doubleJumpButton; 

    public Button[] jumpButtons = new Button[2];

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundDetector;
    [SerializeField] private float groundCheckRadius; 

    [SerializeField] public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
 
        for(int i = 0; i < 2; i++)
        {
            jumpButtons[0] = GameObject.Find("JumpButton").GetComponent<Button>();
            jumpButtons[1] = GameObject.Find("DoubleJumpButton").GetComponent<Button>(); 
        }

        AddButtons();           
    }

    void Update()
    {
        playerRb.velocity = new Vector2(moveSpeed, playerRb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundDetector.position, groundCheckRadius, whatIsGround); 

        animator.SetFloat("speed", playerRb.velocity.x);
        animator.SetBool("isGrounded", isGrounded);
    }

    void AddButtons()
    {
        for(int i = 0;i < jumpButtons.Length;i++)
        {
            AddButtonListeners(jumpButtons[i], i); 
        }
    }
    void AddButtonListeners(Button button, int index) 
    {
        button.onClick.AddListener(() => Jump(jumpForces[index])); 
    }

    void Jump(float jumpForce)
    {
        if(isGrounded)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            isJumping = true;
        }    
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(isJumping && collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            jumpCount += 2; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Water")
        {
            gameManager.RestartGame();
            lifeCount--; 
        }
    }
}
