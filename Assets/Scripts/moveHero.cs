using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHero : MonoBehaviour
{

    public bool faceRight = true;
    public Transform heroT;
    public Rigidbody2D heroRB;
    public float speed = 4.5f;
    public float force = 10f;
    public Animator animator;
    public bool jumpReady = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) && !faceRight){
            flipHero();
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && faceRight){
            flipHero();
        }

        moveHeroCheck();
        jumpHeroCheck();
    }

    void flipHero(){
        faceRight = !faceRight;

        Vector3 scale = heroT.localScale;
        scale.x *= -1;
        heroT.localScale = scale;
    }

    void moveHeroCheck(){
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
            startWalkingAnimation();
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
            startWalkingAnimation();
        } 
        else {
            stopWalkingAnimation();
        }
    }

    void startWalkingAnimation(){
        animator.SetBool("walking", true);
        animator.SetBool("idle", false);
    }

    void stopWalkingAnimation(){
        animator.SetBool("walking", false);
        animator.SetBool("idle", true);
    }

    void startJumpAnimation(){
        animator.SetBool("jumping", true);
        animator.SetBool("walking", false);
        animator.SetBool("idle", false);
    }

    void stopJumpAnimation(){
        animator.SetBool("jumping", false);
    }

    void jumpHeroCheck(){
        if(Input.GetKeyDown(KeyCode.Space) && jumpReady == true){
            startJumpAnimation();
            heroRB.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D floor){
        if(floor.gameObject.CompareTag("chao")){
            jumpReady = true;
            stopJumpAnimation();
        }
    }

    void OnCollisionExit2D(Collision2D floor){
        if(floor.gameObject.CompareTag("chao")){
            jumpReady = false;
        }
    }
}
