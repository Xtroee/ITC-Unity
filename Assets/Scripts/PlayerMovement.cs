using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator tAnimator;
    [SerializeField] private float XInput;

    [SerializeField] private float XMoveSpeed;
    [SerializeField] private float JumpForce;

    [SerializeField] private SpriteRenderer tSpriteRenderer;

    [SerializeField] private Transform rayTransform;
    [SerializeField] private LayerMask targetMask;

    private Rigidbody2D tRb;
    private bool bIsGrounded;
    private bool isLastOnRight;

    private void Start()
    {
        tRb = GetComponent<Rigidbody2D>();
        isLastOnRight = true;
    }

    public void SetXInput(float val)
    {
        XInput = val;

        if (XInput > 0 || XInput < 0)
        {
            isLastOnRight = XInput > 0;
            tAnimator.SetBool("Move", true);
        }
        else
        {
            tAnimator.SetBool("Move", false);
        }
    }

    private void Update()
    {
        tSpriteRenderer.flipX = !isLastOnRight;
    }
    private void FixedUpdate()
    {
        tRb.linearVelocityX = XInput * XMoveSpeed;
    }

    public void ApplyJump()
    {
        if (bIsGrounded == false) return;

        tRb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

        tAnimator.SetTrigger("Jump");
    }

    public void ApplyAttacking()
    {
        tAnimator.SetTrigger("Attacking");
        Vector2 direction = isLastOnRight ? Vector2.right : Vector2.right * -1;

        RaycastHit2D isHit = Physics2D.Raycast(rayTransform.position, direction, 1, targetMask);
        Debug.DrawRay(rayTransform.position, direction * 1, Color.red, 100);
        if (isHit.collider != null) 
        {
            Debug.Log("Hit Name : " + isHit.collider.name);
            enemyMovement hitEnemy = isHit.collider.GetComponentInParent<enemyMovement>();
            

            if (hitEnemy != null)
            {
                Destroy(hitEnemy.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            bIsGrounded = true;
            tAnimator.SetBool("IsGround", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            bIsGrounded = false;
            tAnimator.SetBool("IsGround", false);
        }
    }
}
