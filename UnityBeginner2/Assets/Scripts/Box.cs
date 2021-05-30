using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float jumpForce;
    public bool isUp;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isUp)
        {
            anim.SetTrigger("hit");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        else
        {
            anim.SetTrigger("hit");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
        }
    }
}
