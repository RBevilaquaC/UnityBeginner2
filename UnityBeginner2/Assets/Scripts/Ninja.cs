using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    private Rigidbody2D rig;

    private Animator anim;

    public float speed;
    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;
    private bool colliding;
    public LayerMask Layer;
    public BoxCollider2D boxCol;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, Layer);

        if (colliding)
        {
            speed = - speed;
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - headPoint.position.y;
            if (height > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5);
                speed = 0;
                anim.SetTrigger("die");
                boxCol.enabled = false;
                Destroy(gameObject, 0.4f);
            }
        }
    }
    
}
