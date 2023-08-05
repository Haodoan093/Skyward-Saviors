using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PLAYER_STATE {
    Idle,
    Run,
    Jump,
    Defend,
    Take_Hit,
    Roll,
    Death
}

public class PlayerController : MonoBehaviour

{
    [SerializeField] float _speed,_HP,_armor,_damge;
    Rigidbody2D _rigi;
    Vector2 _movement;
    [SerializeField] float _jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Defend();
       


    }
    void Move()
    {
        _movement = Vector2.zero;
        _movement.x = Input.GetAxisRaw("Horizontal") * _speed;
        _movement.y = _rigi.velocity.y;
    }
    private void FixedUpdate()
    {
        _rigi.velocity = _movement;
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        _rigi.AddForce(new (0, _jumpForce));
    }
    void Defend()
    {
        if (Input.GetKeyDown(KeyCode.S))
            _rigi.AddForce(new(0, _jumpForce));
    }

}
