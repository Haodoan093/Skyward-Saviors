using UnityEngine;

public class Attack1 : Skill
{
    public int combo;
    public bool canAttack;

    override protected void Awake()
    {
        base.Awake();
        key = KeyCode.L;
    }

    override protected void Start()
    {

    }

    protected override void Use()
    {
        base.Use();
        charCtrl.Animator.SetTrigger("Attack" + (combo + 1));
        canAttack = true;
    }

    public void StartCombo()
    {
        canAttack = false;
        if (combo < 3)
        {
            combo++;
        }
    }

    public void FinishAni()
    {
        canAttack = false;
        combo = 0;
        state = SkillState.Cooldown;
    }

    protected override void OnActive()
    {
        base.OnActive();
        if (Input.GetKeyDown(key) && !canAttack)
        {
            canAttack = true;
            charCtrl.Animator.SetTrigger("Attack" + (combo + 1));
        }
    }

}