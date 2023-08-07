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

    public Rigidbody2D Rigidbody { get => rb; set => rb = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public bool CanJump { get => canJump; set => canJump = value; }

    private void Awake()
    {
        canMove = true;
        CanJump = true;
        charCtrl = transform.parent.GetComponent<CharacterController>();
        rb = charCtrl.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var direction = Input.GetAxisRaw("Horizontal");
        Move(direction);
        FlipX(direction);
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