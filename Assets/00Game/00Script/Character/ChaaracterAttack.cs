using UnityEngine;
using System.Collections.Generic;
public class ChaaracterAttack : MonoBehaviour
{
    [SerializeField] private List<Skill> skills;

    private void Awake()
    {
        skills = new List<Skill>();
        var skillList = transform.parent.Find("Skills");
        for (int i = 0; i < skillList.childCount; i++)
        {
            var skill = skillList.GetChild(i).GetComponent<Skill>();
            skills.Add(skill);
        }
    }

    public void Attack1StartCombo()
    {
        Attack1 attack1 = (Attack1)skills[0];
        attack1.StartCombo();
    }
    public void Attack1FinishAni()
    {
        Attack1 attack1 = (Attack1)skills[0];
        attack1.FinishAni();
    }
}