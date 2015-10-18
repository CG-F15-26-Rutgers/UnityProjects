using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    public GameObject target = null;
    public bool orbit = false;

    public void Start()
    {
    }

     public void Update () {
        if(target != null)
        {
            transform.LookAt(target.transform);
            if(orbit)
            {
                transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime);
            }
        }

    
     }

 }