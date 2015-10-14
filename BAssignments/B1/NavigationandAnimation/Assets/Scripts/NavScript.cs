using UnityEngine;
using System.Collections;

public class NavScript : MonoBehaviour {

    public NavMeshAgent agent;
    public Transform goal;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
	}
	
	// Update is called once per frame
	void Update () {
	    
        /*
        if(Input.GetMouseButton(0))
        {
            
        }
         */
	}
}
