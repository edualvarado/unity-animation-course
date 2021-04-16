using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    Animator anim;
    float speed = 1.0f;
    float rotationSpeed = 100f;
    float weight = 1f;

    public static GameObject controlledBy;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;

        transform.Rotate(0, rotation, 0);

        if(translation != 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("speed", translation);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("speed", 0);
        }

    }
}
