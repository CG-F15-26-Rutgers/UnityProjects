using UnityEngine;
using System; // Use this to access Math.

public class AnimatedAgentScript : MonoBehaviour{
	public static Vector3 target;
	public static bool targetChanged;
	
	NavMeshAgent agent;
	private bool active;
	private Animator anim;

	private float epsilon = 3.0f; /* Agents will stop running if within this distance of the target.
									 Should be set to the same value as the "Stopping Distance" variable in the AnimatedAgent prefab. */

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
		if (targetChanged){
			transform.LookAt (target);
			agent.SetDestination(target);
		}

		if (active){
			if ( Math.Abs(transform.position.x - target.x) < epsilon &&
				 Math.Abs(transform.position.y - target.y) < epsilon &&
				 Math.Abs(transform.position.z - target.z) < epsilon)
				anim.SetFloat("MoveSpeed", 0);
			
			else
				anim.SetFloat ("MoveSpeed", 0.5f);
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
