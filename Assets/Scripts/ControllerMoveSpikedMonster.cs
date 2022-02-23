using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMoveSpikedMonster : MonoBehaviour
{
    public Transform slime;

    public float speed = 2.0F;
    private bool faceRight = true;

    public Vector2 moveVector;
    public Rigidbody2D RigidBody;
    public Animator Anim;

    public float checkRadiusGround = 0.2f;
    public LayerMask Platforms;

    public bool Left;
    public Transform LeftCheck;

    public bool Right;
    public Transform RightCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckingLeft();
        CheckingRight();
        Reflect();
        MoveToSlime();
        
    }
    void MoveToSlime(){
        if(Mathf.Pow(transform.position.x-slime.transform.position.x,2)+Mathf.Pow(transform.position.y-slime.transform.position.y,2)<9){
            Anim.SetBool("Staying", false);
            Anim.SetBool("Moving", true);
            
                if(transform.position.x>slime.transform.position.x){
                    moveVector=new Vector2(-speed,0);
                }
                else {
                    moveVector=new Vector2(speed,0);
                }
            
            // else{
            //     moveVector=new Vector2(0,0);
            // }
        } else{
            Anim.SetBool("Staying", true);
            Anim.SetBool("Moving", false);
            moveVector=new Vector2(0,0);
        }



        RigidBody.velocity = new Vector2(moveVector.x, moveVector.y);

        // transform.Translate(moveVector*speed*Time.deltaTime);
    }

    void Reflect()
    {
            if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
            {
                transform.localScale *= new Vector2(-1, 1);

                faceRight = !faceRight;

            }

    }

    void CheckingLeft()
    {
        if(faceRight){
            Left = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
        }
        if(!faceRight){
            Left = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
        }
        
  

    }

    void CheckingRight()
    {
        if(faceRight){
            Right = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
        }
        if(!faceRight){
            Right = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);
        }

        // if (transform.eulerAngles.z == 0 && transform.localScale.x == 1)
        // {
        //     Right = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);

        // }
      
    }


}
