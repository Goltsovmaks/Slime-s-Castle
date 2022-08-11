using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_lens : MonoBehaviour
{
    private Vector2 firePoint1;
    private Vector2 firePoint2;

    private LineRenderer lineRenderer;

    [SerializeField]string rayCastMask;
    [SerializeField] float maxCastDistance;

    [SerializeField] Material laserMaterial;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        firePoint1 = transform.GetChild(0).position;
        firePoint2 = transform.GetChild(1).position;

        lineRenderer.enabled = false;
    }

    private void Cast()
    {
        Vector2 direction = GetDirectionVector();

        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, direction, maxCastDistance, LayerMask.GetMask(rayCastMask));

        lineRenderer.enabled = true;
        lineRenderer.material = laserMaterial;
        lineRenderer.SetPosition(0, transform.position);
        if (raycastHit2D)
        {
            lineRenderer.SetPosition(1, raycastHit2D.point);
            Interact(transform.position, raycastHit2D);
        }
        else
        {
            lineRenderer.SetPosition(1,(Vector2)transform.position + direction * maxCastDistance);
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cast();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lineRenderer.enabled = false;
        }
        
    }

    //================================
    private void Interact(Vector2 startPoint, RaycastHit2D raycastHit2D)
    {
        if (raycastHit2D.collider.TryGetComponent<scr_Reflective>(out scr_Reflective reflective))
        {
            reflective.Reflect(gameObject, gameObject, startPoint, raycastHit2D.point, laserMaterial, new Dictionary<GameObject, int>() { { gameObject, 0 } }, 0);
        }
        if (raycastHit2D.collider.TryGetComponent<scr_laserReceiver>(out scr_laserReceiver receiver))
        {
            receiver.Enable(laserMaterial);
        }

    }
    

    //private void Interact(Vector2 startPoint, RaycastHit2D raycastHit2D)
    //{
    //    if (raycastHit2D.collider.TryGetComponent<scr_Mirror>(out scr_Mirror mirror))
    //    {
    //        mirror.Reflect(startPoint, raycastHit2D.point);
    //    }

    //}
    //================================
    private Vector2 GetDirectionVector()
    {
        Vector2 direction = Vector2.right;

        float cs = Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.z);
        float sn = Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.z);
        float dirX = direction.x * cs - direction.y * sn;
        float dirY = direction.x * sn + direction.y * cs;

        direction = new Vector2(dirX, dirY);

        if (CheckIfPlayerIsCloserToPoint1())
        {
            return direction;
        }
        else
        {
            return -direction;
        }
    }



    private bool CheckIfPlayerIsCloserToPoint1()
    {
        Vector3 playerPosition = scr_Player.instance.transform.position;

        float point1Distance = Mathf.Sqrt(Mathf.Pow(((Vector2)playerPosition - firePoint1).x, 2f) + Mathf.Pow(((Vector2)playerPosition - firePoint1).y, 2f));
        float point2Distance = Mathf.Sqrt(Mathf.Pow(((Vector2)playerPosition - firePoint2).x, 2f) + Mathf.Pow(((Vector2)playerPosition - firePoint2).y, 2f));

        return point1Distance <= point2Distance;
    }
}
