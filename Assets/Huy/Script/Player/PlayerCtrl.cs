using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
    idle,
    run,
    jump,
    fall
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerCtrl : HuyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected CapsuleCollider2D bodyCollider;
    public CapsuleCollider2D BodyCollider => bodyCollider;

    public float speed = 200f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody2D>();
        this.rb.isKinematic = false;
        Debug.Log(transform.name + ": LoadComponent", transform.gameObject);
    }

    protected virtual void LoadCollider()
    {
        if(this.bodyCollider != null) return;
        this.bodyCollider = GetComponent<CapsuleCollider2D>();
        this.bodyCollider.isTrigger = false;
        Debug.Log(transform.name + ": LoadCollider", transform.gameObject);
    }
}
