using UnityEngine;

public class scr_repulsiveLogic : MonoBehaviour
{

    [Header("Сила толчка при соприкосновении")]
    [SerializeField][Range(0, 100f)]private float repulsiveForceHorizontal;
    [SerializeField][Range(0, 10f)]private float repulsiveForceVertical;

    private Vector2 repulsiveVector;


    private void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.CompareTag("Player"))
        {

            if(transform.position.x>colider.transform.position.x)
            {
                repulsiveVector = new Vector2(-1,1);
            }
            else
            {
                repulsiveVector = new Vector2(1,1);
            }
            repulsiveVector.x *= repulsiveForceHorizontal;
            repulsiveVector.y *= repulsiveForceVertical;

            colider.attachedRigidbody.AddForce(repulsiveVector, ForceMode2D.Impulse);

        }

    }
}
