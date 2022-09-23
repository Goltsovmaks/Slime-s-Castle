using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_fly : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]private GameObject startPositionObject;
    private Vector3 startPosition;
    private Vector3 fliesPosition;

    private float timeTempVariable;

    [SerializeField]private bool staying;
    [SerializeField]private bool fliesTo;

    // [SerializeField]private bool attack;
    // [SerializeField]private bool goBack;
    // [SerializeField]private bool immobilized;

    [SerializeField][Range(0, 20)]private float flightRadius;
    [SerializeField][Range(0, 5)]private float timeStaying;
    [SerializeField][Range(0, 5)]private float speedFlying;


    [SerializeField]private bool debugging;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        startPosition = startPositionObject.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        staying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(debugging){
            startPositionObject.transform.position=startPosition;
        }
    }
    private void FixedUpdate() {
        

        if(Vector2.Distance(transform.position, fliesPosition) < 0.01f){
            staying = true;
            fliesTo = false;
        }

        if(timeStaying < timeTempVariable){
            staying = false;
            fliesTo = true;
            timeTempVariable=0;
            fliesPosition = (Vector2)startPosition + Random.insideUnitCircle * flightRadius;
        }

        if(staying){
            timeTempVariable += Time.fixedDeltaTime;
        }
        
        if(staying){
            Staying();
        }else if(fliesTo){
            FliesTo();
        }

    }

    private void Staying(){

    }

    private void FliesTo(){
        transform.position = Vector3.MoveTowards(transform.position, fliesPosition, speedFlying*Time.fixedDeltaTime);
    }

    private void OnDrawGizmos() {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        // Gizmos.DrawWireCube(startPositionObject.transform.position, new Vector3(patrolDistance*2, 0.5f, 0));
        // Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(startPositionObject.transform.position, flightRadius);
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(fliesPosition, flightRadius/10);
    }
}
