using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHero : MonoBehaviour
{

    public bool faceRight = true;
    public Transform heroT;
    public float speed = 4.5f;
    public Animator animator;

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
}
