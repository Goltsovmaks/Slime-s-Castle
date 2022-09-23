using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Rigidbody2D physic;
    // Start is called before the first frame update
    void Start()
    {
        // physic = GetComponent<Rigidbody2D>();
        Destroy(gameObject,1.41f);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
}
