using UnityEngine;
using System.Collections;

public class BasicAgentScript : MonoBehaviour{
	public static Vector3 target;
	NavMeshAgent agent;
	private bool active;

	void Start(){
		agent = GetComponent<NavMeshAgent>();
		agent.autoBraking = true;
		agent.autoRepath = true;
		agent.Stop();

		target = agent.gameObject.transform.position; // First "target" should be its current position.
		agent.SetDestination(target);
		
		active = false;
	}

	void Update(){
		if (active)
			agent.SetDestination(target);
	}
	
	public void ChangeState(){
		if (active)
			agent.Stop();
		else
			agent.Resume();
		
		active = !active;
	}
}
