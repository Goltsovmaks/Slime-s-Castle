using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_lens : MonoBehaviour
{
    private Transform firePoint;

    private LineRenderer lineRenderer;

    [SerializeField]string rayCastMask;
    [SerializeField] float maxCastDistance;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        firePoint = transform.GetChild(0);

        lineRenderer.enabled = false;
    }

    private void Cast(Collider2D collision)
    {
        lineRenderer.enabled = true;

        Vector3 direction = new Vector3(transform.position.x - collision.transform.position.x, 0).normalized;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(firePoint.position, direction, maxCastDistance, LayerMask.GetMask(rayCastMask));

        lineRenderer.SetPosition(0, firePoint.position);
        if (raycastHit2D)
        {
            lineRenderer.SetPosition(1, raycastHit2D.point);
            Interact(firePoint.position, raycastHit2D);
        }
        else
        {
            lineRenderer.SetPosition(1, transform.position + direction * maxCastDistance);
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cast(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lineRenderer.enabled = false;
        }
        
    }

    private void Interact(Vector2 startPoint, RaycastHit2D raycastHit2D)
    {
        if (raycastHit2D.collider.TryGetComponent<scr_Mirror>(out scr_Mirror mirror))
        {
            mirror.Reflect(startPoint, raycastHit2D.point);
        }

    }
}
