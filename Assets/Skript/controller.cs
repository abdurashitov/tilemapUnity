using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float playerSpeed;
    public float jumpPower;
    public int directionInput;
    public bool groundCheck;
    public bool facingRight = true;
    public bool isLookingLeft;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        if ((directionInput < 0) && (facingRight))
        {
            TurnTheRat();
        }

        if ((directionInput > 0) && (!facingRight))
        {
            TurnTheRat();
        }
        groundCheck = true;
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(playerSpeed * directionInput, rb2d.velocity.y);
    }

    public void Move(int InputAxis)
    {

        directionInput = InputAxis;

    }

    public void Jump(bool isJump)
    {
        isJump = groundCheck;

        if (groundCheck)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    void TurnTheRat()
    {
        //смена переменной показывающей направление взгляда на обратное значение
        isLookingLeft = !isLookingLeft;
        //поворот крысы через инвертацию размера по оси х
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

}
