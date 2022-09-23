using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IPickable
{
    public string keyColour;
    public void StartInteraction()
    {
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.75f);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void StopInteraction()
    {
        this.gameObject.transform.parent = null;
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        //�������� �������� ������
    }
}
