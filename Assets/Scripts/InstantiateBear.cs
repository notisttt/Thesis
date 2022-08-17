using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InstantiateBear : MonoBehaviour
{
  
  public float Timer;
  public GameObject Bear;
  public Transform BearLoc;
  public int BearNum;
    
   void Awake(){

        Bear = GameObject.FindGameObjectWithTag("Bear");
        BearLoc = GameObject.FindGameObjectWithTag("Bear").transform;

   }


    void Start()
    {   
        CreateBears(4);
    }
    
    void CreateBears(int EnemyNum){
        
        Vector3 right = transform.right;

        for(int i = 0; i < EnemyNum; i++){

        float offset = i * 0.1f;
        Vector3 position = BearLoc.transform.position + right * offset;    
        GameObject BearClones = Instantiate(Bear, position, transform.rotation);
        BearClones.GetComponent<BearAI>().health = 15;
        BearClones.GetComponent<BearAI>().WalkPointRange = 100;
        BearClones.GetComponent<BearAI>().SightRange = 50;
        BearClones.GetComponent<BearAI>().AttackSpeed = 3.5f;
        BearClones.GetComponent<BearAI>().Dead = false; 
        BearClones.GetComponent<NavMeshAgent>().enabled = true;
        BearClones.GetComponent<BoxCollider>().enabled = true;

        }
    }
    
    void Update(){
    
    
        Bear = GameObject.FindGameObjectWithTag("Bear");
        BearLoc = GameObject.FindGameObjectWithTag("Bear").transform;

    BearNum = GameObject.FindGameObjectsWithTag("Bear").Length;
      
      


          

            if (BearNum < 28){

            if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else {

            CreateBears(4);
            
            Timer = 60;
            }
        }
    }

  
}
