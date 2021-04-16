using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerTelephone : MonoBehaviour
{
    public GameObject character;
    public GameObject anchor;
    bool isWalkingTowards = false;
    bool standingNear = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalkingTowards)
        {
            AutoWalkTowards();
        }
    }

    private void FixedUpdate()
    {
        AnimLerp();
    }

    private void OnMouseDown()
    {
        if (!standingNear)
        {
            anim.SetFloat("speed", 1);
            anim.SetBool("isWalking", true);
            isWalkingTowards = true;
            Control.controlledBy = this.gameObject;
        }

    }
}
