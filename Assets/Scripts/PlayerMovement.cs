using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public Animator animator;
  
    private Rigidbody2D rb;
     public bool isGrounded;
    private BoxCollider2D coll;
    float distToGround;

    public AudioSource jumpSound;
    public AudioSource deathSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f,2.0f,0.0f);
        coll = GetComponent<BoxCollider2D>();
        
        
    }
    void OnCollisionStay2D()
         {
             isGrounded = true;
         }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetBool("Jump",true);
            jumpSound.Play();
            
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
           
            isGrounded = false;
            
        }
        if(isGrounded == true){
        animator.SetBool("Jump",false);
        
        }
    }
     IEnumerator ExecuteAfterTime(float time)
 {
     yield return new WaitForSeconds(time);
 
             
             Destroy(rb.gameObject);
             
 }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Spike"))
        {    Time.timeScale=0;
           deathSound.Play();
          
            StartCoroutine(ExecuteAfterTime(2));
        }
    }
    
}
