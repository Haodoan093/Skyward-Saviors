using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : HuyMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected int jumpHeight = 1;
    [SerializeField] protected float fallMultiplier;
    [SerializeField] protected Vector2 vecGravity;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float jumpTimeCounter;
    [SerializeField] protected float jumpTime;
    public bool isJumping;
    public bool isGrounded;
    public LayerMask groundLayer;

    protected override void Start()
    {
        base.Start();
        this.vecGravity = new Vector2(0, -Physics2D.gravity.y);
        this.jumpTime = 1f;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected override void Update()
    {
        base.Update();
        this.isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.9f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        this.Jumping();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", transform.gameObject);
    }

    protected virtual void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.isGrounded)
        {
            this.Jump();
            isJumping = true;
            this.jumpTimeCounter = this.jumpTime;
        }

        if (this.playerCtrl.Rb.velocity.y < 0)
        {
            this.playerCtrl.Rb.velocity -= this.vecGravity * fallMultiplier * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (this.jumpTimeCounter > 0)
            {
                this.Jump();
                this.jumpTimeCounter -= 5 * Time.deltaTime;
            }
            else
            {
                this.isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.isJumping = false;
        }
    }

    public virtual void Jump()
    {
        this.playerCtrl.Rb.velocity = new Vector2(playerCtrl.Rb.velocity.x, jumpHeight);
    }
}
