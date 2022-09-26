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

    private void Awake() 
    {

        rb = GetComponent<Rigidbody2D>();

        movingPlatform = gameObject;
        startPosition = movingPlatform.transform.position;
        movingPlatform.transform.position = startMoving.transform.position;
        
        widthPlatform = movingPlatform.GetComponent<RectTransform>().sizeDelta.x;

        heightPlatform = movingPlatform.GetComponent<RectTransform>().sizeDelta.y;
    }

    void Start()
    {
        startMoving.SetActive(false);
    }

    void Update()
    {
        Vector2 velocity = Vector2.zero;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, velocityVector, ref velocity, .01f);
    }

    private void FixedUpdate() 
    {
        if(movingPlatform.transform.position.x >= 
            startPosition.x+pathLengthHorizontal/2-widthPlatform/2)
        {
            movingRight=false;
        }
        if(movingPlatform.transform.position.x <= 
            startPosition.x-pathLengthHorizontal/2+widthPlatform/2)
        {
            movingRight=true;
        }

        if(movingRight&&movingHorizontal)
        {
            velocityVector = new Vector2(speed,0);
        }
        if(!movingRight&&movingHorizontal)
        {
            velocityVector = new Vector2(-speed,0);
        }

        if(movingPlatform.transform.position.y >= 
            startPosition.y+pathLengthVertical/2-heightPlatform/2)
        {
            movingUp=false;
        }
        if(movingPlatform.transform.position.y <= 
            startPosition.y-pathLengthVertical/2+heightPlatform/2)
        {
            movingUp=true;
        }

        if(movingUp&&movingVertical)
        {
            velocityVector = new Vector2(0,speed);
        }
        if(!movingUp&&movingVertical)
        {
            velocityVector = new Vector2(0,-speed);
        }

        Vector2 velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = movingPlatform.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent=null;
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawWireCube(transform.position, new Vector3(pathLengthHorizontal, 0.5f, 0));
        Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, pathLengthVertical, 0));
    }
    
}