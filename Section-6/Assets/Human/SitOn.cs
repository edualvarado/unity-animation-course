using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SitOn : MonoBehaviour
{
    public GameObject character;
    public GameObject anchor;
    bool isWalkingTowards = false;
    bool sittingOn = false;
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
        Debug.Log("Clicked on Chair");
        if (!sittingOn)
        {
            anim.SetFloat("speed", 1);
            anim.SetBool("isWalking", true);
            isWalkingTowards = true;
            Controller.controlledBy = this.gameObject;
        }

        else
        {
            anim.SetBool("isSitting", false);
            isWalkingTowards = false;
            sittingOn = false;
            Controller.controlledBy = null;

        }
    }

    void AutoWalkTowards() 
    {
        Vector3 targetDir;
        targetDir = new Vector3(anchor.transform.position.x - character.transform.position.x,
            0f,
            anchor.transform.position.z - character.transform.position.z);
        Quaternion rot = Quaternion.LookRotation(targetDir);
        character.transform.rotation = Quaternion.Slerp(character.transform.rotation, rot, 0.05f);

        //Debug.Log(Vector3.Distance(character.transform.position, anchor.transform.position));
        if (Vector3.Distance(character.transform.position, anchor.transform.position) < 0.5f)
        {
            anim.SetBool("isSitting", true);
            anim.SetBool("isWalking", false);

            character.transform.rotation = anchor.transform.rotation;

            isWalkingTowards = false;
            sittingOn = true;
        }
    }

    void AnimLerp()
    {
        if (!sittingOn) return;

        if(Vector3.Distance(character.transform.position, anchor.transform.position) > 0.1f)
        {
            character.transform.rotation = Quaternion.Lerp(character.transform.rotation,
                anchor.transform.rotation,
                Time.deltaTime * 0.05f);
            character.transform.position = Vector3.Lerp(character.transform.position,
                anchor.transform.position, Time.deltaTime * 0.5f);
        }
        else
        {
            character.transform.position = anchor.transform.position;
            character.transform.rotation = anchor.transform.rotation;
        }
    }
}
