using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
	
	void Update () {
	    
		if (Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray.origin, ray.direction, out hit)){

				// If the user clicked on an agent, then active or deactivate the agent.
				if (hit.transform.gameObject.CompareTag("Agent"))
					hit.transform.gameObject.GetComponent<AgentScript>().ChangeState();

				// If the user clicked on an obstacle, allow them to control it.
				else if (hit.transform.gameObject.CompareTag("Obstacle"))
					hit.transform.gameObject.GetComponent<ObjectScript>().ChangeState();

				// Otherwise, change the agents' goals to the position the user clicked.
				else
					AgentScript.target = hit.point;
			}
		}
	}
}
