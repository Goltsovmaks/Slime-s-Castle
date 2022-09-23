using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ray : MonoBehaviour
{
    //public Ray(GameObject source, float birthTime, GameObject rayObject)
    //{
    //    this.source = source;
    //    this.birthTime = birthTime;
    //    this.rayObject = rayObject;
    //}

    public GameObject source;
    public GameObject origin;
    public float birthTime;
    public float lifetime;
    public scr_Reflective parent;

    public int reflectionStep;
    //public GameObject rayObject;

    public LineRenderer lineRenderer;

    private void Start()
    {
        birthTime = Time.time;
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (birthTime + lifetime <= Time.time)
        {
            parent.rays.Remove(this);
            Destroy(gameObject);
            //r.Destroy();
        }
    }

    //public void Destroy()
    //{
    //    Destroy(lineRenderer);
    //    Destroy(this);
    //}
}
