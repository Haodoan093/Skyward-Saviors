using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HuyMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();
    }

    protected virtual void Awake()
    {
        this.LoadComponent();
    }

    protected virtual void LoadComponent()
    {
        //ForOverride
    }

    protected virtual void ResetValue()
    {
        //ForOverride
    }

    protected virtual void Update()
    {
        //ForOverride
    }

    protected virtual void FixedUpdate()
    {
        //ForOverride
    }

    protected virtual void Start()
    {
        //ForOverride
    }
}
