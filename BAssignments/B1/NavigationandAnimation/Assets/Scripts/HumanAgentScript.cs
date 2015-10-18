using UnityEngine;
using System.Collections;

public class HumanAgentScript : MonoBehaviour{
	public static Vector3 target;
	NavMeshAgent agent;
	private bool active;
	
	Animator anim;
	
	void Start(){
		anim = GetComponent<Animator> ();

		agent = GetComponent<NavMeshAgent>();
		agent.autoBraking = true;
		agent.autoRepath = true;
		agent.Stop();
		
		target = agent.gameObject.transform.position; // First "target" should be its current position.
		agent.SetDestination(target);
		
		active = false;
	}
	
	void Update(){
		if (active) {
			anim.SetFloat("MoveSpeed", .5f);
			agent.SetDestination (target);
		} else 
			anim.SetFloat ("MoveSpeed", 0);
	}
	
	public void ChangeState(){
		if (active) {
			agent.Stop ();
		} else {
			agent.Resume ();
		}
		
		active = !active;
	}
}