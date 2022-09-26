using UnityEngine;

public abstract class scr_cnpt_Form_Abstract: MonoBehaviour
{
    public scr_cnpt_FormBehavior formBehavior;
    public static bool holdSkillisActive;
    public static bool isGrounded;
    protected float overlapRadius = 0.07f;
    public float lightIntensity = 0.5f;
    public Sprite sprite;

    public virtual void Move(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed, 
        float movementSmoothing)
    {
        rb.gravityScale = 0.65f;
        Vector2 targetVelocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y);
        Vector2 velocity = Vector2.zero;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 
            movementSmoothing);

        isGrounded = CheckIfOverlap(rb.transform.GetChild(2).transform, overlapRadius, 
            LayerMask.GetMask("Platforms"));
    }

    public virtual void Jump(Rigidbody2D rb, float jumpPower)
    {
        bool isGrounded = CheckIfOverlap(rb.transform.GetChild(2).transform, overlapRadius, 
            LayerMask.GetMask("Platforms"));

        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    public virtual void StopUsingCurrentForm()
    {

    }

    public virtual void Skill_1()
    {

    }

    public virtual void Skill_2()
    {

    }

    protected bool CheckIfOverlap(Transform checker, float radius, LayerMask mask)
    {
        return Physics2D.OverlapCircleAll(checker.position, radius, mask).Length != 0;
    }
    protected bool CheckIfOverlap(Transform[] checkers, float radius, LayerMask mask)
    {
        bool isOverlap = false;

        foreach (var checker in checkers)
        {
            isOverlap = isOverlap || Physics2D.OverlapCircleAll(checker.position, 
                radius, mask).Length != 0;
        }
        return isOverlap;
    }

    protected Collider2D[] GetInteractableObjects(Transform checker, float radius, LayerMask mask)
    {
        return Physics2D.OverlapCircleAll(checker.position, radius, mask);
    }
}
