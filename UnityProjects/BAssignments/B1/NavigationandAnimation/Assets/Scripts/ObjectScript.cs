using UnityEngine;
using System.Collections;

public class ObjectScript : MonoBehaviour{
	private bool active;
	private float speed;
	private Rigidbody rb;

	void Start(){
		active = false;
		speed = 40.0f;
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
		if (active){
			float x = Input.GetAxis("Horizontal");
			float y = 0;
			float z = Input.GetAxis("Vertical");
			
			if(Input.GetKeyDown("space"))
				y = 5.0f;
			
			Vector3 movement = new Vector3(x, y, z);
			rb.AddForce(movement*speed);
		}
	}

	public void ChangeState(){
		active = !active;
	}
}
