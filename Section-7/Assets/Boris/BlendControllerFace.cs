using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendControllerFace : MonoBehaviour
{

    SkinnedMeshRenderer blendShapes;
    float blink = 0;
    float open = 0;
    float mouseY = 0;

    // Start is called before the first frame update
    void Start()
    {
        blendShapes = this.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        blink = Input.GetAxis("Vertical") * 100;
        open = Input.GetAxis("Horizontal") * 100;
        mouseY = Input.mousePosition.y;
        blendShapes.SetBlendShapeWeight(0, blink);
        blendShapes.SetBlendShapeWeight(1, open);
        blendShapes.SetBlendShapeWeight(2, mouseY);
    }
}
