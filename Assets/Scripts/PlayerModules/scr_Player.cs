using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour, scr_IDamageable
{
    public static float damageRate = 1f;
    public static float nextDamage;
    public static bool canTakeDamage = true;

    public int maxHealth { get; private set; }
    public int currentHealth { get; private set; }

    public Transform spawnPosition;

    public delegate void Action(int health);
    public static event Action PlayerWasDamaged;



    private void Awake()
    {
        maxHealth = 3;
        currentHealth = maxHealth;
        MenuController.SetSpawnPositionEvent+=SetSpawnPosition;
        MenuController.GetSpawnPositionEvent+=GetSpawnPosition;

        scr_GameManager GameManager = scr_GameManager.instance;// Получаем ссылку на GameObject
        GameManager.player = this.gameObject;
        GameManager.SetStartPosition();
        spawnPosition = GameManager.startPosition.transform;
        // При новой загрузке точка спавна - место появления на уровне
        //spawnPosition=gameObject.transform;
        // сообщить gamemanager - я родился

    }
    private void Start()
    {


    
    }

    public void ApplyDamage(int damage)
    {
        if (Time.time > nextDamage && canTakeDamage)
        {
            nextDamage = Time.time + damageRate;

            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                canTakeDamage = false;
                Die();
            }
            Debug.Log("currentHP is " + currentHealth);

            PlayerWasDamaged(currentHealth);
        }


        
    }

    public void Die()
    {
        InputManager.instance.playerInput.actions.FindActionMap("Slime").Disable();
        MenuController.instance.ShowOrHideDiePanel();

        StartCoroutine(Respawn(spawnPosition));
        

        //if (!(spawnPosition is null))
        //{
        //    Respawn(spawnPosition);
        //}
        
    }

    IEnumerator Respawn(Transform spawnPosition)
    {
        gameObject.transform.position = spawnPosition.position;
        currentHealth = maxHealth;
        yield return new WaitForSeconds(3);
        InputManager.instance.playerInput.actions.FindActionMap("Slime").Enable();
        MenuController.instance.ShowOrHideDiePanel();

        canTakeDamage = true;

    }

    //public void Respawn(Transform spawnPosition)
    //{
    //    currentHealth = maxHealth;
    //    gameObject.transform.position = spawnPosition.position;
    //}

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
