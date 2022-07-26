using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_guard : MonoBehaviour, IImmobilizable
{
    private Rigidbody2D rb;
    [SerializeField]private bool movingRight;
    [SerializeField]private bool patrol;
    [SerializeField]private bool attack;
    [SerializeField]private bool goBack;
    [SerializeField]private bool immobilized;

    private GameObject player;

    [SerializeField][Range(0, 5f)]private float speed;
    [SerializeField][Range(0, 30f)]private float patrolDistance;
    [SerializeField]private bool aggressive;
    [SerializeField][Range(0, 30f)]private float attackDistance;

    [SerializeField]private GameObject startPositionObject;
    [SerializeField]private Vector3 startPosition;

    [SerializeField]private bool debugging;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Slime");
        startPosition = startPositionObject.transform.position;
    }

    void Start()
    {

    }

    private void FixedUpdate() {
        if(debugging){
            startPositionObject.transform.position=startPosition;
        }
        // Прибавляем к patrolDistance 0.1 поскольку в fixedUpdate
        if(Vector2.Distance(transform.position, startPosition) < patrolDistance+0.1&&!attack){
            patrol=true;
            goBack=false; 
        }
        if(Vector2.Distance(transform.position, player.transform.position) < attackDistance){
            attack=true;            
            patrol=false;
            goBack=false;
        }
        if(Vector2.Distance(transform.position, player.transform.position) > attackDistance&&!patrol){
            goBack=true; 
            attack=false;                       
        }


        if(patrol){
            Patrol();
        }else if(attack){
            Attack();
        }else if(goBack){
            GoBack();
        }


    }

    private void Attack(){ 
        // rb.MovePosition(player.transform.position);
        if(!aggressive){
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position, speed*Time.fixedDeltaTime);
        if (transform.position.x > player.transform.position.x)
        {
            gameObject.transform.localScale = new Vector2(-1,1);
        }
        else 
        {
            gameObject.transform.localScale = new Vector2(1,1);
        }
    }

    private void Patrol(){
        if(transform.position.x > startPosition.x + patrolDistance){
            movingRight = false;
            // gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } else if(transform.position.x < startPosition.x - patrolDistance){
            movingRight = true;
            
            
        }

        if(movingRight){
            gameObject.transform.localScale = new Vector2(1,1);
            transform.position = new Vector2(transform.position.x + speed*Time.fixedDeltaTime,transform.position.y);
        }else{
            gameObject.transform.localScale = new Vector2(-1,1);
            transform.position = new Vector2(transform.position.x - speed*Time.fixedDeltaTime,transform.position.y);
        }
        
    }

    private void GoBack(){
        transform.position = Vector2.MoveTowards(transform.position,startPosition, speed*Time.fixedDeltaTime);
    }

    public void Immobilize(){
        Debug.Log(this.gameObject+" заморожен");
        // // float timeImmobilize
        // this.immobilized=true;

        // this.rb.isKinematic = true;
        // // this.gameObject.
    }




    private void OnDrawGizmos() {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawWireCube(startPositionObject.transform.position, new Vector3(patrolDistance*2, 0.5f, 0));
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

}
