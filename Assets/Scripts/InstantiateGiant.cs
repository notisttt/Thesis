using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InstantiateGiant : MonoBehaviour
{
  
 
  public GameObject Skeleton;
  public Transform SkeLoc;
  
  public float Timer;
  public int SkelNum;
  
  void Awake(){

    
     Skeleton = GameObject.FindGameObjectWithTag("Giant");
        SkeLoc = GameObject.FindGameObjectWithTag("Giant").transform;
     
  }

  
    
    void CreateSkellies(int EnemyNum){
        
        Vector3 right = transform.right;
 
        for(int i = 0; i < EnemyNum; i++){

        float offset = i * 0.1f;
        Vector3 position = SkeLoc.transform.position + right * offset;    
        GameObject SkellieClones = Instantiate(Skeleton, position, transform.rotation);
        SkellieClones.GetComponent<SkeletonAI>().health = 300;
        SkellieClones.GetComponent<SkeletonAI>().WalkPointRange = 100;
        SkellieClones.GetComponent<SkeletonAI>().SightRange = 100;
        SkellieClones.GetComponent<SkeletonAI>().AttackSpeed = -3;
        SkellieClones.GetComponent<SkeletonAI>().Dead = false;
        SkellieClones.GetComponent<NavMeshAgent>().enabled = true;
           
         
     
     
        }
    }

        void Update(){

     Skeleton = GameObject.FindGameObjectWithTag("Giant");
        SkeLoc = GameObject.FindGameObjectWithTag("Giant").transform;

    SkelNum = GameObject.FindGameObjectsWithTag("Giant").Length;
      
        

       

        

          

            if (SkelNum < 1){

            if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        else{

            CreateSkellies(1);
            
            Timer = 600;

        }

                           }
        
    }

  
}
