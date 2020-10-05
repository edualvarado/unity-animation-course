using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{

    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("Open", true);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Open", false);
    }

}
