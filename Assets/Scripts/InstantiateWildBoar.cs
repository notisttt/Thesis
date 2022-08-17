using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InstantiateWildBoar : MonoBehaviour
{
  
  public float Timer;
  public GameObject WildBoar;
  public Transform WildBoarLoc;
  public int WildBoarNum;
    
   void Awake(){

        WildBoar = GameObject.FindGameObjectWithTag("WildBoars");
        WildBoarLoc = GameObject.FindGameObjectWithTag("WildBoars").transform;

   }


    void Start()
    {   
        CreateWildBoars(4);
    }
    
    void CreateWildBoars(int EnemyNum){
        
        Vector3 right = transform.right;

        for(int i = 0; i < EnemyNum; i++){

        float offset = i * 0.1f;
        Vector3 position = WildBoarLoc.transform.position + right * offset;    
        GameObject WildBoarClones = Instantiate(WildBoar, position, transform.rotation);
        WildBoarClones.GetComponent<WildBoarAI>().health = 10;
        WildBoarClones.GetComponent<WildBoarAI>().WalkPointRange = 100;
        WildBoarClones.GetComponent<WildBoarAI>().SightRange = 35;
        WildBoarClones.GetComponent<WildBoarAI>().AttackSpeed = 4;
        WildBoarClones.GetComponent<WildBoarAI>().Dead = false; 
        WildBoarClones.GetComponent<NavMeshAgent>().enabled = true;
        WildBoarClones.GetComponent<BoxCollider>().enabled = true;
      

        }
    }
    
    void Update(){
    
    
        WildBoar = GameObject.FindGameObjectWithTag("WildBoars");
        WildBoarLoc = GameObject.FindGameObjectWithTag("WildBoars").transform;

    WildBoarNum = GameObject.FindGameObjectsWithTag("WildBoars").Length;
      

    

          

            if (WildBoarNum < 28){

                
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        else {

            CreateWildBoars(4);
            
            Timer = 60;
            }
        }
    }

  
}
