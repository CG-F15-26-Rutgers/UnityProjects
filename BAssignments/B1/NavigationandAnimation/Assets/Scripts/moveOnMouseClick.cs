using UnityEngine;
using System.Collections;
 
public class moveOnMouseClick : MonoBehaviour {
	private Transform myTransform;				
	private Vector3 destinationPosition;		
	private float destinationDistance;			
 
	public float moveSpeed;						
 
 
 
	void Start () {
		myTransform = transform;							
		destinationPosition = myTransform.position;			
	}
 
	void Update () {
 
		destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
 
		if(destinationDistance < .5f){		
			moveSpeed = 0;
		}
		else if(destinationDistance > .5f){			
			moveSpeed = 3;
		}
 
 
		
		if (Input.GetMouseButtonDown(0)&& GUIUtility.hotControl ==0) {
 
			Plane playerPlane = new Plane(Vector3.up, myTransform.position);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float hitdist = 0.0f;
 
			if (playerPlane.Raycast(ray, out hitdist)) {
				Vector3 targetPoint = ray.GetPoint(hitdist);
				destinationPosition = ray.GetPoint(hitdist);
				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				myTransform.rotation = targetRotation;
			}
		}
 
		// Moves the player if the mouse button is hold down
		else if (Input.GetMouseButton(0)&& GUIUtility.hotControl ==0) {
 
			Plane playerPlane = new Plane(Vector3.up, myTransform.position);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float hitdist = 0.0f;
 
			if (playerPlane.Raycast(ray, out hitdist)) {
				Vector3 targetPoint = ray.GetPoint(hitdist);
				destinationPosition = ray.GetPoint(hitdist);
				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				myTransform.rotation = targetRotation;
			}
		//	myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
		}
 
		// To prevent code from running if not needed
		if(destinationDistance > .5f){
			myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
		}
	}
}
