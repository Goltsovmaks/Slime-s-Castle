using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_LightRock : scr_Reflective
{
    [SerializeField] string rayCastMask;
    [SerializeField] float maxCastDistance;

    [SerializeField] private bool isReflecting = false;
    [SerializeField] private float timeLeftSinceLastReflection = 0;
    [SerializeField] private static float stopRate = 0.1f;
    [SerializeField] private static int reflectionStep = 10;

    [SerializeField] private Material reflectionLaserMaterial;

    //[SerializeField] public List<scr_ray> rays = new List<scr_ray>();

    [SerializeField] GameObject rayPrefab;

    private GameObject ray;

    private void Start()
    {
        rays = new List<scr_ray>();
    }

    public override void Reflect(GameObject source, GameObject origin, Vector2 startPoint, Vector2 hitPoint, Material laserMaterial, Dictionary<GameObject, int> reflectionDictionary, int currentReflectionStep) //reflectionStep
    {
        if (currentReflectionStep < reflectionStep)
        {
            LineRenderer lineRenderer;
            Material currentLaserMaterial;

            if (reflectionDictionary.ContainsKey(source))
            {
                if (reflectionDictionary[source] < 1)
                {
                    //==================================
                    if (ray == null)
                    {
                        GameObject rayObject = Instantiate(rayPrefab, transform);
                        rayObject.transform.parent = gameObject.transform;
                        rayObject.GetComponent<scr_ray>().source = source;
                        rayObject.GetComponent<scr_ray>().origin = origin;
                        rayObject.GetComponent<scr_ray>().parent = this;
                        rayObject.GetComponent<scr_ray>().reflectionStep = 0;

                        rays.Add(rayObject.GetComponent<scr_ray>());
                        ray = rayObject;

                        lineRenderer = rayObject.GetComponent<scr_ray>().lineRenderer;
                    }
                    else
                    {
                        ray.GetComponent<scr_ray>().birthTime = Time.time;
                        lineRenderer = ray.GetComponent<scr_ray>().lineRenderer;
                    }
                    //==================================


                    //scr_ray r = rays.Find(r => (r.source == source && r.origin == origin));
                    //if (r != null)
                    //{
                    //    r.birthTime = Time.time;
                    //    lineRenderer = r.lineRenderer;
                    //}
                    //else
                    //{
                    //    GameObject rayObject = Instantiate(rayPrefab, transform);
                    //    rayObject.transform.parent = gameObject.transform;
                    //    rayObject.GetComponent<scr_ray>().source = source;
                    //    rayObject.GetComponent<scr_ray>().origin = origin;
                    //    rayObject.GetComponent<scr_ray>().parent = this;
                    //    rayObject.GetComponent<scr_ray>().reflectionStep = 0;

                    //    rays.Add(rayObject.GetComponent<scr_ray>());

                    //    lineRenderer = rayObject.GetComponent<scr_ray>().lineRenderer;
                    //}

                    Vector2 normal = new Vector2(Mathf.Sin(-Mathf.Deg2Rad * transform.rotation.eulerAngles.z), Mathf.Cos(-Mathf.Deg2Rad * transform.rotation.eulerAngles.z));
                    Vector2 direction = normal.normalized;

                    if (reflectionLaserMaterial != null)
                    {
                        currentLaserMaterial = reflectionLaserMaterial;
                        lineRenderer.material = reflectionLaserMaterial;
                    }
                    else
                    {
                        currentLaserMaterial = laserMaterial;
                        lineRenderer.material = laserMaterial;
                    }

                    lineRenderer.SetPosition(0, transform.position);

                    RaycastHit2D[] raycastHits2D = Physics2D.RaycastAll(transform.position, direction, maxCastDistance, LayerMask.GetMask(rayCastMask));
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
                        Interact(gameObject, transform.position, raycastHits2D[currentHit], currentLaserMaterial, reflectionDictionary, currentReflectionStep + 1);
                    }
                    else
                    {
                        lineRenderer.SetPosition(1, hitPoint + direction * maxCastDistance);
                    }
                }
            }
        }


    }

    private void Interact(GameObject origin, Vector2 startPoint, RaycastHit2D raycastHit2D, Material laserMaterial, Dictionary<GameObject, int> dictionary, int currentReflectionStep)
    {
        if (raycastHit2D.collider.TryGetComponent<scr_Reflective>(out scr_Reflective reflective))
        {
            dictionary = UpdateDictionary(gameObject, dictionary);
            reflective.Reflect(gameObject, origin, startPoint, raycastHit2D.point, laserMaterial, dictionary, currentReflectionStep);
        }
        if (raycastHit2D.collider.TryGetComponent<scr_laserReceiver>(out scr_laserReceiver receiver))
        {
            receiver.Enable(laserMaterial);
        }
    }

    private Dictionary<GameObject, int> UpdateDictionary(GameObject source, Dictionary<GameObject, int> dictionary)
    {
        if (dictionary.ContainsKey(source))
        {
            dictionary[source] += 1;
        }
        else
        {
            dictionary.Add(source, 0);
        }
        return dictionary;
    }
}
