using UnityEngine;
using System.Collections;

public class HumanScript : MonoBehaviour {

	[SerializeField][Range(1,20)]
	private float speed = 10;
	
	private Vector3 targetPosition;
	private bool isMoving;
	
	const int LEFT_MOUSE_BUTTON = 0;
	
	private Animator anim;
	
	void Start() {
		anim = GetComponent<Animator> ();
		
		targetPosition = transform.position;
		isMoving = false;
	}
	
	void Update() {
		if (Input.GetMouseButton (LEFT_MOUSE_BUTTON))
			SetTargetPosition ();
		
		if (isMoving) 
			MovePlayer ();
	}
	
	void SetTargetPosition() {
		Plane plane = new Plane (Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float point = 0f;
		
		if(plane.Raycast(ray, out point))
			targetPosition = ray.GetPoint(point);
		
		isMoving = true;
	}
	
	void MovePlayer() {
		transform.LookAt (targetPosition);
		
		transform.position = Vector3.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);
		anim.SetFloat ("Walk", 1);
		
		if (transform.position == targetPosition) {
			isMoving = false;
			anim.SetFloat("Walk", 0);
		}
		
		Debug.DrawLine (transform.position, targetPosition, Color.red);
	}

}
