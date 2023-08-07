using UnityEngine;

public enum CharacterState
{
    Idle,
    Run,
    Jump,
    Fall,
    Defend,
    Hit,
    Roll,
    Death
}

public class CharacterController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sprite;
    public CharacterMovement movement;
    public Transform model;

    public SpriteRenderer Sprite { get => sprite; set => sprite = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public CharacterMovement Movement { get => movement; set => movement = value; }
    public Transform Model { get => model; set => model = value; }

    private void Awake()
    {
        model = transform.Find("Model");
        animator = model.GetComponent<Animator>();
        sprite = model.GetComponent<SpriteRenderer>();
        movement = transform.Find("Movement").GetComponent<CharacterMovement>();
    }
}