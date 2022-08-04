using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Mirror : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField] string rayCastMask;
    [SerializeField] float maxCastDistance;

    [SerializeField] private bool isReflecting = false;
    [SerializeField] private float timeLeftSinceLastReflection = 0;
    [SerializeField] private float stopRate = 0.1f;

    [SerializeField] private bool isRotating = false;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0, 0, 36f * Time.deltaTime);
        }



        timeLeftSinceLastReflection -= Time.deltaTime;
        if (timeLeftSinceLastReflection <= 0)
        {
            lineRenderer.enabled = false;
            //timeLeftSinceLastReflection = 0;
        }
        else
        {
            lineRenderer.enabled = true;
        }
        //StopReflecting();
    }

    public void Reflect(Vector2 startPoint,Vector2 hitPoint)
    {
        //isReflecting = true;
        timeLeftSinceLastReflection = stopRate;

        Vector2 normal = new Vector2(Mathf.Sin(-Mathf.Deg2Rad * transform.rotation.eulerAngles.z), Mathf.Cos(-Mathf.Deg2Rad * transform.rotation.eulerAngles.z));
        Vector2 vectorA = hitPoint - startPoint;

        float coeff = normal.x * vectorA.x + normal.y * vectorA.y / normal.magnitude;
        Vector2 projectionAn = new Vector2(normal.x * coeff, normal.y * coeff);

        Vector2 direction = (vectorA - 2 * projectionAn).normalized;
        

        lineRenderer.SetPosition(0, hitPoint);

        RaycastHit2D[] raycastHits2D = Physics2D.RaycastAll(hitPoint, direction, maxCastDistance, LayerMask.GetMask(rayCastMask));
        int currentHit = 0;
        foreach (var hit in raycastHits2D)
        {
            if (hit.collider.gameObject == gameObject)
            {
                currentHit += 1;
            }
        }

        if (raycastHits2D.Length > currentHit)
        {
            lineRenderer.SetPosition(1, raycastHits2D[currentHit].point);
            Debug.Log("hit");
            Interact(startPoint, raycastHits2D[currentHit]);
        }
        else
        {
            lineRenderer.SetPosition(1, hitPoint + direction * maxCastDistance);
            Debug.Log("NOhit");
        }
    }

    //private void StopReflecting()
    //{
    //    isReflecting = false;
    //}

    private void Interact(Vector2 startPoint,RaycastHit2D raycastHit2D)
    {
        if (raycastHit2D.collider.TryGetComponent<scr_Mirror>(out scr_Mirror mirror))
        {
            mirror.Reflect(startPoint,raycastHit2D.point);
        }
        
    }
}
