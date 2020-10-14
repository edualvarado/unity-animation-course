using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKLookAt : MonoBehaviour
{

    Animator anim;
    public Transform target;
    public float weight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtPosition(target.position);
        anim.SetLookAtWeight(weight);
    }
}
