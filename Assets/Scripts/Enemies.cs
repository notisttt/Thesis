using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemies : MonoBehaviour
{
    public NavMeshAgent NavAgent;

    public Transform Player;

    public LayerMask WhatIsGround, WhatIsPlayer;

    

    public Vector3 WalkPoint;  
    bool WalkPointSet;                //Enemy walk paths
    public float WalkPointRange;

    public float AttackSpeed;         //Enemy Attacks
    bool PlayerHit;     

public float SightRange, AttackRange;
public bool  InSightRange, InAttackRange;    //Enemy States


 void Awake(){

    Player = GameObject.Find("Player").transform;
    NavAgent = GetComponent<NavMeshAgent>();

 }

   

  
    void Update()
    {
        InSightRange = Physics.CheckSphere(transform.position, SightRange, WhatIsPlayer);
         InAttackRange = Physics.CheckSphere(transform.position, AttackRange, WhatIsPlayer);
         if (!InSightRange && !InAttackRange) {
            
            Patrolling();

         }
         if (InSightRange && !InAttackRange) {
            
            Chase();

         }
         if (InSightRange && InAttackRange) {
         
         Attack();

       }
    }


     private void Patrolling(){

     if (!WalkPointSet) {
        
        SearchWalkPoint();
      }

      if (WalkPointSet){

        NavAgent.SetDestination(WalkPoint);
      }

      Vector3 DistanceToWalkPoint = transform.position - WalkPoint;

      if (DistanceToWalkPoint.magnitude <1f){

        WalkPointSet = false;
      }
    }                

    private void SearchWalkPoint(){
    
    float RandomZ = Random.Range(-WalkPointRange, WalkPointRange);
     float RandomX = Random.Range(-WalkPointRange, WalkPointRange);
     WalkPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);
     if (Physics.Raycast(WalkPoint, -transform.up, 2f, WhatIsGround)){
     WalkPointSet = true;

      }
    }

    private void Chase(){
    NavAgent.SetDestination(Player.position);
    }

    private void Attack(){

        NavAgent.SetDestination(transform.position);

        transform.LookAt(Player);

        if(!PlayerHit){

            PlayerHit = true;
            Invoke(nameof(ResetAttack), AttackSpeed);
        }
    }

    public void ResetAttack(){
        
        PlayerHit = false;
    }
    
    void Start()
    {
        
    }
}
