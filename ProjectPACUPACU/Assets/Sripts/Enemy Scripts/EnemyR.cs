using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyR : MonoBehaviour {
    public enum EnemyState
    {
        CHASE, PATROLL,WAIT
    }
    public EnemyState State;
    Transform destination;
   NavMeshAgent navMeshAgent;
    public GameObject plane;
    GameObject Player,detectionZone;
    Vector3 targetVector;
    // Use this for initialization
    void Start () {
        detectionZone = this.transform.GetChild(0).gameObject;
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (navMeshAgent!= null)
        {
            setDestination();
        }
        else
        {
            print("no tengo NavMes:" + gameObject.name);
        }
       
    }
	
	// Update is called once per frame
	void Update () {
        if (detectionZone != null)
        {
            Player = detectionZone.GetComponent<DetectionZone>().getPlayer();
        }
        else
        {
            detectionZone = this.transform.GetChild(0).gameObject;
        }
       if (Player != null)
        {
           State= EnemyState.CHASE;
        }
        else
        {
            State = EnemyState.PATROLL;
        }
        switch (State)
        {
            case EnemyState.CHASE:
                if (Player != null)
                {

                }
               
                break;
            case EnemyState.PATROLL:
              
            if(  navMeshAgent.remainingDistance<1)
                {
                    print("toy cerca");
                    targetVector = randomVector();
                }
                navMeshAgent.SetDestination(targetVector);
                break;

        }
	}
    private void setDestination()
    {
        
        
        Vector3 targetVector;
       
        if (destination != null)
        {
             targetVector = destination.transform.position;
           
        }
        
       
    }
    private Vector3 randomVector()
    {
        Vector3 a=new Vector3();
        float x, z;
        x = Random.Range(-plane.GetComponent<Renderer>().bounds.extents.magnitude, plane.GetComponent<Renderer>().bounds.extents.magnitude);
        z= Random.Range(-plane.GetComponent<Renderer>().bounds.extents.magnitude, plane.GetComponent<Renderer>().bounds.extents.magnitude);
       // x = Random.Range(-5.5f, 5.5f);
      //  z = Random.Range(-5.5f, 5.5f);

        a = new Vector3(x, .5f,z);

        return a;
    }
}
