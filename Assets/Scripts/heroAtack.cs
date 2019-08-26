using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroAtack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private float attackCounter = 1;
    public bool isGrounded = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //invoke("resetAttack", startTimeBtwAttack);

        if(timeBtwAttack <= 0){

            if(isGrounded){
                if(Input.GetKeyDown(KeyCode.Z) && attackCounter == 1){
                    animator.SetTrigger("attack");
                    timeBtwAttack = startTimeBtwAttack;
                    attackCounter++;
                }
                else if(Input.GetKeyDown(KeyCode.Z) && attackCounter == 2){
                    animator.SetTrigger("attack2");
                    timeBtwAttack = startTimeBtwAttack;
                    attackCounter++;
                }
                else if(Input.GetKeyDown(KeyCode.Z) && attackCounter == 3){
                    animator.SetTrigger("attack3");
                    timeBtwAttack = startTimeBtwAttack;
                    attackCounter = 1;
                }
            }
            else if(!isGrounded){
                if(Input.GetKeyDown(KeyCode.Z)){
                    animator.SetTrigger("attack");
                    timeBtwAttack = startTimeBtwAttack;
                }
            }
        }
        else{
            timeBtwAttack -= Time.deltaTime;
        }     
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
