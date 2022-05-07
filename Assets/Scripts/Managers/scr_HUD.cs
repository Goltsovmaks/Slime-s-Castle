using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_HUD : MonoBehaviour
{
    public GameObject[] HPbar = new GameObject[3];

    private void Awake()
    {
        scr_Player.PlayerWasDamaged += UpdateHPBar;
        for (int i = 0; i < HPbar.Length; i++)
        {
            HPbar[i] = transform.GetChild(i).gameObject;
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

    private void OnDisable()
    {
        scr_Player.PlayerWasDamaged -= UpdateHPBar;
    }
}
