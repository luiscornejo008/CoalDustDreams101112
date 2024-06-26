using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Move : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float shiftSpeed = 5.4f;
    public float shiftJump = 20.4f;
    public int superJump = 0;
    public int health = 5;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;
    public GameObject pickaxe;
    public int score;
    public int diamonds;
    public int gold;
    public int iron;
    public GameObject dopey;
    

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;
    public void getIron(int money)
    {
        iron = iron + money;
        Debug.Log("you have " + iron + " iron.");
    }

    public void getGold(int money)
    {
        gold = gold + money;
        Debug.Log("you have " + gold + " gold.");
    }

    public void getDiamonds(int money)
    {
        diamonds = diamonds + money;
        Debug.Log("you have " + diamonds + " diamonds.");
    }

    public void getHit()
    {
        health = health - 1;
        Debug.Log("health is at " + health + "/10");
    }

    // Use this for initialization
    void Start()
    {
        score = 0;
        health = 5;
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        
        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }
    public void addScore(int s)
    {
        score = score + s;
    }
    public int returnScore()
    {
        return score;
    }
    // Update is called once per frame
    void Update()
    {
        //pickaxe equip/unequip
        


        // Movement controls
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else
        {
            if (isGrounded || r2d.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
            }
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Jumping
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(checkSuper() > 0)
            {
                r2d.velocity = new Vector2(r2d.velocity.x, shiftJump);
                hasSuperd();
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && (isGrounded == true))
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }


        // Camera follow
      //  if (mainCamera)
     //   {
     //       mainCamera.transform.position = new Vector3(t.position.x, t.position.y, cameraPos.z);
      //  }
    }
    public void getSuper()
    {
        superJump = superJump + 1;
    }

    

    public void hasSuperd()
    {
        superJump = superJump - 1;
    }

    public int checkSuper()
    {
        return superJump;
    }

    public int checkHealth()
    {
        return health;
    }

    public int checkDiamonds()
    {
        return diamonds;
    }

    public int checkGold()
    {
        return gold;
    }

    public int checkIron()
    {
        return iron;
    }

    public void getHit(int num)
    {
        health = health - num;
        Debug.Log("Health: " + checkHealth());
    }


    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);

        if(checkHealth() < 1)
        {
            dopey.SetActive(false);
        }
    }
}