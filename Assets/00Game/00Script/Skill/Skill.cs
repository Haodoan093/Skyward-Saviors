using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] protected float cooldownTime;
    [SerializeField] protected float activeTime;
    [SerializeField] protected float elapsedCooldownTime;
    [SerializeField] protected float elapsedActiveTime;
    [SerializeField] protected CharacterController charCtrl;

    public enum SkillState { Ready, Active, Cooldown };
    protected SkillState state = SkillState.Ready;
    protected KeyCode key;
    
    protected SkillState State { get => state; set => state = value; }
    protected KeyCode Key { get => key; set => key = value; }
    public float CooldownTime { get => cooldownTime; set => cooldownTime = value; }
    public float ElapsedCooldownTime { get => elapsedCooldownTime; set => elapsedCooldownTime = value; }

    virtual protected void Awake()
    {
        charCtrl = transform.parent.parent.GetComponent<CharacterController>();
    }

    virtual protected void Start()
    {

    }

    virtual protected void Update()
    {
        switch (state)
        {
            case SkillState.Ready:
                {

                    if (Input.GetKeyDown(key))
                    {
                        Use();
                    }
                    break;
                }
            case SkillState.Active:
                {
                    if (activeTime == 0)
                    {
                        OnActive();
                        break;
                    }
                    elapsedActiveTime -= Time.deltaTime;
                    if (elapsedActiveTime > 0)
                    {
                        OnActive();
                    }
                    else
                    {
                        state = SkillState.Cooldown;
                    }
                    break;
                }
            case SkillState.Cooldown:
                {
                    elapsedCooldownTime -= Time.deltaTime;
                    if (elapsedCooldownTime <= 0)
                    {
                        state = SkillState.Ready;
                    }
                    break;
                }
        }
    }

    virtual protected void Use()
    {
        state = SkillState.Active;
        elapsedActiveTime = activeTime;
        elapsedCooldownTime = cooldownTime;
        Debug.Log($"use");
    }

    virtual protected void OnActive()
    {

    }
}