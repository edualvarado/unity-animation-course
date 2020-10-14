using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform target;
    public Transform hand;
    Animator anim;
    float weight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        weight = anim.GetFloat("IKPickup");

        if (weight > 0.95)
        {
            target.parent = hand;
            target.localPosition = new Vector3(0f, 0.107f, 0.14f);
            target.localRotation = Quaternion.Euler(331f, 0, 0);
        }

        anim.SetIKPosition(AvatarIKGoal.RightHand, target.position);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("pickup");
        }
        
    }
}
