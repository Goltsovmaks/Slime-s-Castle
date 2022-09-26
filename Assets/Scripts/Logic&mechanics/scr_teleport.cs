using UnityEngine;

public class scr_teleport : MonoBehaviour
{
    [SerializeField]private GameObject finalTeleportObject;
    [SerializeField]private Vector2 finalTeleportPosition;

    private void Awake() 
    {
        finalTeleportPosition = finalTeleportObject.transform.position;
        finalTeleportObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.CompareTag("Player"))
        {
            collider.gameObject.transform.position = finalTeleportPosition;
        }
    }

}
