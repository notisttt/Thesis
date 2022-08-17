using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthAndAttack : MonoBehaviour
{
    public float Timer;
    public SkeletonAI skeletonAI;
    public WildBoarAI wildboarAI;
    public BearAI bearAI;
    public GiantAI giantAI;

    Animator m_Animator;

    public LayerMask WhatIsSkeleton; 
    public LayerMask WhatIsWildBoar;
    public LayerMask WhatIsBear;
    public LayerMask WhatIsGiant;

    public float PlayerHealth;    //h zwi tou paikti kai poso damage trwei apo hits
    public float Resistance;
    public float Regeneration;
    public float MaxHealth;
    public float Damage;

    public float SkelHitRange;
    public bool InSkelHitRange;

    public float WilBHitRange;
    public bool InWilBHitRange;

    public float BearHitRange;
    public bool InBearHitRange;

    public float GiantHitRange;
    public bool InGiantHitRange;
    
    
   

 void Start(){

        m_Animator = GetComponent<Animator> ();
                                                                   

    }


  void FixedUpdate(){
    
    if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

   else {     
   if(PlayerHealth < MaxHealth) {

   PlayerHealth += Regeneration;

   }
    else {    
        
        Timer = 60;
    }

   }

     InSkelHitRange = Physics.CheckSphere(transform.position, SkelHitRange, WhatIsSkeleton);
     InWilBHitRange = Physics.CheckSphere(transform.position, WilBHitRange, WhatIsWildBoar);
     InBearHitRange = Physics.CheckSphere(transform.position, BearHitRange, WhatIsBear);
     InGiantHitRange = Physics.CheckSphere(transform.position, GiantHitRange, WhatIsGiant);
     


    
      
     


    

     if (Input.GetMouseButtonDown(0)){

           m_Animator.SetTrigger ("IsAttacking");

         DamageEnemies();

     }



}

void DamageEnemies(){

    if(InSkelHitRange){

        skeletonAI.TakeDamage();
    }

    if(InWilBHitRange){

        wildboarAI.TakeDamage();
    }

    if(InBearHitRange){

        bearAI.TakeDamage();
    }

    if(InGiantHitRange){

        giantAI.TakeDamage();
    }



}

void OnCollisionEnter(Collision EnemyCollision){

   
           
        if (EnemyCollision.gameObject.tag == "Skeletons")
    { 

    skeletonAI = EnemyCollision.gameObject.GetComponent<SkeletonAI>();
   
                                               
     }

     else if (EnemyCollision.gameObject.tag == "WildBoars"){

        wildboarAI = EnemyCollision.gameObject.GetComponent<WildBoarAI>();
     }



     else if (EnemyCollision.gameObject.tag == "Bear"){

        bearAI = EnemyCollision.gameObject.GetComponent<BearAI>();
     }


      else if (EnemyCollision.gameObject.tag == "Giant")
    { 

    giantAI = EnemyCollision.gameObject.GetComponent<GiantAI>();
   
                                               
     }

}


 public void GetHit()
    {
        
        PlayerHealth -= Resistance;     //afti i methodos elegxei to ti ginetai otan ena NPC xtypisei ton paikti
 
        if (PlayerHealth <= 0) Invoke(nameof(ReturnMainMenu), 0.5f);     
    }
    private void ReturnMainMenu()           //afti i methodos elegxei to ti ginetai otan o paiktis pethanei
    { 
        SceneManager.LoadScene(0);
    }




}
