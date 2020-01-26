using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Bird : MonoBehaviour 
{
    public float upForce = 200f;                    //Upward force of the "flap".
    private bool isDead = false;            //Has the player collided with a wall?

      private Animator anim;                    
    private Rigidbody2D rb2d;                //Holds a reference to the Rigidbody2D component of the bird.

    void Start()
    {
        anim = GetComponent<Animator> ();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Don't allow control if the bird has died.
        if (isDead == false) 
        {
            //Look for input to trigger a "flap".
            if (Input.GetMouseButtonDown(0)) 
            {
                //...zero out the birds current y velocity before...
                rb2d.velocity = Vector2.zero;
 
                //    new Vector2(rb2d.velocity.x, 0);
                //..giving the bird some upward force.
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
      rb2d.velocity=Vector2.zero;
      isDead = true;
      anim.SetTrigger ("Die");
        // If the bird collides with something set it to dead...
       GameControl.instance.BirdDied(); 
    }
    
}