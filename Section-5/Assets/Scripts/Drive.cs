using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    float speed = 2.5f;
    float rotationSpeed = 100.0f;

    Animator anim;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation > 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("direction", 1.0f);
        }
        else if (translation < 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("direction", -1.0f);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("isJumping");
        }        
    }
}
