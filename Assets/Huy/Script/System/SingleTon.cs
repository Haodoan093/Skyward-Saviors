using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleTon : HuyMonoBehaviour
{
    [SerializeField] protected static SingleTon instance;
    public static SingleTon Instance;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        if (instance != null) return;
        instance = this;
    }
}
