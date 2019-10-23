using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public int flag = 1;
    Rigidbody2D rb;
    private bool isGrounded = false;
    public float jumpForce = 1.0F;
    public bool isLookingLeft;
    private float x;
    public Animator charAnimator;

    private SpriteRenderer sprite;
    public Quaternion rotation = Quaternion.identity;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        charAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }
    private void Start()
    {
        transform.GetChild(0).transform.SetParent(null);



    }
    private void FixedUpdate()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isGrounded = false;
            Jump();
            charAnimator.SetInteger("Run", 2);
        }
        if (Input.GetButton("Horizontal"))
        {
            Run();
            if (isGrounded == true)
            charAnimator.SetInteger("Run", 1);
        }
        else
        {
            if (isGrounded == true)
                charAnimator.SetInteger("Run", 0);
        }





        if (x < 0 && !isLookingLeft)
            TurnTheRat();
        if (x > 0 && isLookingLeft)
            TurnTheRat();
    }
    private void Jump()
    {
        flag++;
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    private void Run()
    {
        x = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(x * speed, rb.velocity.y, 0f);
        rb.velocity = move;
        //sprite.flipX = move.x < 0.0f;
        //Vector3 move = Vector3.right * Input.GetAxis("Horizontal");
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + move, speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        charAnimator.SetInteger("Run", 0);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

    void TurnTheRat()
    {
        //смена переменной показывающей направление взгляда на обратное значение
        isLookingLeft = !isLookingLeft;
        //поворот крысы через инвертацию размера по оси х
        //transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        //transform.Rotate(0, 180, 0);


        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y-180, transform.eulerAngles.z);


    }

}
