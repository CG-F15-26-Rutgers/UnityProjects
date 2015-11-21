using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

    private float speed;
    private Rigidbody rb;

    void Start (){
		speed = 500.0f;
        rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		rb.mass = 10.0f;
		rb.angularDrag = 0.0f;
		rb.drag = 5.0f;
    }

    void FixedUpdate (){
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }
}
