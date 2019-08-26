using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHero : MonoBehaviour
{

    public bool faceRight = true;
    public Transform heroT;
    public Rigidbody2D heroRB;
    public float speed = 3.15f;
    public float force = 6.5f;
    public Animator animator;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            if(!faceRight)
                flipHero();
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            if(faceRight)
                flipHero();
        }

        float moveHero = Input.GetAxisRaw("Horizontal");
        heroRB.velocity = new Vector2(moveHero * speed, heroRB.velocity.y);

        if(moveHero == 0){
            animator.SetBool("isWalking", false);
        }
        else{
            animator.SetBool("isWalking", true);
        }

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
            heroRB.velocity = Vector2.up * force;
            animator.SetTrigger("takeOff");
        }

        if(isGrounded == true){
            animator.SetBool("isJumping", false);
        }
        else{
            animator.SetBool("isJumping", true);
        }
    
    }

    void flipHero(){
        faceRight = !faceRight;

        Vector3 scale = heroT.localScale;
        scale.x *= -1;
        heroT.localScale = scale;
    }


    void OnCollisionEnter2D(Collision2D floor){
        if(floor.gameObject.CompareTag("chao")){
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D floor){
        if(floor.gameObject.CompareTag("chao")){
            isGrounded = false;
        }
    }
}
