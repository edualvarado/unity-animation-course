using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGrabbing : MonoBehaviour
{
    public GameObject rootPos;

    private void OnTriggerEnter(Collider obj)
    {
        Debug.Log(obj);
        obj.GetComponentInParent<ClimbUp>().GrabEdge(rootPos.transform);
    }

}
