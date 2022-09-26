using UnityEngine;

public class scr_fly : MonoBehaviour
{
    [SerializeField]private GameObject startPositionObject;
    private Vector3 startPosition;
    private Vector3 fliesPosition;

    private float timeTempVariable;
    
    [SerializeField]private bool staying;
    [SerializeField]private bool fliesTo;

    [SerializeField][Range(0, 20)]private float flightRadius;
    [SerializeField][Range(0, 5)]private float timeStaying;
    [SerializeField][Range(0, 5)]private float speedFlying;

    [SerializeField]private bool debugging;

    private void Awake() 
    {
        startPosition = startPositionObject.transform.position;
    }

    void Start()
    {
        staying = true;
    }

    void Update()
    {
        if(debugging){
            startPositionObject.transform.position=startPosition;
        }
    }
    private void FixedUpdate() 
    {

        if(Vector2.Distance(transform.position, fliesPosition) < 0.01f)
        {
            staying = true;
            fliesTo = false;
        }

        if(timeStaying < timeTempVariable)
        {
            staying = false;
            fliesTo = true;
            timeTempVariable=0;
            fliesPosition = (Vector2)startPosition + Random.insideUnitCircle * flightRadius;
        }

        if(staying)
        {
            timeTempVariable += Time.fixedDeltaTime;
        }
        
        if(staying)
        {
            Staying();
        }else if(fliesTo)
        {
            FliesTo();
        }

    }

    private void Staying()
    {

    }

    private void FliesTo()
    {
        transform.position = Vector3.MoveTowards(transform.position, fliesPosition, speedFlying*Time.fixedDeltaTime);
    }

    private void OnDrawGizmos() {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawWireSphere(startPositionObject.transform.position, flightRadius);
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(fliesPosition, flightRadius/10);
    }
}
