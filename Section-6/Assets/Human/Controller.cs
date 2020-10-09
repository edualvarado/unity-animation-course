using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	float speed = 2.0F;
    float rotationSpeed = 100.0F;
    Animator anim;

    public static GameObject controlledBy;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (controlledBy != null) return;

		float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        
        transform.Rotate(0, rotation, 0);

        if(translation != 0)
        {
        	anim.SetBool("isWalking",true);
        	anim.SetFloat("speed", translation);
        }
        else
        {
        	anim.SetBool("isWalking",false);
        	anim.SetFloat("speed", 0);
        }	
    }
}
