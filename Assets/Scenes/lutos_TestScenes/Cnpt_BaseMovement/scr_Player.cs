using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour, scr_IDamageable
{
    public int maxHealth { get; private set; }
    public int currentHealth { get; private set; }

    public Transform spawnPosition;



    private void Awake()
    {
        maxHealth = 5;
        currentHealth = maxHealth;
        MenuController.SetSpawnPositionEvent+=SetSpawnPosition;
        MenuController.GetSpawnPositionEvent+=GetSpawnPosition;

        scr_GameManager gm = scr_GameManager.instance;// Получаем ссылку на GameObject
        gm.player = this.gameObject;
        gm.SetStartPosition();

        // сообщить gamemanager - я родился

        




        // if(spawnPosition!=null){
        //     gameObject.transform.position=spawnPosition.position;
        // }else{
        //     spawnPosition=gameObject.transform;
        // }
        // spawnPosition.position
    }
    private void Start()
    {
        Debug.Log("1");
        // Жёсткий костыль
        if(spawnPosition==null){
            spawnPosition=gameObject.transform;
        }
        
        Respawn(spawnPosition);
    
    }

    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        Debug.Log("currentHP is " + currentHealth);
    }

    public void Die()
    {
        //do something
        //shown Die Panel
        if (!(spawnPosition is null))
        {
            Respawn(spawnPosition);
        }
        
    }

    public void Respawn(Transform spawnPosition)
    {
        currentHealth = maxHealth;
        gameObject.transform.position = spawnPosition.position;
    }

    public void SetSpawnPosition(Vector3 position){
        spawnPosition.position=position;
        gameObject.transform.position = spawnPosition.position;
        Debug.Log(spawnPosition.position);
        Debug.Log(gameObject.transform.position);
    }

    public Vector3 GetSpawnPosition(){
        // Debug.Log(spawnPosition.position);
        return spawnPosition.position;
    }


}
