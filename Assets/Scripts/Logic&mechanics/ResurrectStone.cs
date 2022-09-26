using UnityEngine;

public class ResurrectStone : MonoBehaviour
{
    private Animator anim;
    private AudioSource soundActive;
    void Start()
    {
        anim=GetComponent<Animator>();
        soundActive=GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D myTrigger)
    {
        if (myTrigger.CompareTag("Player")&&!anim.GetBool("Active"))
        {
            myTrigger.GetComponent<scr_Player>().spawnPosition = transform;
            anim.SetBool("Active",true);
            soundActive.Play();
        }
    }

}
