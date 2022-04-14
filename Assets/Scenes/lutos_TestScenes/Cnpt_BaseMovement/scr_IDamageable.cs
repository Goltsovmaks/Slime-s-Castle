using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface scr_IDamageable
{
    int maxHealth { get; }
    int currentHealth { get; }

    public void ApplyDamage(int damage);

    void Die();

    void Respawn(Transform spawnPoint);

}
