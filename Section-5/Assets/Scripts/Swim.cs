using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    float speed = 1.0f;
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
            anim.SetBool("isSwimming", true);
            anim.SetFloat("direction", 1.0f);
        }
        else if (translation < 0)
        {
            anim.SetBool("isSwimming", true);
            anim.SetFloat("direction", -1.0f);
        }
        else
        {
            anim.SetBool("isSwimming", false);
        }
    }
}
