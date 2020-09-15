using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  System;


public class Robot : MonoBehaviour {

    public Rigidbody2D robot;

    public SpriteRenderer YourSprite;

    public Rigidbody2D rival;
    
    Animator robotAnimation;

    // здоровье
    public Slider YourHealthSlider;

    public int YourHealth;


    // атаки

    private float CoolDownAttack, CoolDownStepAttack, CoolDownBodyAttack, CoolDownLaserAttack;
    public float CDAttack, CDStepAttack, CDBodyAttack, CDLaserAttack;

    public int AttackDamage, LegDamage, BodyDamage, SuperDamage;

    public GameObject attack, stepAttack, bodyAttack, laserAttack;

    public GameObject youWin, youLose;

    

    public float horizontalSpeed;
    float speedX;
    [SerializeField]
    private float distance;



    // противник

    public Slider RivalHealthSlider;
    public int RivalHealth;
    public GameObject rivalRobot;
    public Animator RAnimation;

    public float RSpeed;

    //атаки

    private float CoolDownRivalAttack, CoolDownRivalSuperAttack, CoolDownRivalLegAttack;
	public float CDRAttack, CDRSuperAttack, CDRLegAttack;

    public int RAttackDamage, RLegDamage, RSuperDamage;

    void Start ()
    {
        robot = GetComponent<Rigidbody2D>();
        robotAnimation = GetComponent<Animator>();

        YourSprite.color = Color.blue;
        
	}
	
    private void CoolDown()
    {
        if (CoolDownAttack > 0)
            CoolDownAttack -= Time.deltaTime;
        else
            attack.SetActive(true);

        if (CoolDownBodyAttack > 0)
            CoolDownBodyAttack -= Time.deltaTime;
        else
            bodyAttack.SetActive(true);

        if (CoolDownLaserAttack > 0)
            CoolDownLaserAttack -= Time.deltaTime;
        else
            laserAttack.SetActive(true);

        if (CoolDownStepAttack > 0)
            CoolDownStepAttack -= Time.deltaTime;
        else
            stepAttack.SetActive(true);

    }


    public void Update()
    {
        RivalHealthSlider.value = RivalHealth;
        CoolDown();
        RivalCoolDown();

        

        YourHealthSlider.value = YourHealth;


        distance = robot.position.x - rival.position.x;

        if (RivalHealth <= 0)
        {
            Invoke("GameEndWin", 0.1f);
            Invoke("LoadMenu", 2f);
            
        }
            
        if (YourHealth <= 0)
        {
            Invoke("GameEndLose", 0.1f);
            Invoke("LoadMenu", 2f);
            
        }
            
        
    }


    public void FixedUpdate ()
    {
        robot.transform.Translate(speedX, 0, 0);
        /*if ((CoolDownRivalAttack > 0) && (CoolDownRivalLegAttack > 0) && (CoolDownLaserAttack > 0))
            rival.transform.Translate(-RSpeed, 0, 0);
        else*/
            RivalAttacker();

    }

    private void setIdle()
    {
        robotAnimation.SetInteger("Walk", 0);
    }

    public void Jump()
    {
        if (robot.velocity.y == 0)
        {
            robot.AddForce(transform.up * 6f, ForceMode2D.Impulse);
            robotAnimation.SetInteger("Walk", 8);
            Invoke("setIdle", 0.9f);
        }
    }

    public void GoLeft()
    {
        speedX = -horizontalSpeed;
        robotAnimation.SetInteger("Walk", 2);

    }

    public void GoRight()
    {
         speedX = horizontalSpeed;
        robotAnimation.SetInteger("Walk", 1);
    }  
        
    public void Stop()
    {
        speedX = 0;
        robotAnimation.SetInteger("Walk", 0);
    }

    public void RStop()
    {
	    RAnimation.SetInteger("Rival", 0);
    }
	

    


    public void Attack()
    {
        if ((CoolDownAttack <= 0) && (distance > -3.7))
        {
            robotAnimation.SetInteger("Walk", 3);

            RivalHealth -= AttackDamage;

            CoolDownAttack = CDAttack;

            attack.SetActive(false);
            
        }



    }

    public void StepAttack()
    {
        if (CoolDownStepAttack <= 0 && distance > -3.3)
        {
            robotAnimation.SetInteger("Walk", 4);


            RivalHealth -= LegDamage;

            CoolDownStepAttack = CDStepAttack;

            stepAttack.SetActive(false);
        }
    }

    public void BodyAttack()
    {
        if (CoolDownBodyAttack <= 0 && distance > -3.7)
        {

            robotAnimation.SetInteger("Walk", 5);

            RivalHealth -= BodyDamage;

            CoolDownBodyAttack = CDBodyAttack;

            bodyAttack.SetActive(false);
        }
    }

    public void LaserAttack()
    {
        if (CoolDownLaserAttack <= 0 && distance > -8.4)
        {
            robotAnimation.SetInteger("Walk", 6);

            RivalHealth -= SuperDamage;

            CoolDownLaserAttack = CDLaserAttack;

            laserAttack.SetActive(false);
        }
    }

   
    public void RivalAttacker()
    {

        if
            ( CoolDownRivalAttack > 0 && CoolDownRivalLegAttack > 0 & CoolDownRivalSuperAttack > 0 )
            rival.transform.Translate(RSpeed, 0, 0);
        else
            rival.transform.Translate(-RSpeed, 0, 0);
            

        
            RSuperAttack();
            Invoke("RAttack", 2);
            Invoke("RLegAttack", 3);

        

        



    }

   
    private void RivalCoolDown()
    {
        if (CoolDownRivalAttack > 0)
            CoolDownRivalAttack -= Time.deltaTime;
        
        if (CoolDownRivalSuperAttack > 0)
            CoolDownRivalSuperAttack -= Time.deltaTime;
       

        if (CoolDownRivalLegAttack > 0)
            CoolDownRivalLegAttack -= Time.deltaTime;
        

    }


    

    public void RAttack()
        {
	       if ((CoolDownRivalAttack <= 0) && (distance > -3.3))
        {
            RAnimation.SetInteger("Rival", 2);

            YourHealth -= RAttackDamage;

            CoolDownRivalAttack = CDRAttack;
        }
        }

        public void RSuperAttack()
        {
        if ((CoolDownRivalSuperAttack <= 0) && (distance > -8.4))

        {
            RAnimation.SetInteger("Rival", 1);

            YourHealth -= RSuperDamage;

            CoolDownRivalSuperAttack = CDRSuperAttack;
        }
        }

    public void RLegAttack()
    {
        if((CoolDownRivalLegAttack <= 0) && (distance > -3.3) && (robot.velocity.y == 0))
        {
            RAnimation.SetInteger("Rival", 3);

            YourHealth -= RLegDamage;

            CoolDownRivalLegAttack = CDRLegAttack;
        }
    }

    public void GameEndWin()
    {
        RAnimation.SetInteger("Rival", 4);

        youWin.SetActive(true);

        
    }   
    
    public void GameEndLose()
    {
        robotAnimation.SetInteger("Walk", 7);

        youLose.SetActive(true);
        
        




    }

    private void LoadMenu()
    {
        Application.LoadLevel("MainMenu");
    }

   

   
}
