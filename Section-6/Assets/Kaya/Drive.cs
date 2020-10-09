using UnityEngine;
using System.Collections;

public class Drive : MonoBehaviour {

    float speed = 5.0F;
    float rotationSpeed = 100.0F;
    Animator anim;
    Collision collision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeathCube")
        {
            anim.SetBool("isDead", true);
            this.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    void Start()
    {
    	anim = this.GetComponent<Animator>();
    }

    void Update() 
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        if(translation != 0)
        {
        	anim.SetBool("isWalking",true);
        }
        else
        {
        	anim.SetBool("isWalking",false);
        }
    }
}
