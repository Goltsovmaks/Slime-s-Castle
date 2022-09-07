using UnityEngine;

[ExecuteInEditMode]
public class scr_SpriteOutline : MonoBehaviour {
    public Color color = Color.white;

    private SpriteRenderer spriteRenderer;

    void OnEnable() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // UpdateOutline(true);
    }

    void OnDisable() {
        UpdateOutline(false);
    }

    void Update() {
        // UpdateOutline(true);
    }

    void UpdateOutline(bool outline) {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", color);
        spriteRenderer.SetPropertyBlock(mpb);
    }

    private void OnTriggerEnter2D(Collider2D colider) {
        if (colider.CompareTag("Player"))
        {
            UpdateOutline(true);
        }
    }

    private void OnTriggerExit2D(Collider2D colider) {
        if (colider.CompareTag("Player"))
        {
            UpdateOutline(false);
        }
    }



}