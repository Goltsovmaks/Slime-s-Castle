using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomboxScript : MonoBehaviour
{
    AudioClip[] clips;
    private AudioSource music;

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.M))
        {
            music.Play();
        }
    }
}
