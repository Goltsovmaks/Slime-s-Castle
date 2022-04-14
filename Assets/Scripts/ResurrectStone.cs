using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurrectStone : MonoBehaviour
{
    private GameObject slime;
    private Animator anim;
    private AudioSource soundActive;
    // Start is called before the first frame update
    void Start()
    {
        slime=GameObject.FindGameObjectWithTag("Player");
        anim=GetComponent<Animator>();
        soundActive=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D myTrigger)
    {
        if (myTrigger.CompareTag("Player")&&!anim.GetBool("Active"))
        {
            myTrigger.GetComponent<scr_Player>().spawnPosition = transform;
            //SlimeData.PointOfResurrect.Add(transform.position);
            anim.SetBool("Active",true);
            soundActive.Play();
        }
    }

}
