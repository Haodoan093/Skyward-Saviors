using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private CharacterController charCtrl;

    public Rigidbody2D rb;
    private bool canMove;
    private bool canJump;
    private float direction = 1;
    private bool isRolling;
    private bool isJumping;
    public LayerMask layerMask;


    public Rigidbody2D Rigidbody { get => rb; set => rb = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public bool CanJump { get => canJump; set => canJump = value; }
    public float Direction { get => direction; set => direction = value; }
    public bool CanMove { get => canMove; set => canMove = value; }

    public bool OnGround
    {
        get
        {
            var bounds = charCtrl.Collider.bounds;
            return Physics2D.OverlapCapsule(new Vector2(bounds.center.x, bounds.min.y),
            new Vector2(bounds.size.x, 0.1f),
            CapsuleDirection2D.Horizontal, 0, layerMask);
        }
    }

    public bool IsRolling { get => isRolling; set => isRolling = value; }

    private void Awake()
    {
        CanMove = true;
        CanJump = true;
        layerMask = LayerMask.GetMask("Ground");
        charCtrl = transform.parent.GetComponent<CharacterController>();
        rb = charCtrl.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var dir = Input.GetAxisRaw("Horizontal");
        if (dir != 0) direction = dir;
        Move(dir);
        FlipX(direction);
    }


    public void Move(float dir)
    {
        if (!CanMove || (!OnGround && dir == 0) || isRolling) return;
        rb.velocity = new Vector2(dir * moveSpeed, rb.velocity.y);
    }

    public void Stop()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, force);
    }

    private void FlipX(float dir)
    {
        if (dir != 0)
        {
            var model = charCtrl.Model;
            var localScale = model.localScale;
            model.localScale = new Vector3(Mathf.Abs(localScale.x) * dir, localScale.y, localScale.z);
        }
    }
}