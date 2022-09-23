using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_laser : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField] private bool isOn;

    [SerializeField] string rayCastMask;
    [SerializeField] float maxCastDistance;

    [SerializeField] Material laserMaterial;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.enabled = false;
    }

    private void Update()
    {
        if (isOn)
        {
            Cast();
        }
        else
        {
            lineRenderer.enabled = false;
        }
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
            lineRenderer.SetPosition(1, (Vector2)transform.position + direction * maxCastDistance);
        }
    }

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

    private Vector2 GetDirectionVector()
    {
        Vector2 direction = Vector2.right;

        float cs = Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.z);
        float sn = Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.z);
        float dirX = direction.x * cs - direction.y * sn;
        float dirY = direction.x * sn + direction.y * cs;

        direction = new Vector2(dirX, dirY);

        return direction;
    }
}
