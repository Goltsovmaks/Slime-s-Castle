using System.Collections;
using UnityEngine;

public class scr_fallingStalagmite : MonoBehaviour
{
    private Vector3 size;
    private Vector3 offsetPosition;
    private Vector3 startPosition;

    private bool recovering;
    private bool falling;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [SerializeField][Range(0, 2f)]private float widthCheckArea;    
    [SerializeField][Range(0, 30f)]private float heightCheckArea;

    [Header("Настройка скорости и высоты падения")]
    [SerializeField][Range(0, 30f)]private float speedFalling;
    [SerializeField][Range(0, 120f)]private float heightFalling;

    [Header("true, если восстанавливается")]
    [SerializeField]private bool reusable = true;
    [SerializeField][Range(0.001f, 10f)] private float timeRecovery;

    [Header("true, если всегда падает")]
    [SerializeField]private bool alwaysFalling;

    private bool checkCollider;
    [SerializeField]private LayerMask slime;

    IEnumerator recoverAfter(float time)
    {
        recovering = true;
        falling = false;

        yield return new WaitForSeconds(time);
        rb.velocity = new Vector2(0,0);
        transform.position = startPosition;

        spriteRenderer.enabled = true;
        recovering = false;
         
    }
    
    void Start()
    {
        startPosition = transform.position; 
        size = new Vector3(widthCheckArea, heightCheckArea, 0);
        offsetPosition = new Vector3(0, heightCheckArea/2, 0);
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() 
    {
        if(alwaysFalling)
        {
            checkCollider = true;
        }
        else
        {
            checkCollider = Physics2D.OverlapBox(transform.position - offsetPosition, 
                size, 0f, slime);
        }

        
        if(checkCollider&&!recovering&&!falling)
        {
            falling = true;
            rb.velocity = new Vector2(0,-speedFalling);
        }

        if(Vector3.Distance(startPosition, transform.position) > heightFalling&&!recovering)
        {
            collision();
        }


            
    }
    private void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.CompareTag("Player"))
        {
            collision();
        }

        if(colider.CompareTag("Breaking")){

            collision();
        }

        if(colider.CompareTag("Starting")){
            startPosition = new Vector3(transform.position.x,
                colider.gameObject.transform.position.y,0);
        }
    }

    private void collision()
    {
        if(!reusable)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(recoverAfter(timeRecovery));            
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawWireCube(transform.position - new Vector3(0, 
            heightCheckArea/2, 0), new Vector3(widthCheckArea, heightCheckArea, 0));
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireCube(transform.position - new Vector3(0, 
            heightFalling, 0), new Vector3(0.5f, 0.5f, 0));
    }
}
