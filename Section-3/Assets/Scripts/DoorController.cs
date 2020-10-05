using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator anim;

    void OnTriggerEnter(Collider obj)
    {
        anim.SetBool("isOpening", true);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("isOpening", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = this.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
