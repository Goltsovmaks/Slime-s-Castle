using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_SpiderWebShot : MonoBehaviour
{
    public float xForce = 10f;
    public float yForce = 5f;

    public void Shot()
    {
        //получить направление стика геймпада в direction
        //gameObject.GetComponent<Rigidbody2D>().velocity = direction;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(xForce, yForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }

}
