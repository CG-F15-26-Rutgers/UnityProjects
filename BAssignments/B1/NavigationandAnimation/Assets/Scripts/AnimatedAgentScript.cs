using UnityEngine;
using System.Collections;

public class AnimatedAgentScript : MonoBehaviour{
	public static Vector3 target;
	public static bool targetChanged;
	
	NavMeshAgent agent;
	private bool active;
	private Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
		
		agent = GetComponent<NavMeshAgent>();
		agent.autoBraking = true;
		agent.autoRepath = true;
		agent.Stop();

		target = agent.gameObject.transform.position; // First "target" should be its current position.
		agent.SetDestination(target);
		
		active = false;
		targetChanged = false;
	}

	void Update(){
		if (targetChanged)
			agent.SetDestination(target);

		if (active){
			if (transform.position == target)
				anim.SetFloat("MoveSpeed", 0);
			
			else{
				transform.LookAt (target);
				anim.SetFloat ("MoveSpeed", 0.5f);
			}
		}
	}
	
	public void ChangeState(){
		if (active)
			agent.Stop();
		else 
			agent.Resume();
		
		active = !active;
	}
}
