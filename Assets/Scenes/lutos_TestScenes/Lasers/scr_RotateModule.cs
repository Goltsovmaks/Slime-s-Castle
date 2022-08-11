using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_RotateModule : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;
    public bool isRotating = false;

    private void Update()
    {
        if (isRotating)
        {
            Rotate();
        }   
    }
    public void Rotate()
    {
        transform.Rotate(Time.deltaTime * rotation);
    }
}
