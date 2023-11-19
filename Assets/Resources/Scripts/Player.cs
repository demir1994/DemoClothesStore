using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;
    public float moveSpeed = 5f;  

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 oldPos;

    [SerializeField]
    public List<SpriteRenderer> _playerSprites;

    public SpriteRenderer hoodCosmetic;
    public SpriteRenderer torsoCosmetic;
    public SpriteRenderer waistbandCosmetic;

    private void Awake()
    {
        player = this;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;
        float verticalInput = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector2(horizontalInput, verticalInput);

        //print(rb.velocity.magnitude);

        InitialMovement();

        if (Input.GetKeyUp(KeyCode.Tab)){
            GameManager.instance.inventory.SetActive(true);
        }
    }

    public void Clothes_UpdateHood(Sprite hood)
    {
        hoodCosmetic.sprite = hood;
    }
    public void Clothes_UpdateTorso(Sprite torso)
    {
        torsoCosmetic.sprite = torso;
    }
    public void Clothes_UpdateWaistband(Sprite waistband)
    {
        waistbandCosmetic.sprite = waistband;
    }

    /// <summary>
    /// Movement with animator setting
    /// </summary>
    private void InitialMovement()
    {

        // Movement components
        oldPos = rb.velocity;
        if (oldPos.x > 0)
        {
            // facing right
            foreach (SpriteRenderer sprites in _playerSprites)
            {
                sprites.flipX = false;
            }
        }
        else if (oldPos.x < 0)
        {
            // facing left
            foreach (SpriteRenderer sprites in _playerSprites)
            {
                sprites.flipX = true;
            }
        }

        oldPos = transform.position;

        // Animators components
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // running
            moveSpeed = 2.2f;
            animator.SetBool("run", true);
            animator.SetBool("walk", false);
            animator.SetBool("idle", false);
        } else
        {
            moveSpeed = 1.5f;
            animator.SetBool("run", false);
        }

        
        if (rb.velocity.magnitude > 0.1f && moveSpeed < 2f)
        {
            // walking
            animator.SetBool("walk", true);
            animator.SetBool("idle", false);

        } else if (rb.velocity.magnitude <= 0)
        {
            // idle
            animator.SetBool("walk", false);
            animator.SetBool("idle", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shop")
        {
            GameManager.instance.ShopEnter(true);
            print("Shop");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Shop")
        {
            GameManager.instance.ShopEnter(false);
            print("ShopExit");
        }
    }
}

