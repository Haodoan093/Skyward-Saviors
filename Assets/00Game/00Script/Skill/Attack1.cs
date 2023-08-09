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
        if (charCtrl.movement.OnGround && charCtrl.movement.Rigidbody.velocity.x != 0) return;
        base.Use();
        charCtrl.Animator.SetTrigger("Attack" + (combo + 1));
        canAttack = true;
        charCtrl.movement.CanMove = false;
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
        charCtrl.movement.CanMove = true;
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