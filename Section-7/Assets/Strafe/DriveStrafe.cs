using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveStrafe : MonoBehaviour {

	public float speed = 20.0f;
    public float turnSpeed = 50.0f;

    Animator anim;
    bool move = false;

    void Start()
    {
    	anim = GetComponent<Animator>();
    }

    void Update() {
        float translationX = Input.GetAxis("Horizontal") * speed;
        float translationZ = Input.GetAxis("Vertical") * speed;
        translationX *= Time.deltaTime;
        translationZ *= Time.deltaTime;

        //transform.Translate(0, 0, translationX);
        //transform.Rotate(0, rotation, 0);

        if(translationX == 0 && translationZ == 0)
        	move = false;
        else
        	move = true;

        float turnAmount = Mathf.Atan2(translationX, translationZ);
        transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);

        anim.SetBool("Running", move);
        anim.SetFloat ("VelocityX", translationX);
		anim.SetFloat ("VelocityZ", translationZ);

    }
}
