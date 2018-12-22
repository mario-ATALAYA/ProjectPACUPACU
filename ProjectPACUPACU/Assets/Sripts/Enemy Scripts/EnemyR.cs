using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyR : MonoBehaviour
{
    public enum EnemyState
    {
        CHASE, PATROLL, WAIT
    }
    public EnemyState State;

    public GameObject plane;
    Transform destination;
    NavMeshAgent _navMeshAgent;
    GameObject _player, _detectionArea;
    Vector3 targetVector;

    public float waitTime;
    private float _waitTime;

    public List<Material> detectionAreaColor = new List<Material>();

    // Use this for initialization
    void Start()
    {
        _detectionArea = this.transform.GetChild(0).gameObject;
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player");

        if (_navMeshAgent != null)
        {
            SetDestination();
        }
        else
        {
            print("no tengo NavMesh:" + gameObject.name);
        }

        State = EnemyState.PATROLL;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (detectionZone != null)
        {
            Player = detectionZone.GetComponent<DetectionZone>().getPlayer();
        }
        else
        {
            detectionZone = this.transform.GetChild(0).gameObject;
        }
        */

        switch (State)
        {
            case EnemyState.CHASE:
                _detectionArea.GetComponent<Renderer>().material = detectionAreaColor[0];

                if (_player != null)
                {
                    _navMeshAgent.SetDestination(_player.transform.position);
                }

            break;
            case EnemyState.PATROLL:
                _detectionArea.GetComponent<Renderer>().material = detectionAreaColor[1];

                if (_navMeshAgent.remainingDistance < 1)
                {
                    print("toy cerca");
                    targetVector = RandomVector();
                }
                _navMeshAgent.SetDestination(targetVector);

            break;
            case EnemyState.WAIT:
                _detectionArea.GetComponent<Renderer>().material = detectionAreaColor[2];
                _navMeshAgent.SetDestination(transform.position);

                _waitTime += Time.deltaTime;
                if(_waitTime >= waitTime)
                {
                    State = EnemyState.PATROLL;
                    _waitTime = 0;
                }

            break;
        }
    }
    private void SetDestination()
    {
        Vector3 targetVector;

        if (destination != null)
        {
            targetVector = destination.transform.position;

        }
    }

    private Vector3 RandomVector()
    {
        Vector3 a = new Vector3();
        float x, z;
        x = Random.Range(-plane.GetComponent<Renderer>().bounds.extents.magnitude, plane.GetComponent<Renderer>().bounds.extents.magnitude);
        z = Random.Range(-plane.GetComponent<Renderer>().bounds.extents.magnitude, plane.GetComponent<Renderer>().bounds.extents.magnitude);
        // x = Random.Range(-5.5f, 5.5f);
        //  z = Random.Range(-5.5f, 5.5f);

        a = new Vector3(x, .5f, z);

        return a;
    }
}
