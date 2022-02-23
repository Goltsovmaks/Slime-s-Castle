using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_v2 : MonoBehaviour
{
    public Slime_parameters slimeParameters;
    private ControllerManager controllerManager;

    public bool horizontalSlime = false;
    public bool verticalSlime = false;

    public Rigidbody2D rb;
    public Animator anim;

    public float checkRadiusGround = 0.17f;
    public LayerMask platforms;

    public Transform leftChecker;
    public Transform rightChecker;
    public Transform topChecker;
    public Transform bottomChecker;

    [SerializeField] private bool leftWall = false;
    [SerializeField] private bool rightWall = false;
    [SerializeField] private bool topWall = false;
    [SerializeField] private bool bottomWall = false;

    public float speed = 5.0F;
    public float jumpPower = 11.0F;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .01f;

    public Vector2 moveVectorSoft;
    public Vector3 targetVelocity;
    public Vector3 targetVelocity2;


    public bool stuckLeft = false; //������ � ����� �����
    public bool stuckRight = false; //������ � ������ �����
    public bool stuckTop = false; //������ � �������

    [SerializeField] private AudioSource jumping;

    public bool isJumping = false;
    public bool isTrueJumping = false;
    public bool canSpendStamina = true;

    public bool canStuck = false;

    public int moveMode = 2;
    public int jumpMode = 5;

    private float jumpTimeCounter;
    public float jumpTime;
    public float coeff;

    public BoxCollider2D box1;
    public BoxCollider2D box2;
    public BoxCollider2D box3;

    private float right = 0f;
    private float left = 0f;
    private float up = 0f;
    private float down = 0f;


    void Start()
    {
        controllerManager = GameObject.Find("ControllerManager").GetComponent<ControllerManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SlimeData.PointOfResurrect.Add(transform.position);
    }

    private void FixedUpdate()
    {
        fixedJump();
        fixedMove();
        if (stuckLeft || stuckRight || stuckTop)
        {
            slimeParameters.stamina -= slimeParameters.staminaStuckUsage;
        }
    }

    private void Update()
    {
        jump();
        move();
        wallChecker();
        
        setAnimation();
        
        anim.SetBool("onWall", false);
        anim.SetBool("onGround", false);
        stuckLeft = false;
        stuckRight = false;
        stuckTop = false;
        rb.gravityScale = 0.8f;

        if (slimeParameters.stamina <= slimeParameters.staminaStuckUsage)
        {
            canStuck = false;
        }


        if (Input.GetKey(controllerManager.controlls["Stuck"]) && leftWall && canStuck) //Input.GetKey(KeyCode.LeftShift)
        {
            rb.gravityScale = 0;
            stuckLeft = true;
            anim.SetBool("onWall", true);
        }
        if (bottomWall)
        {
            rb.gravityScale = 0.8f;
            anim.SetBool("onGround", true);
            canStuck = true;
        }
        if (Input.GetKey(controllerManager.controlls["Stuck"]) && rightWall && canStuck) //Input.GetKey(KeyCode.LeftShift)
        {
            rb.gravityScale = 0;
            stuckRight = true;
            anim.SetBool("onWall", true);
        }
        if (Input.GetKey(controllerManager.controlls["Stuck"]) && topWall && canStuck)
        {
            rb.gravityScale = 0;
            stuckTop = true;
            anim.SetBool("onGround", true);
        }

        if (bottomWall || topWall)
        {
            horizontalSlime = true;
        }
        else
        {
            horizontalSlime = false;
        }
        if (leftWall || rightWall)
        {
            verticalSlime = true;
        }
        else
        {
            verticalSlime = false;
        }


        if (horizontalSlime && verticalSlime)
        {
            anim.SetBool("onWall", true);
            if (topWall)
            {
                gameObject.GetComponent<SpriteRenderer>().flipY = true;
            }
            else if (bottomWall)
            {
                gameObject.GetComponent<SpriteRenderer>().flipY = false;
            }
            if (rightWall)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (leftWall)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

    }

    void wallChecker()
    {
        leftWall = false;
        Collider2D[] lColliders = Physics2D.OverlapCircleAll(leftChecker.position, checkRadiusGround, platforms);
        for (int i = 0; i < lColliders.Length; i++)
        {
            if (lColliders[i].gameObject != gameObject)
                leftWall = true;
        }
        rightWall = false;
        Collider2D[] rColliders = Physics2D.OverlapCircleAll(rightChecker.position, checkRadiusGround, platforms);
        for (int i = 0; i < rColliders.Length; i++)
        {
            if (rColliders[i].gameObject != gameObject)
                rightWall = true;
        }
        topWall = false;
        Collider2D[] tColliders = Physics2D.OverlapCircleAll(topChecker.position, checkRadiusGround, platforms);
        for (int i = 0; i < tColliders.Length; i++)
        {
            if (tColliders[i].gameObject != gameObject)
                topWall = true;
        }
        bottomWall = false;
        anim.SetBool("onGround", false);
        Collider2D[] bColliders = Physics2D.OverlapCircleAll(bottomChecker.position, checkRadiusGround, platforms); //+0.1f
        for (int i = 0; i < bColliders.Length; i++)
        {
            if (bColliders[i].gameObject != gameObject) 
            {
                bottomWall = true;
                anim.SetBool("onGround", true);
            }
                

        }

    }

    void fixedMove()
    {
        Vector3 moveVectorSoft2 = new Vector3();
        moveVectorSoft2.x = right + left;

        targetVelocity = new Vector3(moveVectorSoft2.x * speed * 10f, rb.velocity.y);
        Vector3 velocity = Vector3.zero;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
        anim.SetFloat("xMove", Mathf.Abs(rb.velocity.x));

        if (stuckLeft || stuckRight)
        {

            Vector3 moveVectorSoft3 = new Vector3();
            moveVectorSoft3.y = up + down;

            targetVelocity2 = new Vector3(rb.velocity.x, moveVectorSoft3.y * speed * 10f);
            Vector3 velocity2 = Vector3.zero;
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity2, ref velocity2, m_MovementSmoothing);
            anim.SetFloat("yMove", Mathf.Abs(rb.velocity.y));
            

        }

    }

    void move()
    {
       
        if (moveMode == 2)
        {
            right = 0;
            left = 0;

            if (Input.GetKey(controllerManager.controlls["Right"])) //Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)
            {
                right += 0.1f;
            }
            if (right >= 1f) 
            {
                right = 1f;
            }
            if (right <= 0f)
            {
                right = 0f;
            }
            if (Input.GetKey(controllerManager.controlls["Left"]))
            {
                right -= 0.1f;
            }
            if (left <= -1f)
            {
                left = -1f;
            }
            if (left >= 0f)
            {
                left = 0f;
            }

            

            if ((horizontalSlime) && !(verticalSlime))
            {
                if (rb.velocity.x < -1)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
            if (topWall)
            {
                gameObject.GetComponent<SpriteRenderer>().flipY = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipY = false;
            }



            //================================/

            if (stuckLeft || stuckRight) 
            {
                up = 0;
                down = 0;

                if (Input.GetKey(controllerManager.controlls["Up"]))
                {
                    up += 0.1f;
                }
                if (up >= 1f)
                {
                    up = 1f;
                }
                if (up <= 0f)
                {
                    up = 0f;
                }
                if (Input.GetKey(controllerManager.controlls["Down"]))
                {
                    down -= 0.1f;
                }
                if (down <= -1f)
                {
                    down = -1f;
                }
                if (down >= 0f)
                {
                    down = 0f;
                }


                //Vector3 moveVectorSoft3 = new Vector3();
                //moveVectorSoft3.y = up + down;

                //targetVelocity2 = new Vector3(rb.velocity.x, moveVectorSoft3.y * speed * 10f);
                //Vector3 velocity2 = Vector3.zero;
                //rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity2, ref velocity2, m_MovementSmoothing);
                //anim.SetFloat("yMove", Mathf.Abs(rb.velocity.y));

            

                if ((verticalSlime) && !(horizontalSlime))
                {
                    if (rb.velocity.y > 1)
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipY = true;
                    }
                    else
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipY = false;
                    }

                    if (rightWall)
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    else
                    {
                        gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    }


                }



            }
        }


    }

    void fixedJump()
    {
        if (isTrueJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveVectorSoft.y + jumpPower / 2);
            //if (canSpendStamina)
            //{
            //    Debug.Log("hey");
            //    canSpendStamina = false;
            //    slimeParameters.stamina -= slimeParameters.staminaJumpUsage;
            //}
        }
        if (isJumping)
        {
            //canSpendStamina = true;
            rb.velocity = new Vector2(rb.velocity.x, moveVectorSoft.y + 11f / 1.7f);
        }

        
    }

    void jump()
    {

        if ((Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && bottomWall && slimeParameters.stamina >= slimeParameters.staminaJumpUsage)
        {
            //slimeParameters.stamina -= slimeParameters.staminaJumpUsage;
        }

        if (Input.GetKey(controllerManager.controlls["Jump"]) && bottomWall && slimeParameters.stamina >= slimeParameters.staminaJumpUsage)
        {
            if (canSpendStamina)
            {
                canSpendStamina = false;
                slimeParameters.stamina -= slimeParameters.staminaJumpUsage;
            }
            isTrueJumping = true;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            //rb.velocity = new Vector2(rb.velocity.x, moveVectorSoft.y + jumpPower / 2);
            jumping.Play();
        }
        else
        {
            isTrueJumping = false;
        }
        if (Input.GetKey(controllerManager.controlls["Jump"]) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                //rb.velocity = new Vector2(rb.velocity.x, moveVectorSoft.y + 11f / 1.7f);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
                canSpendStamina = true;
            }
        }
        if (Input.GetKeyUp(controllerManager.controlls["Jump"]))
        {
            isJumping = false;
            canSpendStamina = true;
        }
            

    }


    void setAnimation()
    {
        if ((leftWall || rightWall) && (topWall || bottomWall))
        {
            box1.enabled = false;
            box2.enabled = false;
            box3.enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        else if (bottomWall || topWall)
        {

            //gameObject.GetComponent<BoxCollider2D>().enabled = true;
            box1.enabled = true;
            box2.enabled = false;
            box3.enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        else if (stuckLeft || stuckRight)
        {
            //gameObject.GetComponent<BoxCollider2D>().enabled = true;
            box1.enabled = false;
            box2.enabled = true;
            box3.enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        else
        {
            //gameObject.GetComponent<BoxCollider2D>().enabled = false;
            box1.enabled = false;
            box2.enabled = false;
            box3.enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }


    }

   
}
