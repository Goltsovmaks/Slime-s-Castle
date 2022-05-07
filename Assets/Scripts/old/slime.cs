using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public float speed = 5.0F;
    public float PowerJump = 11.0F;

    public bool onGround;
    public Transform GroundCheck;

    public float checkRadiusGround = 0.1f;
    public LayerMask Platforms;


    public Rigidbody2D RigidBody;
    public Animator Anim;
    public Vector2 moveVector;
    public Vector2 moveVectorSoft;

    private bool faceRight = true;

    public bool stuckLeft = false; //Прилип к левой стене
    public bool stuckRight = false; //Прилип к правой стене
    public bool stuckTop = false; //прилип к потолку
    // Может ли слизень перевернуться, прилеплённым к стене
    public bool letRotZLeft=true;
    public bool letRotZRight = true;
    public bool letUnstuckTop=true;

    public bool letJump=true;

    public float RotZ = 0.0f;
    private int GScale=1;
    public int scaleY=1;

    // Переменные для правильной смены анимаций
    public bool moveFloor;

    [SerializeField]private AudioSource Jumping;



    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        // print(RigidBody);
        SlimeData.PointOfResurrect.Add(transform.position);

    }

    IEnumerator CoolDownRotZLeft(float CoolDownTime){
        yield return new WaitForSeconds(CoolDownTime);
        letRotZLeft=true;
    }
    IEnumerator CoolDownRotZRight(float CoolDownTime)
    {
        yield return new WaitForSeconds(CoolDownTime);
        letRotZRight = true;
    }
    IEnumerator CoolDownJump(float CoolDownTime)
    {
        yield return new WaitForSeconds(CoolDownTime);
        letJump = true;
    }
    IEnumerator CoolDownUnstuckTop(float CoolDownTime)
    {
        yield return new WaitForSeconds(CoolDownTime);
        letUnstuckTop = true;
    }


    void FixedUpdate()
    {



    }

    void Update()
    {


        CheckingOnGround();
        CheckingLeft();
        CheckingRight();
        CheckingTop();

        
        
        SlimeMove();
        Reflect();
        Jump();
        // print(transform.rotation.z);
        // print(stuckRight);
        // print(RigidBody.gravityScale);
        // CheckingOnGround();
        // CheckingLeft();
        // CheckingRight();
        // CheckingTop();
        // print(letRotZ);
        // print(Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms));
        // print(Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, Platforms));
    }


    void Reflect()
    {

        if (transform.localScale.y == 1 && transform.eulerAngles.z == 0)
        {
            if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
            {
                transform.localScale *= new Vector2(-1, 1);

                faceRight = !faceRight;

            }
        }


        if (transform.localScale.y == -1 && transform.eulerAngles.z == 0)
        {
            if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
            {
                transform.localScale *= new Vector2(-1, 1);

                faceRight = !faceRight;

            }
        }

        if (transform.eulerAngles.z == 90)
        {
            if ((moveVector.y > 0 && !faceRight) || (moveVector.y < 0 && faceRight))
            {
                transform.localScale *= new Vector2(-1, 1);

                faceRight = !faceRight;
            }

        }
        if (transform.eulerAngles.z == 270)
        {
            if ((moveVector.y > 0 && faceRight) || (moveVector.y < 0 && !faceRight))
            {
                transform.localScale *= new Vector2(-1, 1);

                faceRight = !faceRight;

            }
        }




    }

    public Vector2 FinalVectorValue;
    // Рабочий метод
    void SlimeMove()
    {

        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        moveVectorSoft.x=Input.GetAxis("Horizontal");
        moveVectorSoft.y = Input.GetAxis("Vertical");

        // moveVector.x = -1;
        // moveVectorSoft.x = -1;        
        // moveVector.y = 1;
        // moveVectorSoft.y = 1;

        // moveVector.y = -1;

        // moveVector.x=1;



        Anim.SetBool("onGround", onGround);
        Anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        Anim.SetFloat("moveY", Mathf.Abs(moveVector.y));

        if(onGround){
            if(letJump&&Anim.GetBool("Jump")){
            letJump=false;
            CoolDownJump(0.01f);
            }
            if(transform.eulerAngles.z !=0 && !stuckLeft&& !stuckRight){
                RotZ=0;
                Anim.SetBool("Corner", false);
            }
            Anim.SetBool("Jump", false);           

        } else if(!stuckRight&&!stuckLeft&&!stuckTop){
            Anim.SetBool("moveFloor", false);
            Anim.SetBool("stay", false);
            Anim.SetBool("Jump", true);         
            Anim.SetBool("Corner", false);
            RotZ=0;
            if(RigidBody.gravityScale !=1){
                GScale = 1;
            }
        }


        if(moveVector.x>0){
            if(Right||!letRotZRight){
                stuckRight =true;
                RigidBody.AddForce(new Vector2(6, 0), ForceMode2D.Force);
                if(RigidBody.gravityScale !=0){
                    GScale = 0;
                }

                FinalVectorValue.x = RigidBody.velocity.x/100;
                FinalVectorValue.y = moveVector.y*speed;

                if(transform.eulerAngles.z !=90){
                    RotZ=90;
                    // RigidBody.AddForce(new Vector2(-6, 0), ForceMode2D.Force);
                    letRotZRight =false;
                    StartCoroutine(CoolDownRotZRight(0.18f));
                    if(Anim.GetBool("moveFloor")){
                        if(onGround){
                            transform.position += new Vector3(0.12f, 0.11f, 0);
                        }
                        if(Top){
                            transform.position += new Vector3(0.12f, -0.11f, 0);
                        }
                    }
                    if(Anim.GetBool("stay")){
                        if (onGround)
                        {
                            transform.position += new Vector3(0.12f, 0.1f, 0);
                        }
                        if (Top)
                        {
                            transform.position += new Vector3(0.12f, -0.1f, 0);
                        }
                        
                    }

                    if(Anim.GetBool("Jump")){
                        transform.position += new Vector3(0.1f, 0, 0);
                    }

                }

                if(moveVector.y>0){
                    if(Top){
                        Anim.SetBool("moveFloor", false);
                        Anim.SetBool("stay", false);
                        Anim.SetBool("Jump", false);
                        if(!Anim.GetBool("Corner")&&moveVectorSoft.y>0.5&&moveVectorSoft.x>0.5){
                            Anim.SetBool("Corner", true);
                            transform.position += new Vector3(0, 0.05f, 0);
                        }
                    }
                    else{
                        Anim.SetBool("moveFloor", true);
                        Anim.SetBool("stay", false);
                        Anim.SetBool("Jump", false);
                        Anim.SetBool("Corner", false);
                    }

                }

                if(moveVector.y==0){
                    Anim.SetBool("moveFloor",false);
                    Anim.SetBool("stay", true);
                    Anim.SetBool("Jump", false);
                    Anim.SetBool("Corner", false);
                }

                if(moveVector.y<0){
                    if(onGround){
                        Anim.SetBool("moveFloor", false);
                        Anim.SetBool("stay", false);
                        Anim.SetBool("Jump", false);
                        if(!Anim.GetBool("Corner")&& moveVectorSoft.y<-0.5&& moveVectorSoft.x > 0.5){
                            Anim.SetBool("Corner", true);
                            transform.position += new Vector3(0, -0.05f, 0);
                        }
                        

                    }
                    else{
                        Anim.SetBool("moveFloor", true);
                        Anim.SetBool("stay", false);
                        Anim.SetBool("Jump", false);
                        Anim.SetBool("Corner", false);
                    }
                    
                }

                
            }
            else if(letRotZRight)
            {
                stuckRight =false;
                if(RigidBody.gravityScale !=1 &&!Top){
                    GScale = 1;
                }

                FinalVectorValue.x=moveVector.x*speed;
                FinalVectorValue.y=RigidBody.velocity.y;

                if(onGround||Top){
                    Anim.SetBool("moveFloor", true);
                    Anim.SetBool("stay", false);
                    Anim.SetBool("Corner", false);
                }
                if(!onGround&&!Top){
                    Anim.SetBool("moveFloor", false);
                    Anim.SetBool("stay", false);
                    Anim.SetBool("Jump", true);
                    Anim.SetBool("Corner", false);
                }

                if (transform.eulerAngles.z != 0)
                {
                    RotZ=0;
                }

                // moveVector.x * speed, RigidBody.velocity.y
            }
            
        }

        if(moveVector.x==0){
            FinalVectorValue.x=0;
            FinalVectorValue.y=RigidBody.velocity.y;
            stuckLeft=false;
            stuckRight=false;
            letRotZLeft=true;
            letRotZRight=true;
            if(RigidBody.gravityScale !=1 &&!stuckTop){
                GScale = 1;
            }

            if(onGround){
                Anim.SetBool("moveFloor", false);
                Anim.SetBool("stay", true);
                Anim.SetBool("Jump", false);
                Anim.SetBool("Corner", false);
            } else if(!stuckTop&&letJump){
                Anim.SetBool("moveFloor", false);
                Anim.SetBool("stay", false);
                Anim.SetBool("Jump", true);
                Anim.SetBool("Corner", false);
            }
        }

        if(moveVector.x<0){
            if(Left||!letRotZLeft){
                stuckLeft =true;
                RigidBody.AddForce(new Vector2(-6, 0), ForceMode2D.Force);
                if(RigidBody.gravityScale !=0){
                    GScale = 0;
                }

                FinalVectorValue.x = RigidBody.velocity.x/100;
                FinalVectorValue.y = moveVector.y*speed;

                if(transform.eulerAngles.z !=270){
                    RotZ=270;
                    // RigidBody.AddForce(new Vector2(-6, 0), ForceMode2D.Force);
                    letRotZLeft=false;
                    StartCoroutine(CoolDownRotZLeft(0.18f));
                    if(Anim.GetBool("moveFloor")){
                        if(onGround){
                            transform.position += new Vector3(-0.12f, 0.11f, 0);
                        }
                        if(Top){
                            transform.position += new Vector3(-0.12f, -0.11f, 0);
                        }
                    }
                    if(Anim.GetBool("stay")){
                        if (onGround)
                        {
                            transform.position += new Vector3(-0.12f, 0.11f, 0);
                        }
                        if (Top)
                        {
                            transform.position += new Vector3(-0.12f, -0.11f, 0);
                        }
                        
                    }

                    if(Anim.GetBool("Jump")){
                        transform.position += new Vector3(-0.1f, 0, 0);
                    }

                }

                if(moveVector.y>0){
                    if(Top){
                        Anim.SetBool("moveFloor", false);
                        Anim.SetBool("stay", false);
                        Anim.SetBool("Jump", false);
                        if(!Anim.GetBool("Corner")&&moveVectorSoft.y>0.5&&moveVectorSoft.x<-0.5){
                            Anim.SetBool("Corner", true);
                            transform.position += new Vector3(0, 0.05f, 0);
                        }
                    }
                    else{
                        Anim.SetBool("moveFloor", true);
                        Anim.SetBool("stay", false);
                        Anim.SetBool("Jump", false);
                        Anim.SetBool("Corner", false);
                    }

                }

                if(moveVector.y==0){
                    Anim.SetBool("moveFloor",false);
                    Anim.SetBool("stay", true);
                    Anim.SetBool("Jump", false);
                    Anim.SetBool("Corner", false);
                }

                if(moveVector.y<0){
                    if(onGround){
                        Anim.SetBool("moveFloor", false);
                        Anim.SetBool("stay", false);
                        Anim.SetBool("Jump", false);
                        if(!Anim.GetBool("Corner")&& moveVectorSoft.y<-0.5&& moveVectorSoft.x < -0.5){
                            Anim.SetBool("Corner", true);
                            transform.position += new Vector3(0, -0.05f, 0);
                        }
                        

                    }
                    else{
                        Anim.SetBool("moveFloor", true);
                        Anim.SetBool("stay", false);
                        Anim.SetBool("Jump", false);
                        Anim.SetBool("Corner", false);
                    }
                    
                }

                
            }
            else if(letRotZLeft)
            {
                stuckLeft =false;
                if(RigidBody.gravityScale !=1 &&!Top){
                    GScale = 1;
                }

                FinalVectorValue.x=moveVector.x*speed;
                FinalVectorValue.y=RigidBody.velocity.y;

                if(onGround||Top){
                    Anim.SetBool("moveFloor", true);
                    Anim.SetBool("stay", false);
                    Anim.SetBool("Corner", false);
                }
                if(!onGround&&!Top){
                    Anim.SetBool("moveFloor", false);
                    Anim.SetBool("stay", false);
                    Anim.SetBool("Jump", true);
                    Anim.SetBool("Corner", false);
                }

                if (transform.eulerAngles.z != 0)
                {
                    RotZ=0;
                }

                // moveVector.x * speed, RigidBody.velocity.y
            }
            
        } else{
            stuckLeft=false;
        }


        if(moveVector.y>0){
            if(!stuckLeft && !stuckRight){
                if((Top||!letUnstuckTop)){
                    if(letUnstuckTop&&!stuckTop){
                        letUnstuckTop = false;
                        StartCoroutine(CoolDownUnstuckTop(0.07f));

                    }
                    stuckTop =true;
                    
    
                    if(RigidBody.gravityScale !=-1){
                        GScale = -1;
                    }

                    if(transform.localScale.y!=-1){
                        scaleY=-1;
                    }

                    FinalVectorValue.x = moveVector.x * speed;
                    FinalVectorValue.y = RigidBody.velocity.y;



                    if (transform.eulerAngles.z != 0)
                    {
                        RotZ = 0;
                        // print(Anim.GetBool("Jump"));
                        // if (Anim.GetBool("moveFloor"))
                        // {
                        //     if (Left)
                        //     {
                        //         // transform.position += new Vector3(-0.12f, 0.11f, 0);
                        //         transform.position += new Vector3(0.12f, 0f, 0);
                        //         }
                        //     if (Right)
                        //     {
                        //         transform.position += new Vector3(-0.12f, 0f, 0);
                        //     }
                        // }
                        // if (Anim.GetBool("stay"))
                        //     {
                        //     if (Left)
                        //     {
                        //         transform.position += new Vector3(0.12f, 0.11f, 0);
                        //     }
                        //     if (Right)
                        //     {
                        //         transform.position += new Vector3(-0.12f, 0.11f, 0);
                        //     }

                        // }

                        // if (Anim.GetBool("Jump"))
                        // {
                        //     transform.position += new Vector3(0, 0.1f, 0);
                        // }
                        // if (Anim.GetBool("Corner"))
                        // {   if(Left){
                        //         transform.position += new Vector3(0.12f, 0.0f, 0);
                        //     }
                        //     if(Right){
                        //         transform.position += new Vector3(-0.12f, 0.0f, 0);
                        //     }
                        //     // transform.position += new Vector3(0.12f, 0.12f, 0);
                        // }

                    }

                        // if()

                    if(moveVector.x>0){
                        Anim.SetBool("moveFloor", true);
                        Anim.SetBool("stay", false);
                        Anim.SetBool("Jump", false);
                        Anim.SetBool("Corner", false);
                    }

                    if(moveVector.x==0){
                        Anim.SetBool("moveFloor", false);
                        Anim.SetBool("stay", true);
                        Anim.SetBool("Jump", false);
                        Anim.SetBool("Corner", false);
                    }

                    if(moveVector.x<0){
                        Anim.SetBool("moveFloor", true);
                        Anim.SetBool("stay", false);
                        Anim.SetBool("Jump", false);
                        Anim.SetBool("Corner", false);
                    }

                } else {
                    stuckTop=false;
                    letUnstuckTop=true;

                    if (RigidBody.gravityScale != 1)
                    {
                        GScale = 1;
                    }

                    if (transform.localScale.y != 1)
                    {
                        scaleY = 1;
                    }

                    // FinalVectorValue.x = moveVector.x * speed;
                    // FinalVectorValue.y = RigidBody.velocity.y;
                    }
            } else{
                if(stuckTop!=false){
                    stuckTop=false;
                }
                if (transform.localScale.y != 1)
                {
                    scaleY = 1;
                }
            }
        } else {
            if(stuckTop!=false){
                stuckTop=false;
            }
            if (transform.localScale.y != 1)
            {
                scaleY = 1;
            }
            
        }



        // RigidBody.AddForce(moveVector*speed);
        RigidBody.velocity = new Vector2(FinalVectorValue.x, FinalVectorValue.y);

        RigidBody.gravityScale=GScale;
        if(RotZ!=transform.eulerAngles.z){
            transform.rotation = Quaternion.Euler(0, 0, RotZ);
        }

        if(transform.localScale.y!=scaleY){
            transform.localScale=new Vector2(transform.localScale.x,scaleY);
        }

    }


    // Input.GetKeyDown(KeyCode.Space)
    void Jump()
    {
        // Anim.SetFloat("Jump", Input.GetAxis("Jump") );
        // if (!onGround && !stuckLeft && !stuckRight && !stuckTop)
        // {
        //     Anim.SetBool("Jump", true);
        // }
        // else
        // {
        //     Anim.SetBool("Jump", false);
        // }
        if (onGround&&!Anim.GetBool("Corner")&&!stuckLeft && !stuckRight)
        {
            if (Input.GetAxis("Jump") > 0)
            {
                RigidBody.velocity = new Vector2(moveVector.x, PowerJump);
                letJump=true;
                if(!stuckLeft&&!stuckRight){
                    Jumping.Play();
                }
            }
        }

        // if (onGround){


        //     if (Input.GetAxis("Jump") > 0 && !stuckLeft && !stuckRight && !stuckTop){
        //     RigidBody.velocity = new Vector2(moveVector.x, PowerJump);
        //     Anim.SetBool("stay",false);
        //     }
        //     // print(Input.GetKeyDown(KeyCode.Space));
        // }
        // else{
        //     // if();
        //     // transform.rotation = Quaternion.Euler (0,0,0);

        // }

    }


    public bool Left;
    public Transform LeftCheck;

    public bool Right;
    public Transform RightCheck;

    public bool Top;
    public Transform TopCheck;

    void CheckingOnGround()
    {
        // onGround = Physics2D.OverlapArea(GroundCheckXY, GroundCheckAB, Platforms);
        if (transform.eulerAngles.z == 0 && transform.localScale.y == 1)
        {
            onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 0 && transform.localScale.y == -1)
        {
            onGround = Physics2D.OverlapCircle(TopCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 90 && transform.localScale.x == 1)
        {
            onGround = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 90 && transform.localScale.x == -1)
        {
            onGround = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 270 && transform.localScale.x == 1)
        {
            onGround = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 270 && transform.localScale.x == -1)
        {
            onGround = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
        }


        // onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, Platforms);
    }


    void CheckingLeft()
    {
        if (transform.eulerAngles.z == 0 && transform.localScale.x == 1)
        {
            Left = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 0 && transform.localScale.x == -1)
        {
            Left = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 90)
        {
            Left = Physics2D.OverlapCircle(TopCheck.position, checkRadiusGround, Platforms);
        }

        if (transform.eulerAngles.z == 270)
        {
            Left = Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, Platforms);
        }

    }


    void CheckingRight()
    {
        if (transform.eulerAngles.z == 0 && transform.localScale.x == 1)
        {
            Right = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);

        }
        if (transform.eulerAngles.z == 0 && transform.localScale.x == -1)
        {
            Right = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
        }

        if (transform.eulerAngles.z == 90)
        {
            Right = Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, Platforms);
        }

        if (transform.eulerAngles.z == 270)
        {
            Right = Physics2D.OverlapCircle(TopCheck.position, checkRadiusGround, Platforms);
        }
    }



    void CheckingTop()
    {
        if (transform.eulerAngles.z == 0 && transform.localScale.y == 1)
        {
            Top = Physics2D.OverlapCircle(TopCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 0 && transform.localScale.y == -1)
        {
            Top = Physics2D.OverlapCircle(GroundCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 90 && transform.localScale.x == 1)
        {
            Top = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 90 && transform.localScale.x == -1)
        {
            Top = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 270 && transform.localScale.x == 1)
        {
            Top = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
        }
        if (transform.eulerAngles.z == 270 && transform.localScale.x == -1)
        {
            Top = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
        }
    }

}
