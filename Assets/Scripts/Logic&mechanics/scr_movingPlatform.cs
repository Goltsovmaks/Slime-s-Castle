using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_movingPlatform : MonoBehaviour
{
    [SerializeField][Range(0, 30f)]private float speed;

    [SerializeField]private bool movingHorizontal;
    [SerializeField]private bool movingVertical;

    [SerializeField]private GameObject movingPlatform;
    [SerializeField]private GameObject objectPathLengthHorizontal;
    [SerializeField]private GameObject objectPathLengthVertical;
    [SerializeField]private GameObject startMoving;

    private Vector2 startPosition;

    private float widthPlatform;
    private float heightPlatform;

    private float pathLengthHorizontal;
    private float pathLengthVertical;
    [Header("Для настройки изначального направления движения платформы")]
    [SerializeField]private bool movingRight;
    [SerializeField]private bool movingUp;

    private void Awake() {

        movingPlatform = gameObject;
        startPosition = movingPlatform.transform.position;
        movingPlatform.transform.position = startMoving.transform.position;

        // Значения длин берутся из соответствующих объектов
        // Неучтена ситуация с изменением видимого размера платформы!!
        pathLengthHorizontal = objectPathLengthHorizontal.GetComponent<SpriteRenderer>().size.x;
        widthPlatform = movingPlatform.GetComponent<RectTransform>().sizeDelta.x;

        pathLengthVertical = objectPathLengthVertical.GetComponent<SpriteRenderer>().size.y;
        heightPlatform = movingPlatform.GetComponent<RectTransform>().sizeDelta.y;


    }

    void Start()
    {
        // Элементы при запуске сцены скрываются
        objectPathLengthHorizontal.SetActive(false);
        objectPathLengthVertical.SetActive(false);
        startMoving.SetActive(false);
    }

    void Update()
    {
        // Для отладки
        // pathLengthHorizontal = objectPathLengthHorizontal.GetComponent<SpriteRenderer>().size.x;
        // pathLengthVertical = objectPathLengthVertical.GetComponent<SpriteRenderer>().size.y;
        // objectPathLengthHorizontal.transform.position = startPosition;
        // objectPathLengthVertical.transform.position = startPosition;

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
    
}