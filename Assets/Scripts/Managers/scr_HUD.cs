using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_HUD : MonoBehaviour
{
    public GameObject[] HPbar = new GameObject[3];

    private void Awake()
    {
        scr_Player.PlayerWasDamaged += UpdateHPBar;
        scr_Player.PlayerGotACoin += UpdateCoins;

        for (int i = 0; i < HPbar.Length; i++)
        {
            HPbar[i] = transform.GetChild(0).GetChild(i).gameObject;
        }
    }

    void UpdateHPBar(int currentHealth)
    {
        for (int i = 0; i < HPbar.Length; i++)
        {
            if (i < currentHealth)
            {
                HPbar[i].SetActive(true);
            }
            else
            {
                HPbar[i].SetActive(false);
            }
        }
    }

    void UpdateCoins(int currentCoins)
    {
        transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = currentCoins.ToString();
    }

    private void OnDisable()
    {
        scr_Player.PlayerWasDamaged -= UpdateHPBar;
        scr_Player.PlayerGotACoin -= UpdateCoins;
    }
}
