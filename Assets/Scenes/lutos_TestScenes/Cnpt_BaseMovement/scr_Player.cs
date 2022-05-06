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

        scr_GameManager GameManager = scr_GameManager.instance;// Получаем ссылку на GameObject
        GameManager.player = this.gameObject;
        GameManager.SetStartPosition();
        // При новой загрузке точка спавна - место появления на уровне
        spawnPosition=gameObject.transform;
        // сообщить gamemanager - я родился

    }
    private void Start()
    {


    
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
        return spawnPosition.position;
    }

    private void OnDestroy() {
        MenuController.SetSpawnPositionEvent-=SetSpawnPosition;
        MenuController.GetSpawnPositionEvent-=GetSpawnPosition;
    }


}
