using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InstantiateWorker : MonoBehaviour
{
  
 
  public GameObject Worker;
  public Transform WorkerLoc;
  
  public float Timer;
  public int WorkerNum;
  
  void Awake(){

    
        Worker = GameObject.FindGameObjectWithTag("Peasants");
        WorkerLoc = GameObject.FindGameObjectWithTag("Peasants").transform;
     
  }

    void Start()
    {   
        CreateWorkers(4);
    }
    
    void CreateWorkers(int WorkerNum){
        
        Vector3 right = transform.right;
 
        for(int i = 0; i < WorkerNum; i++){

        float offset = i * 0.1f;
        Vector3 position = WorkerLoc.transform.position + right * offset;    
        GameObject WorkerClones = Instantiate(Worker, position, transform.rotation);

           
         
     
     
        }
    }

        void Update(){

        Worker = GameObject.FindGameObjectWithTag("Peasants");
        WorkerLoc = GameObject.FindGameObjectWithTag("Peasants").transform;

        WorkerNum = GameObject.FindGameObjectsWithTag("Peasants").Length;
      
        

       

        

          

            if (WorkerNum < 20){

            if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        else{

            CreateWorkers(4);
            
            Timer = 300;

        }

                           }
        
    }

  
}
