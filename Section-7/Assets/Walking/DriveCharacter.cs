using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCharacter : MonoBehaviour
{
    float speed = 5.0F;
    float rotationSpeed = 1.0F;
    float currentSpeed = 0.0F;
    Animator anim;

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
        translation += Time.deltaTime;
        rotation += Time.deltaTime;

        currentSpeed += translation;
        anim.SetFloat("Speed", currentSpeed);
        transform.Rotate(0, rotation, 0);

        Debug.Log("Axis is: " + Input.GetAxis("Vertical"));
        Debug.Log("Translation is: " + translation);
        Debug.Log("currentSpeed is: " + currentSpeed);

        if (translation != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
            currentSpeed = 0;
        }
    }
}
