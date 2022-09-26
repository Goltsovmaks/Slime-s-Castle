using UnityEngine;

public class Key : MonoBehaviour, IPickable
{
    public string keyColour;
    public void StartInteraction()
    {
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.75f);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void StopInteraction()
    {
        gameObject.transform.parent = null;
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }
}
