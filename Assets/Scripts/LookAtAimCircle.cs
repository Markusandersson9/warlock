using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtAimCircle : MonoBehaviour {

    public float damping;

    private Transform cursor;

    // Use this for initialization
    void Start()
    {
        this.cursor = GameObject.Find("AimCircle").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        var lookAtPosition = cursor.position - transform.position;
        lookAtPosition.y = 0; //Looks at a objecton xz plane (y = 0)
        var rotation = Quaternion.LookRotation(lookAtPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, damping);
    }
}
