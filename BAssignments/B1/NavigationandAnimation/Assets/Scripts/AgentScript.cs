using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour{
	public static Vector3 target;
	NavMeshAgent agent;
	private bool active;

	void Start(){
		agent = GetComponent<NavMeshAgent>();
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
