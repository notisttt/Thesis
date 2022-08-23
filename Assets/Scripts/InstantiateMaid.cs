using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InstantiateMaid : MonoBehaviour
{
  
 
  public GameObject Maid;
  public Transform MaidLoc;
  
  public float Timer;
  public int MaidNum;
  
  void Awake(){

    
        Maid = GameObject.FindGameObjectWithTag("Peasants");
        MaidLoc = GameObject.FindGameObjectWithTag("Peasants").transform;
     
  }

    void Start()
    {   
        CreateMaids(4);
    }
    
    void CreateMaids(int MaidNum){
        
        Vector3 right = transform.right;
 
        for(int i = 0; i < MaidNum; i++){

        float offset = i * 0.1f;
        Vector3 position = MaidLoc.transform.position + right * offset;    
        GameObject MaidClones = Instantiate(Maid, position, transform.rotation);

           
         
     
     
        }
    }

        void Update(){

        Maid = GameObject.FindGameObjectWithTag("Peasants");
        MaidLoc = GameObject.FindGameObjectWithTag("Peasants").transform;

        MaidNum = GameObject.FindGameObjectsWithTag("Peasants").Length;
      
        

       

        

          

            if (MaidNum < 20){

            if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        else{

            CreateMaids(4);
            
            Timer = 300;

        }

                           }
        
    }

  
}
