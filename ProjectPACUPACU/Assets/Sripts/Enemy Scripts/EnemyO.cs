using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyO : MonoBehaviour {
    public float Speed;
    public GameObject plane;
    Vector3 targetVector,StartMarker;
    float dist, journeyLength, fracJourney, distCovered;
    // Use this for initialization
    void Start () {
        targetVector = transform.position;
        print(plane.GetComponent<Renderer>().bounds.extents.magnitude);
        
    }
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(transform.position, targetVector);
        
       
        if (dist <0.5f)
        {
            print("toy cerca 2");
            targetVector = randomVector();
            StartMarker = transform.position;
            journeyLength = Vector3.Distance(StartMarker, targetVector);
            distCovered = Time.deltaTime * Speed;
            fracJourney = distCovered / journeyLength;

        }
        transform.position = Vector3.MoveTowards(transform.position, targetVector,Speed*Time.deltaTime);
        //transform.position = Vector3.Lerp(StartMarker, targetVector,fracJourney);
    }
    private Vector3 randomVector()
    {
        Vector3 a = new Vector3();
        float x, z;
        x = Random.Range(-plane.GetComponent<Renderer>().bounds.extents.magnitude, plane.GetComponent<Renderer>().bounds.extents.magnitude);
        z = Random.Range(-plane.GetComponent<Renderer>().bounds.extents.magnitude, plane.GetComponent<Renderer>().bounds.extents.magnitude);
        // x = Random.Range(-5.5f, 5.5f);
        //  z = Random.Range(-5.5f, 5.5f);

        a = new Vector3(x, 1, z);
        print(a);
        return a;
    }
}
