using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : HuyMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] 

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponentInParent<PlayerCtrl>();
    }

    protected override void Update()
    {
        base.Update();
        this.CheckMoving();
    }

    protected virtual void Move()
    {
        this.playerCtrl.Rb.velocity = new Vector2(InputManager.Instance.Horizontal * this.playerCtrl.speed * Time.deltaTime, this.playerCtrl.Rb.velocity.y);
    }

    protected virtual void Stop()
    {
        this.playerCtrl.Rb.velocity = new Vector2(0, this.playerCtrl.Rb.velocity.y);
    }

    protected virtual void CheckMoving()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.D))
        {
            this.Move();
        }
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            this.Stop();
        }
    }
}
