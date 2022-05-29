using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_HUD : MonoBehaviour
{
    public GameObject[] HPbarArray = new GameObject[3];

    private GameObject hpBar;
    private GameObject coinCounter;

    private void Start()
    {
        hpBar = GameObject.Find("HP_bar");
        coinCounter = GameObject.Find("Counter");

        scr_Player.PlayerWasDamaged += UpdateHPBar;
        scr_Player.PlayerGotACoin += UpdateCoins;

        for (int i = 0; i < HPbarArray.Length; i++)
        {
            HPbarArray[i] = hpBar.transform.GetChild(i).gameObject;
        }
    }

    void UpdateHPBar(int currentHealth)
    {
        for (int i = 0; i < HPbarArray.Length; i++)
        {
            if (i < currentHealth)
            {
                HPbarArray[i].SetActive(true);
            }
            else
            {
                HPbarArray[i].SetActive(false);
            }
        }
    }

    void UpdateCoins(int currentCoins)
    {
        coinCounter.gameObject.GetComponent<Text>().text = currentCoins.ToString();
    }

    private void OnDisable()
    {
        scr_Player.PlayerWasDamaged -= UpdateHPBar;
        scr_Player.PlayerGotACoin -= UpdateCoins;
    }
}
