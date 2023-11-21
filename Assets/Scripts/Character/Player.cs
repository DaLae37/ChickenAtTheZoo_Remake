using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Rigidbody2D rb;

    [Header("Jump")]
    [SerializeField]
    protected float jumpPower;
    [SerializeField]
    protected bool isJump;

    [Header("Move")]
    [SerializeField]
    protected int direction;
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        ResetFields();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isJump && Input.GetAxis("Jump") != 0)
        {
            Jump();
        }
        if(Input.GetAxis("Horizontal") != 0)
        {
            Move((Input.GetAxis("Horizontal") < 0 ? -1 : 1));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            isJump = false;
        }
    }

    public void ResetFields()
    {
        direction = 1;
        rb = GetComponent<Rigidbody2D>();
        isJump = false;
        isMove = false;
    }

    protected void Jump()
    {
        rb.AddForce(Vector2.up * jumpPower);
        isJump = true;
    }
    
    protected void Move(int direction)
    {
        transform.localScale = new Vector3(direction, 1);
        rb.velocity = (Vector2.left * -1 * moveSpeed * direction);
    }
}
