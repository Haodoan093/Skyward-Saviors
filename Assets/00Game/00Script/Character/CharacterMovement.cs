using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 500f;
    [SerializeField] private CharacterController charCtrl;

    public Rigidbody2D rb;
    private bool canMove;
    private bool canJump;
    private bool isJumping;
    public LayerMask layerMask;

    public Rigidbody2D Rigidbody { get => rb; set => rb = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public bool CanJump { get => canJump; set => canJump = value; }

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

    private void Awake()
    {
        canMove = true;
        CanJump = true;
        layerMask = LayerMask.GetMask("Ground");
        charCtrl = transform.parent.GetComponent<CharacterController>();
        rb = charCtrl.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var direction = Input.GetAxisRaw("Horizontal");
        Move(direction);
        FlipX(direction);
        Debug.Log($"on ground: {OnGround}");
    }

    private void Move(float direction)
    {
        if (!canMove) return;
        var velocity = rb.velocity;
        rb.velocity = new Vector2(direction * moveSpeed, velocity.y);
    }

    public void Jump(float force)
    {
        rb.AddForce(new Vector2(0, force));

    }

    private void FlipX(float direction)
    {
        if (direction != 0)
        {
            var model = charCtrl.Model;
            var localScale = model.localScale;
            model.localScale = new Vector3(Mathf.Abs(localScale.x) * direction, localScale.y, localScale.z);
        }
    }


}