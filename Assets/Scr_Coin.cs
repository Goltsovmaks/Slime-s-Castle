using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Coin : MonoBehaviour
{
    private bool isInteractable = false;

    void Start()
    {
        StartCoroutine(BecomeInteractable());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInteractable)
        {
            if (collision.CompareTag("Player"))
            {
                //начислить монетку
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isInteractable)
        {
            if (collision.CompareTag("Player"))
            {
                //начислить монетку
                Destroy(gameObject);
            }
        }
    }

    IEnumerator BecomeInteractable()
    {
        yield return new WaitForSeconds(1f);
        isInteractable = true;
    }
}
