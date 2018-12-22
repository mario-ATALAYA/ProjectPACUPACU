using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    GameObject _player;
    EnemyR _me;

    // Use this for initialization
    void Start()
    {
        _me = transform.parent.GetComponent<EnemyR>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetPlayer()
    {
        return _player;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<Player>().PlayerIsMoving())
                _me.State = EnemyR.EnemyState.CHASE;
            else
                if(_me.State == EnemyR.EnemyState.CHASE)
                    _me.State = EnemyR.EnemyState.WAIT;          
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if(_me.State == EnemyR.EnemyState.CHASE)
                _me.State = EnemyR.EnemyState.WAIT;
        }
    }
}
