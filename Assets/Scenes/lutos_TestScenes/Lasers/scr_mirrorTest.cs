using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_mirrorTest : scr_Reflective
{
    //private LineRenderer lineRenderer;

    [SerializeField] string rayCastMask;
    [SerializeField] float maxCastDistance;

    [SerializeField] private bool isReflecting = false;
    [SerializeField] private float timeLeftSinceLastReflection = 0;
    [SerializeField] private static float stopRate = 0.1f;
    [SerializeField] private static int reflectionStep = 10;

    [SerializeField] private Material reflectionLaserMaterial;

    //[SerializeField] public List<scr_ray> rays = new List<scr_ray>();

    [SerializeField] GameObject rayPrefab;

    private void Start()
    {
        rays = new List<scr_ray>();
    }

    //private void Start()
    //{
    //    lineRenderer = GetComponent<LineRenderer>();
    //    lineRenderer.enabled = false;
    //}

    //private void Update()
    //{
    //    rays.ForEach(r => CheckRayTimerate(r));

    //    //timeLeftSinceLastReflection -= Time.deltaTime;
    //    //if (timeLeftSinceLastReflection <= 0)
    //    //{
    //    //    lineRenderer.enabled = false;
    //    //}
    //    //else
    //    //{
    //    //    lineRenderer.enabled = true;
    //    //}
    //}

    //private void CheckRayTimerate(scr_ray r)
    //{
    //    if (r.birthTime+stopRate <= Time.time)
    //    {
    //        //r.Destroy();
    //    }
    //}

    public override void Reflect(GameObject source, GameObject origin, Vector2 startPoint, Vector2 hitPoint, Material laserMaterial, Dictionary<GameObject,int> reflectionDictionary, int currentReflectionStep) //reflectionStep
    {
        if (currentReflectionStep < reflectionStep)
        {
            LineRenderer lineRenderer;
            Material currentLaserMaterial;

            if (reflectionDictionary.ContainsKey(source))
            {
                if (reflectionDictionary[source] < 1)
                {

                    //проверка на ориджин
                    scr_ray r = rays.Find(r => (r.source == source && r.origin == origin));
                    if (r != null)
                    {
                        r.birthTime = Time.time;
                        lineRenderer = r.lineRenderer;
                    }
                    else
                    {
                        GameObject rayObject = Instantiate(rayPrefab, transform);
                        rayObject.transform.parent = gameObject.transform;
                        rayObject.GetComponent<scr_ray>().source = source;
                        rayObject.GetComponent<scr_ray>().origin = origin;
                        rayObject.GetComponent<scr_ray>().parent = this;
                        rayObject.GetComponent<scr_ray>().reflectionStep = 0;

                        rays.Add(rayObject.GetComponent<scr_ray>());

                        lineRenderer = rayObject.GetComponent<scr_ray>().lineRenderer;
                    }

                    //проверяет источник, 
                    //если такой уже есть - обновляет его время
                    //если источник уникальный,добавляет его в лист, начинает отслеживать его время 

                    //timeLeftSinceLastReflection = stopRate;

                    Vector2 normal = new Vector2(Mathf.Sin(-Mathf.Deg2Rad * transform.rotation.eulerAngles.z), Mathf.Cos(-Mathf.Deg2Rad * transform.rotation.eulerAngles.z));
                    Vector2 vectorA = hitPoint - startPoint;

                    float coeff = normal.x * vectorA.x + normal.y * vectorA.y / normal.magnitude;
                    Vector2 projectionAn = new Vector2(normal.x * coeff, normal.y * coeff);

                    Vector2 direction = (vectorA - 2 * projectionAn).normalized;

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
                        Interact(origin, hitPoint, raycastHits2D[currentHit], currentLaserMaterial, reflectionDictionary, currentReflectionStep+1);
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

    private Dictionary<GameObject, int> UpdateDictionary(GameObject source,Dictionary<GameObject, int> dictionary)
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

//[System.Serializable]
//public class ReflectionList
//{
//    public Dictionary<GameObject, int> reflections = new Dictionary<GameObject, int>();

//    //public List<GameObject> sources = new List<GameObject>();
//    //public List<int> steps = new List<int>();
//}

//[System.Serializable]
//public class Ray
//{
//    public Ray(GameObject source, float birthTime, GameObject rayObject)
//    {
//        this.source = source;
//        this.birthTime = birthTime;
//        this.rayObject = rayObject;
//    }

//    public GameObject source;
//    public float birthTime;
//    public GameObject rayObject;

//    //public void Destroy()
//    //{
//    //    Destroy(lineRenderer);
//    //    Destroy(this);
//    //}
//}
