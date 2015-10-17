using UnityEngine;
using System.Collections;

public class HumanScript : MonoBehaviour {

	private Animator anim;
	private float h;
	private float v;
	private float j;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		j = Input.GetAxis ("Jump");
		
		anim.SetFloat ("Walk", v);
		anim.SetFloat ("Turn", h);
		anim.SetFloat ("Jump", j);
	}
}
