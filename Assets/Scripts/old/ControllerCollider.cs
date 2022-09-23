using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCollider : MonoBehaviour
{
[SerializeField]
private Collider2D[] colliders;
private int currentColliderIndex = 0;


public void SetColliderForSprite(int spriteNum){
    colliders[currentColliderIndex].enabled = false;
    currentColliderIndex = spriteNum;
    colliders[currentColliderIndex].enabled = true;

}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
