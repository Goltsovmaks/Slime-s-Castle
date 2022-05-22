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

    
    [Header("Для настройки изначального направления движения платформы")]
    [SerializeField]private bool movingRight;
    [SerializeField]private bool movingUp;

    

    private void Awake() {

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
            movingPlatform.transform.position = new Vector2(movingPlatform.transform.position.x+speed*Time.fixedDeltaTime,movingPlatform.transform.position.y);
        }
        if(!movingRight&&movingHorizontal){
            movingPlatform.transform.position = new Vector2(movingPlatform.transform.position.x-speed*Time.fixedDeltaTime,movingPlatform.transform.position.y);
        }
        // Для определения вертикального движения
        if(movingPlatform.transform.position.y>=startPosition.y+pathLengthVertical/2-heightPlatform/2){
            movingUp=false;
        }
        if(movingPlatform.transform.position.y<=startPosition.y-pathLengthVertical/2+heightPlatform/2){
            movingUp=true;
        }

        if(movingUp&&movingVertical){
            movingPlatform.transform.position = new Vector2(movingPlatform.transform.position.x, movingPlatform.transform.position.y+speed*Time.fixedDeltaTime);
        }
        if(!movingUp&&movingVertical){
            movingPlatform.transform.position = new Vector2(movingPlatform.transform.position.x, movingPlatform.transform.position.y-speed*Time.fixedDeltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent=movingPlatform.transform;
        }
    }

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