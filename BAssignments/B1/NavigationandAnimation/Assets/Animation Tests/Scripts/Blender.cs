using UnityEngine;
using System.Collections;

public class Blender : MonoBehaviour {
	Animator anim;

	void Start() {
		anim = GetComponent<Animator> ();
	}

	void Update() {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
	
		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector3 temp = transform.position;
			temp.y += 3f;
			transform.position = temp;
		}

		anim.SetFloat ("MoveSpeed", v);
		anim.SetFloat ("TurnDirection", h);
	}

}
