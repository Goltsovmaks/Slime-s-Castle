using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_movingPlatform : MonoBehaviour
{
    [SerializeField][Range(0, 30f)]private float speed;
    [Header("|")]
    [SerializeField]private bool movingHorizontal;
    [SerializeField][Range(0, 30f)]private float pathLengthHorizontal;    
    [Header("|")]
    [SerializeField]private bool movingVertical;
    [SerializeField][Range(0, 30f)]private float pathLengthVertical;

    [SerializeField]private GameObject movingPlatform;
    [SerializeField]private GameObject startMoving;

    private Vector2 startPosition;

    private float widthPlatform;
    private float heightPlatform;
    private Vector2 velocityVector;

    private Rigidbody2D rb;

    
    [Header("Для настройки изначального направления движения платформы")]
    [SerializeField]private bool movingRight;
    [SerializeField]private bool movingUp;

    private void Awake() {

        rb = GetComponent<Rigidbody2D>();

        movingPlatform = gameObject;
        startPosition = movingPlatform.transform.position;
        movingPlatform.transform.position = startMoving.transform.position;

        // Значения длин берутся из соответствующих объектов
        
        widthPlatform = movingPlatform.GetComponent<RectTransform>().sizeDelta.x;

        heightPlatform = movingPlatform.GetComponent<RectTransform>().sizeDelta.y;


    }

    void Start()
    {
        // Элементы при запуске сцены скрываются
        startMoving.SetActive(false);
    }

    void Update()
    {
                // rb.velocity = velocityVector;
                Vector2 velocity = Vector2.zero;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, velocityVector, ref velocity, .01f);

    }

    private void FixedUpdate() {
        // Для определения горизонтального движения
        if(movingPlatform.transform.position.x>=startPosition.x+pathLengthHorizontal/2-widthPlatform/2){
            movingRight=false;
        }
        if(movingPlatform.transform.position.x<=startPosition.x-pathLengthHorizontal/2+widthPlatform/2){
            movingRight=true;
        }

        if(movingRight&&movingHorizontal){
            velocityVector = new Vector2(speed,0);
        }
        if(!movingRight&&movingHorizontal){
            velocityVector = new Vector2(-speed,0);
        }
        // Для определения вертикального движения
        if(movingPlatform.transform.position.y>=startPosition.y+pathLengthVertical/2-heightPlatform/2){
            movingUp=false;
        }
        if(movingPlatform.transform.position.y<=startPosition.y-pathLengthVertical/2+heightPlatform/2){
            movingUp=true;
        }

        if(movingUp&&movingVertical){
            velocityVector = new Vector2(0,speed);
        }
        if(!movingUp&&movingVertical){
            velocityVector = new Vector2(0,-speed);
        }

        // rb.gravityScale = 0.65f;
        // Vector2 targetVelocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y);
        Vector2 velocity = Vector2.zero;
        // rb.velocity = Vector2.SmoothDamp(rb.velocity, velocityVector, ref velocity, .01f);
        
        // rb.velocity = velocityVector;
        
        // rb.AddForce(velocityVector*50);
        // rb.AddForce(velocityVector*50);

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = movingPlatform.transform;
            // collision.GetComponent<Rigidbody2D>.velocity=
        }
    }

    // private void OnCollisionStay2D(Collision2D collision) {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         // collision.transform.parent = movingPlatform.transform;
    //         collision.gameObject.GetComponent<Rigidbody2D>().velocity=velocityVector;
    //     }
    // }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent=null;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawWireCube(transform.position, new Vector3(pathLengthHorizontal, 0.5f, 0));
        Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, pathLengthVertical, 0));
    }
    
}