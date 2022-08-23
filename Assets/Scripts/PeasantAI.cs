using System.Collections;
using System.Collections.Generic;    //ta namespaces
using UnityEngine;
using UnityEngine.AI;
public class PeasantAI : MonoBehaviour  
{
   
    
    Animator m_Animator;



    public LayerMask WhatIsGround;         //layermasks
    
    public NavMeshAgent NavAgent;                         //To AI twn NPC
  

    public Vector3 WalkPoint;  
    bool WalkPointSet;                //metavlites gia tin katefthinsi twn npc        
    public float WalkPointRange;
 


    



 void Awake(){             //i awake kaleitai einai i prwti methodos pou kaleitai sto game 
 
    

     
    NavAgent = GetComponent<NavMeshAgent>();                           //afto pairnei to navmesh, diladi to pou mporei na perpatisei to npc    



 }

   
 void Start(){
        m_Animator = GetComponent<Animator> ();
                                                                   

    }


  
    void Update()           //i update kaleitai kathe frame
    {
       
       
        
         
          
         
            Patrolling();

         
   
 
   
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
     if (Physics.Raycast(WalkPoint, -transform.up, 2f, WhatIsGround)){                                                   //kwdikas gia to pws perpataei to npc
     WalkPointSet = true;
    

      m_Animator.SetBool ("IsMoving", WalkPointSet);
     
      }
    }


}
