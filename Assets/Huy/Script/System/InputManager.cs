using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : HuyMonoBehaviour
{
    [SerializeField] protected float horizontal;
    [SerializeField] protected float vertical;

    public float Horizontal => horizontal;
    public float Vertical => vertical;

    [SerializeField] private static InputManager instance;
    public static InputManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected override void Update()
    {
        base.Update();
        this.GetAxisInput();
    }

    protected virtual void GetAxisInput()
    {
        this.horizontal = Input.GetAxis("Horizontal");
        this.vertical = Input.GetAxis("Vertical");
    }
}
