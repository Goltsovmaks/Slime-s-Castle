using System.Collections;
using UnityEngine;

public class scr_Player : MonoBehaviour, scr_IDamageable
{
    public static scr_Player instance;

    public static float damageRate = 1f;
    public static float nextDamage;
    public static bool canTakeDamage = true;

    public static GameObject currentPickedObject = null;

    public int maxHealth;
    public int currentHealth;

    public int currentNumberOfCoins = 0;

    public Transform spawnPosition;
    [SerializeField]private float respawnTime = 1f;

    public delegate void Action(int health);
    public static event Action PlayerWasDamaged;

    public delegate void TakeCoinAction(int number);
    public static event Action PlayerGotACoin;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        scr_EventSystem.instance.playerAwake.Invoke(transform);

        maxHealth = 3;
        currentHealth = maxHealth;
        MenuController.SetSpawnPositionEvent+=SetSpawnPosition;
        MenuController.GetSpawnPositionEvent+=GetSpawnPosition;

        scr_GameManager GameManager = scr_GameManager.instance;
        GameManager.player = gameObject;

        EditorManager editorManager = EditorManager.instance;


        if (!GameManager.currentSaveGame.newGame)
        {
            transform.position = GameManager.currentSaveGame.position;
        }
        
    }

    public void AddCoin(int coins)
    {
        currentNumberOfCoins += coins;
        
        PlayerGotACoin(currentNumberOfCoins);
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

            PlayerWasDamaged(currentHealth);
        }
 
    }

    public void Die()
    {
        InputManager.Instance.playerInput.actions.FindActionMap("Slime").Disable();
        MenuController.instance.ShowOrHideDiePanel();

        StartCoroutine(Respawn(spawnPosition));

    }

    IEnumerator Respawn(Transform spawnPosition)
    {
        currentHealth = maxHealth;

        yield return new WaitForSeconds(respawnTime);
        gameObject.transform.position = spawnPosition.position;

        InputManager.Instance.playerInput.actions.FindActionMap("Slime").Enable();
        MenuController.instance.ShowOrHideDiePanel();

        canTakeDamage = true;

    }

    public void SetSpawnPosition(Vector3 position)
    {
        spawnPosition.position=position;
        gameObject.transform.position = spawnPosition.position;
        Debug.Log(spawnPosition.position);
        Debug.Log(gameObject.transform.position);
    }

    public Vector3 GetSpawnPosition()
    {
        return spawnPosition.position;
    }

    private void OnDestroy() 
    {
        MenuController.SetSpawnPositionEvent-=SetSpawnPosition;
        MenuController.GetSpawnPositionEvent-=GetSpawnPosition;
    }


}
