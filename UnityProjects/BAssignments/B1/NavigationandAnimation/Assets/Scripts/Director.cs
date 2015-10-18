using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
	
	void Update(){

		AnimatedAgentScript.targetChanged = false;
	    
		if (Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray.origin, ray.direction, out hit)){

				// If the user clicked on an agent, then activate or deactivate the agent.
				if (hit.transform.gameObject.CompareTag("BasicAgent"))
					hit.transform.gameObject.GetComponent<BasicAgentScript>().ChangeState();
				
				else if(hit.transform.gameObject.CompareTag("AnimatedAgent"))
					hit.transform.gameObject.GetComponent<AnimatedAgentScript>().ChangeState();

				// If the user clicked on an obstacle, then activate or deactivate the obstacle.
				else if (hit.transform.gameObject.CompareTag("Obstacle"))
					hit.transform.gameObject.GetComponent<ObjectScript>().ChangeState();

				// Otherwise, change the agents' goals to the position the user clicked.
				else{
					BasicAgentScript.target = hit.point;
					
					AnimatedAgentScript.targetChanged = true;
					AnimatedAgentScript.target = hit.point;
				}
			}
		}
	}
}
