using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_fallingPlatform : MonoBehaviour
{


    private Rigidbody2D rb;
    [SerializeField] private Collider2D collider;
    private SpriteRenderer spriteRenderer;

    private Vector3 startPosition;
    [SerializeField] [Range(0, 5f)] private float timeStanding;
    [SerializeField] [Range(0, 1f)] private float timeFalling;
    [Header("Время, через которое платформа восстановится")]
    [SerializeField] [Range(0, 10f)] private float timeRecovery;
    [Header("true, если многоразовая")]
    [SerializeField] private bool reusable = true;

    IEnumerator fallDownAfter(float time){
        // После прошествия времени платформа упадёт
        yield return new WaitForSeconds(time);
        // Выключить коллайдер
        rb.isKinematic = false;
        collider.enabled = false;
        yield return new WaitForSeconds(timeFalling);
        spriteRenderer.enabled = false;
        if(!reusable){
            Destroy(gameObject);
        }else{
            StartCoroutine(recoverAfter(timeRecovery-timeFalling));            
        }

    }

    IEnumerator recoverAfter(float time){
        // После прошествия времени платформа восстановиться
        yield return new WaitForSeconds(time);
        // Включить коллайдер и поставить на место
        collider.enabled = true;
        spriteRenderer.enabled = true;
        rb.isKinematic = true;
        // Обнление набранной скорости
        rb.velocity=Vector3.zero;
        transform.position = startPosition;        
        
    }

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.CompareTag("Player")&&collider.enabled)
        {
            StartCoroutine(fallDownAfter(timeStanding));
            // colider.GetComponent<scr_Player>().spawnPosition = transform;
            // //SlimeData.PointOfResurrect.Add(transform.position);
            // anim.SetBool("Active",true);
            // soundActive.Play();
        }
    }



}
