using System.Collections;
using System.Collections.Generic;    //ta namespaces
using UnityEngine;
using UnityEngine.AI;
public class GiantAI : MonoBehaviour  
{
    public PlayerHealthAndAttack playerhealthandattack;  //afti i metavliti einai gia to PlayerHealthAndAttack script
                                 //afti i metavliti einai gia to gameobject tou paikti
    public NavMeshAgent NavAgent;                         //To AI twn NPC
    
    Animator m_Animator;

    public GameObject Giant;
    public GameObject Player;

    public Transform PlayerLoc;                            //oi syntentagmenes tou paikti

    public LayerMask WhatIsGround, WhatIsPlayer;           //layermasks
    
     public float health;                                   //i zwi tou npc
     public float damage;
     public float playerHealth;
     public float maxHealth;
     public float regen;

    public Vector3 WalkPoint;  
    bool WalkPointSet;                //metavlites gia tin katefthinsi twn npc        
    public float WalkPointRange;
    public bool running;

    public float AttackSpeed;         //metavlites gia tis epitheseis twn npc
    bool PlayerHit;    

    public float DespawnTimer; 

public float SightRange, AttackRange;
public bool  InSightRange, InAttackRange;    //metavlites gia tis kiniseis twn npc

public bool Dead;

 void Awake(){             //i awake kaleitai einai i prwti methodos pou kaleitai sto game 
 
    playerhealthandattack = GameObject.Find("Player").GetComponent<PlayerHealthAndAttack>();                 //afto pernei to playerhealthandattack script apo to player gameobject
    damage = Player.GetComponent<PlayerHealthAndAttack>().Damage;
    playerHealth = Player.GetComponent<PlayerHealthAndAttack>().PlayerHealth;
    maxHealth = Player.GetComponent<PlayerHealthAndAttack>().MaxHealth;
    regen = Player.GetComponent<PlayerHealthAndAttack>().Regeneration;

    
    PlayerLoc = GameObject.Find("Player").transform;               //afto pairnei tis syntetagmenes tou player gameobject
    NavAgent = GetComponent<NavMeshAgent>();                            //afto pairnei to navmesh, diladi to pou mporei na perpatisei to npc    

 }

   
 void Start(){
        m_Animator = GetComponent<Animator> ();

      
                                                                   

    }


  
    void Update()           //i update kaleitai kathe frame
    {
        InSightRange = Physics.CheckSphere(transform.position, SightRange, WhatIsPlayer);        //to an mporei to npc na dei ton paikti
         InAttackRange = Physics.CheckSphere(transform.position, AttackRange, WhatIsPlayer);     //to an to npc mporei na epitethei ston paikti
         if (!InSightRange && !InAttackRange) {
           
          
            Giant.GetComponent<NavMeshAgent>().speed = 35f;
            Patrolling();

         }
         if (InSightRange && !InAttackRange) {
          
          
                                                                                                //ifs gia to an mporei na dei/epitethei ton paikti i oxi
            Chase();

         }
         if (InSightRange && InAttackRange) {
         

           Giant.GetComponent<NavMeshAgent>().speed = 35f;
         
         Attack();

       }

                   if(DespawnTimer > 0){
        
        DespawnTimer -= Time.deltaTime;

       }
       else if(DespawnTimer <= 0 && health > 0){

        DespawnTimer = 600;
       }

       else {
      
      DespawnCorpse();

       }
    }


     private void Patrolling(){

     if (!WalkPointSet) {
                                               //ti kanei to npc otan den vlepei ton paikti
        SearchWalkPoint();
      }

      if (WalkPointSet){

        NavAgent.SetDestination(WalkPoint);
      }

      Vector3 DistanceToWalkPoint = transform.position - WalkPoint;

      if (DistanceToWalkPoint.magnitude <1f){

        WalkPointSet = false;
        running = false;
      }
    }                

    private void SearchWalkPoint(){
    
    float RandomZ = Random.Range(-WalkPointRange, WalkPointRange);
     float RandomX = Random.Range(-WalkPointRange, WalkPointRange);
     WalkPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);
     if (Physics.Raycast(WalkPoint, -transform.up, 2f, WhatIsGround)){                                                   //kwdikas gia to pws perpataei to npc
     WalkPointSet = true;
     running = false;

      m_Animator.SetBool ("IsMoving", WalkPointSet);
     
      }
    }

    private void Chase(){
    NavAgent.SetDestination(PlayerLoc.position);                    //kwdikas gia to pws kynigaei ton paikti to npc
    running = true;
    WalkPointSet = false;
    m_Animator.SetBool ("IsRunning", running);
    Giant.GetComponent<NavMeshAgent>().speed = 52f;
  
    }

    private void Attack(){

        NavAgent.SetDestination(transform.position);              //kwdikas gia to pws epitithetai ton paikti

        transform.LookAt(PlayerLoc);
        
        if(!PlayerHit){

            PlayerHit = true;                                                                                  
            m_Animator.SetTrigger ("IsAttacking");
            playerhealthandattack.GetHit();
            Invoke(nameof(ResetAttack), AttackSpeed);
             
       

        }
    }

    public void ResetAttack(){
        
        PlayerHit = false;
    }
    
    public void TakeDamage()
    {
        health -= damage;

        if (health <= 0) {
          Dead = true;
        Player.GetComponent<PlayerHealthAndAttack>().Damage += damage;
        Player.GetComponent<PlayerHealthAndAttack>().PlayerHealth += playerHealth;
        Player.GetComponent<PlayerHealthAndAttack>().MaxHealth += maxHealth;
        Player.GetComponent<PlayerHealthAndAttack>().Regeneration += regen;
                                                               
        m_Animator.SetBool ("IsDead", Dead);
           Invoke(nameof(Death), 0.5f);  
           
            }            //kwdikas gia to pws trwei damage kai pethainei to npc

            else {
              Dead = false;
            }
    }
    private void Death()
    {
       Giant.GetComponent<NavMeshAgent>().enabled = false;
       Giant.GetComponent<BoxCollider>().enabled = false;
       WalkPointRange = 0;
       SightRange = 0;
       AttackSpeed = 999;

 
     
    }

    private void DespawnCorpse(){

      Destroy(gameObject);
    }
}
