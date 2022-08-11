using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Reflective:MonoBehaviour
{
    [SerializeField] public List<scr_ray> rays;

    public virtual void Reflect(GameObject source, GameObject origin, Vector2 startPoint, Vector2 hitPoint, Material laserMaterial, Dictionary<GameObject, int> reflectionDictionary, int currentReflectionStep) { }
}

//[System.Serializable]
//public class LaserColor
//{
//    public ColorNameEnum colorName;
//    public Color color;
//    public float intensity;

//    public Vector4 GetHDRColor()
//    {
//        return (Vector4)color*intensity;
//    }

//    public enum ColorNameEnum
//    {
//        color1,
//        color2,
//        color3,
//        magenta,
//        cyan
//    }
//}