using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendController : MonoBehaviour
{

    SkinnedMeshRenderer blendShapes;
    float inflateAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        blendShapes = this.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Input is: " + Input.GetAxis("Vertical"));
        inflateAmount = Input.GetAxis("Vertical") * 100;
        blendShapes.SetBlendShapeWeight(0, inflateAmount);
        
    }
}
