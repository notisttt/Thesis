using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InstantiateSkeleton : MonoBehaviour
{
  
 
  public GameObject Skeleton;
  public Transform SkeLoc;
  
  public float Timer;
  public int SkelNum;
  
  void Awake(){

    
     Skeleton = GameObject.FindGameObjectWithTag("Skeletons");
        SkeLoc = GameObject.FindGameObjectWithTag("Skeletons").transform;
     
  }

    void Start()
    {   
        CreateSkellies(4);
    }
    
    void CreateSkellies(int EnemyNum){
        
        Vector3 right = transform.right;
 
        for(int i = 0; i < EnemyNum; i++){

        float offset = i * 0.1f;
        Vector3 position = SkeLoc.transform.position + right * offset;    
        GameObject SkellieClones = Instantiate(Skeleton, position, transform.rotation);
        SkellieClones.GetComponent<SkeletonAI>().health = 20;
        SkellieClones.GetComponent<SkeletonAI>().WalkPointRange = 5;
        SkellieClones.GetComponent<SkeletonAI>().SightRange = 40;
        SkellieClones.GetComponent<SkeletonAI>().AttackSpeed = 3;
        SkellieClones.GetComponent<SkeletonAI>().Dead = false;
        SkellieClones.GetComponent<NavMeshAgent>().enabled = true;
        SkellieClones.GetComponent<BoxCollider>().enabled = true;
           
         
     
     
        }
    }

        void Update(){

     Skeleton = GameObject.FindGameObjectWithTag("Skeletons");
        SkeLoc = GameObject.FindGameObjectWithTag("Skeletons").transform;

    SkelNum = GameObject.FindGameObjectsWithTag("Skeletons").Length;
      
        

       

        

          

            if (SkelNum < 4){

            if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        else{

            CreateSkellies(4);
            
            Timer = 300;

        }

                           }
        
    }

  
}
