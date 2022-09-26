using System.Collections.Generic;
using UnityEngine;

public class scr_Trap : MonoBehaviour
{
    public int damage;
    [SerializeField] List<creatureType> whoCanBeDamaged = new List<creatureType>();

    private void OnTriggerEnter2D(Collider2D col)
    {
        TryDamage(col);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        TryDamage(col);
    }

    private void TryDamage(Collider2D col)
    {
        foreach (var type in whoCanBeDamaged)
        {
            if (col.CompareTag(type.ToString()))
            {
                col.gameObject.GetComponent<scr_IDamageable>().ApplyDamage(damage);
                break;
            }
        }
    }

    enum creatureType
    {
        Player,
        Enemy
    }

}
