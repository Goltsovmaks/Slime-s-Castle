using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLogic : MonoBehaviour
{
    private GameObject slime;
    private GameObject _Dead;
    private Vector3 StartPos;
    private GameObject HUD;

    public delegate void methodDead();
    IEnumerator ShowDeadTime(float waitTime)
    {
        _Dead.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        _Dead.SetActive(false);
        
    }
    void Awake() {
        HarmLogic.DeadEvent+=dead;
    }

    void Start()
    {
        slime = gameObject;
        HUD=GameObject.Find("HUD");
        _Dead=HUD.GetComponent<HUDController>().Dead;

    }
    void Update()
    {

    }
    
    void OnDestroy() {
        HarmLogic.DeadEvent-=dead;
    }
    // private void OnTriggerEnter2D(Collider2D myTrigger)
    // {
    //     if (myTrigger.CompareTag("Player"))
    //     {
    //         dead();
    //         print("Dead!");

    //     }
    // }
    void dead(){
        
        StartCoroutine(ShowDeadTime(0.50f));
        slime.transform.position=SlimeData.PointOfResurrect[SlimeData.PointOfResurrect.Count-1];
    }
}
