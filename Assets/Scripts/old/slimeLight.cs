using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeLight : MonoBehaviour
{
    public Transform slime;
    public Light lightSlime;
    private Vector3 StartPos;

    void Start()
    {
        lightSlime.transform.position = new Vector3(slime.position.x, slime.position.y, -1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        lightSlime.transform.position=new Vector3(slime.position.x,slime.position.y, -1.0f);
        
    }


    // void Start()
    // {
    //     StartPos=slime.transform.position;
    //     StartPos.y+=10;
    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }
    // private void OnTriggerEnter2D(Collider2D myTrigger)
    // {
    //     if (myTrigger.CompareTag("Player"))
    //     {
    //         win();
    //     }
    // }
    // void win(){
    //     slime.transform.position=StartPos;
    // }
}
