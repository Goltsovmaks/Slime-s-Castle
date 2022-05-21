using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_guard : MonoBehaviour
{
    private Rigidbody2D rb;
     [SerializeField]private bool movingRight;

    private GameObject player;

    [SerializeField][Range(0, 5f)]private float speed;
    [SerializeField][Range(0, 30f)]private float patrolDistance;
    [SerializeField][Range(0, 30f)]private float attackDistance;

    [SerializeField]private GameObject startPositionObject;
    [SerializeField]private Vector3 startPosition;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Slime");
        startPosition = startPositionObject.transform.position;
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(Vector2.Distance(transform.position, startPosition) < patrolDistance){
            Patrol();
        }
    }

    private void Attack(){ 


    }

    private void Patrol(){
        if(transform.position.x > startPosition.x + patrolDistance){
            movingRight = false;
        } else if(transform.position.x < startPosition.x - patrolDistance){
            movingRight = true;
        }

        if(movingRight){
            transform.position = new Vector2(transform.position.x + speed*Time.fixedDeltaTime,transform.position.y);
        }else{
            transform.position = new Vector2(transform.position.x - speed*Time.fixedDeltaTime,transform.position.y);
        }
        
    }

    private void GoBack(){
        
    }
}
