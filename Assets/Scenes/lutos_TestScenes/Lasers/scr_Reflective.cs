using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Reflective:MonoBehaviour
{
    [SerializeField] public List<scr_ray> rays;

    public virtual void Reflect(GameObject source, GameObject origin, Vector2 startPoint, Vector2 hitPoint, Dictionary<GameObject, int> reflectionDictionary, int currentReflectionStep) { }
}
