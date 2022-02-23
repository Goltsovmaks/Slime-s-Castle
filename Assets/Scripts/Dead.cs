using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private GameObject slime;
    private GameObject _Dead;
    private Vector3 StartPos;
    private GameObject HUD;
    IEnumerator ShowDeadTime(float waitTime)
    {
        _Dead.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        _Dead.SetActive(false);
        
    }



    void Start()
    {
        slime = GameObject.Find("slime");
        HUD=GameObject.Find("HUD");
        _Dead=HUD.GetComponent<HUDController>().Dead;
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D myTrigger)
    {
        if (myTrigger.CompareTag("Player"))
        {
            dead();
            print("Dead!");

        }
    }
    void dead(){
        
        StartCoroutine(ShowDeadTime(0.50f));
        slime.transform.position=SlimeData.PointOfResurrect[SlimeData.PointOfResurrect.Count-1];
    }
}
