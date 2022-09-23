using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMoveSpikedMonster : MonoBehaviour
{
    private Transform slime;

    [SerializeField][Range(0, 5f)]private float speed = 2.0F;
    [SerializeField][Range(0, 25f)]private float attackDistance = 3.0F;

    [SerializeField]private Vector2 moveVector;
    private bool moveRight;

    private Rigidbody2D RigidBody;
    private Animator Anim;

    private float checkRadiusGround = 0.2f;
    [SerializeField]private LayerMask Platforms;

    [SerializeField]private bool Left;
    [SerializeField]private Transform LeftCheck;

    [SerializeField]private bool Right;
    [SerializeField]private Transform RightCheck;

    private void Awake() {

        slime = GameObject.Find("Slime").transform;
        RigidBody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

    }

    void Start()
    {
        
    }
    private void Update() {
        CheckingLeft();
        CheckingRight();
    }

    void FixedUpdate()
    {
        
        MoveToSlime();
        
    }
    void MoveToSlime(){
        
        if(Vector2.Distance(transform.position,slime.transform.position)<attackDistance){
            Anim.SetBool("Staying", false);
            Anim.SetBool("Moving", true);
               
                if(transform.position.x>slime.transform.position.x){
                    moveRight=false;
                    moveVector=new Vector2(-speed,0);
                }
                else {
                    moveRight=true;
                    moveVector=new Vector2(speed,0);
                }
    
        } else{
            Anim.SetBool("Staying", true);
            Anim.SetBool("Moving", false);
            moveVector=new Vector2(0,RigidBody.velocity.y);
        }

        if(moveVector.x>0&&!Right){
            moveVector=new Vector2(0,RigidBody.velocity.y);
        }
        if(moveVector.x<0&&!Left){
            moveVector=new Vector2(0,RigidBody.velocity.y);
        }


        RigidBody.velocity = moveVector;

        // transform.Translate(moveVector*speed*Time.deltaTime);
    }

    void CheckingLeft()
    {
        Left = Physics2D.OverlapCircle(LeftCheck.position, checkRadiusGround, Platforms);       
    }

    void CheckingRight()
    {
        Right = Physics2D.OverlapCircle(RightCheck.position, checkRadiusGround, Platforms);
    }
  
}
