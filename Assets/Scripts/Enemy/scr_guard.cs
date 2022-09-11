using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_guard : MonoBehaviour, IImmobilizable, scr_IDamageable
{
    public int mobID;

    [SerializeField]private bool canTakeDamage = true;
    //[SerializeField]private int healthEnemy;
    [SerializeField][Range(0, 10f)]private float damageRate;
    private float nextDamage;
    
    [SerializeField][Range(0, 50f)]private float speed;
    [SerializeField][Range(0, 30f)]private float patrolDistance;
    [SerializeField]private bool aggressive;
    [SerializeField][Range(0, 30f)]private float attackDistance;

    [SerializeField]private bool debugging;


    private Rigidbody2D rb;
    private bool movingRight;
    [SerializeField]private bool patrol;
    [SerializeField]private bool attack;
    [SerializeField]private bool goBack;
    [SerializeField]private bool immobilized;

    
    

    private GameObject player;

    [SerializeField]private GameObject startPositionObject;
    [SerializeField]private Vector3 startPosition;

    private Vector2 velocityVector;


    //public int maxHealth { get; private set; }
    //public int currentHealth { get; private set; }

    public int maxHealth;
    public int currentHealth;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Slime");
        startPosition = startPositionObject.transform.position;
    }

    void Start()
    {
        //maxHealth=healthEnemy;
        currentHealth=maxHealth;
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
        if(!aggressive){
            return;
        }

        if(player.transform.position.x-transform.position.x>0){
            velocityVector = new Vector2(speed,0);
        }else{
            velocityVector = new Vector2(-speed,0);
        }
        
        rb.velocity = velocityVector;
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
        } else if(transform.position.x < startPosition.x - patrolDistance){
            movingRight = true;
            
            
        }

        if(movingRight){
            gameObject.transform.localScale = new Vector2(1,1);
            velocityVector = new Vector2(speed,0);
            
        }else{
            gameObject.transform.localScale = new Vector2(-1,1);
            velocityVector = new Vector2(-speed,0);

        }

        rb.velocity = velocityVector;
    }

    private void GoBack(){
        if(startPosition.x-transform.position.x>0){
            velocityVector = new Vector2(speed,0);
        }else{
            velocityVector = new Vector2(-speed,0);
        }

        rb.velocity = velocityVector;
    }

    public void Immobilize(){
        Debug.Log(this.gameObject+" заморожен");
        // // float timeImmobilize
        // this.immobilized=true;

        // this.rb.isKinematic = true;
        // // this.gameObject.
    }

    public void ApplyDamage(int damage){
        Debug.Log("currentHealth is " + currentHealth);
        Debug.Log("damage is " + damage);

        if (Time.time > nextDamage && canTakeDamage)
        {
            nextDamage = Time.time + damageRate;

            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                canTakeDamage = false;
                Die();
            }
            Debug.Log("currentHP is " + currentHealth);

        }
    }

    public void Die(){
        Debug.Log("помер");
        scr_EventSystem.instance.mobDeath.Invoke(mobID);
        Destroy(gameObject);
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     //Debug.Log("entering");
    //     if (collision.CompareTag("Player"))
    //     {
    //         collision.gameObject.GetComponent<scr_IDamageable>().ApplyDamage(damage);
    //         //if (Time.time > nextDamage)
    //         //{
    //         //    col.gameObject.GetComponent<scr_IDamageable>().ApplyDamage(1);
    //         //    nextDamage = Time.time + damageRate;
    //         //}
    //     }
    // }




    private void OnDrawGizmos() {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawWireCube(startPositionObject.transform.position, new Vector3(patrolDistance*2, 0.5f, 0));
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

}
