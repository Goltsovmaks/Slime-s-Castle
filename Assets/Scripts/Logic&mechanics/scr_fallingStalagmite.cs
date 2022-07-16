using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_fallingStalagmite : MonoBehaviour
{
    private Vector3 size;
    private Vector3 offsetPosition;
    private Vector3 startPosition;
    private Vector2 repulsiveVector;
    private bool recovering;
    private bool falling;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;


    [SerializeField][Range(0, 2f)]private float widthCheckArea;    
    [SerializeField][Range(0, 30f)]private float heightCheckArea;

    [Header("Сила толчка при соприкосновении")]
    [SerializeField][Range(0, 100f)]private float repulsiveForceHorizontal;
    [SerializeField][Range(0, 10f)]private float repulsiveForceVertical;

    [Header("Настройка гравитации")]
    [SerializeField][Range(0, 5f)]private float gravityScale;

    [Header("true, если восстанавливается")]
    [SerializeField] private bool reusable = true;
    [SerializeField] [Range(0, 10f)] private float timeFalling;
    [SerializeField] [Range(0.1f, 10f)] private float timeRecovery;

    private bool checkCollider;
    [SerializeField]private LayerMask slime;

    
    IEnumerator fallDown(){
        falling = true;

        rb.isKinematic = false;
        rb.gravityScale = gravityScale;

        yield return new WaitForSeconds(timeFalling);
        spriteRenderer.enabled = false;
        rb.isKinematic = true;
        // Обнуление набранной скорости
        rb.velocity=Vector3.zero;
        transform.position = startPosition;

        if(!reusable){
            Destroy(gameObject);
        }else{
            StartCoroutine(recoverAfter(timeRecovery));            
        }

    }

    IEnumerator recoverAfter(float time){
        recovering = true;
        falling = false;

        // После прошествия времени сталагмит восстановиться
        yield return new WaitForSeconds(time);
        // Включаем
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

// Проверка на попадание игрока в зону
    private void FixedUpdate() {
        checkCollider = Physics2D.OverlapBox(transform.position - offsetPosition, size, 0f, slime);
        if(checkCollider&&!recovering&&!falling){
            StartCoroutine(fallDown());
            Debug.Log("start");          
        }
    }
// При столкновении придаём импульс игроку
    private void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.CompareTag("Player"))
        {

            if(transform.position.x>colider.transform.position.x){
                repulsiveVector = new Vector2(-1,1);
            }else{
                repulsiveVector = new Vector2(1,1);
            }
            repulsiveVector.x *= repulsiveForceHorizontal;
            repulsiveVector.y *= repulsiveForceVertical;

            colider.attachedRigidbody.AddForce(repulsiveVector, ForceMode2D.Impulse);


            // StartCoroutine(fallDownAfter(timeStanding));
            // colider.GetComponent<scr_Player>().spawnPosition = transform;
            // //SlimeData.PointOfResurrect.Add(transform.position);
            // anim.SetBool("Active",true);
            // soundActive.Play();
        }
    }

// Для отладки в редакторе
    private void OnDrawGizmos() {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawWireCube(transform.position - new Vector3(0, heightCheckArea/2, 0), new Vector3(widthCheckArea, heightCheckArea, 0));
    }
}
