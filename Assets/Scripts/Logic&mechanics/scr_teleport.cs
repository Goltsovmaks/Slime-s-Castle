using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_teleport : MonoBehaviour
{
    [SerializeField]private GameObject finalTeleportObject;
    [SerializeField]private Vector2 finalTeleportPosition;




    private void Awake() {
        finalTeleportPosition = finalTeleportObject.transform.position;
        finalTeleportObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("телепорт");
            collider.gameObject.transform.position = finalTeleportPosition;
        }
    }




    // private void OnDrawGizmos() {
    //     Gizmos.color = new Color(1, 0, 1, 0.5f);
    //     Gizmos.DrawWireSphere(finalTeleportPosition, 0.5f);
    //     // Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, pathLengthVertical, 0));
    // }
}
