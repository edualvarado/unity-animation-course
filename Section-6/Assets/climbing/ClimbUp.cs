using UnityEngine;
using System.Collections;

public class ClimbUp : MonoBehaviour {

    float speed = 5.0F;
    float rotationSpeed = 100.0F;
    float lerpSpeed = 5.0F;

    Animator anim;
    bool isHanging = false;
    bool isShimmy = false;
    Transform animRootTarget;

    public void GrabEdge(Transform rootTarget)
    {
        if (isHanging) return;
        anim.SetTrigger("grabEdge");
        this.GetComponent<Rigidbody>().isKinematic = true;
        isHanging = true;
        animRootTarget = rootTarget;

        moveAnchor();
    }

    public void StandingUp()
    {
        isHanging = false;
        this.GetComponent<Rigidbody>().isKinematic = false;
        animRootTarget = null;
    }

    public void EndShimmy()
    {
        isShimmy = false;
        moveAnchor();
    }

    void moveAnchor()
    {
        Plane rootPlane = new Plane(animRootTarget.position,
                    animRootTarget.position + animRootTarget.right,
                    animRootTarget.position + animRootTarget.up);

        Vector3 adjustedPos = new Vector3(this.transform.position.x,
                                          animRootTarget.position.y,
                                          this.transform.position.z);

        Ray ray = new Ray(adjustedPos - animRootTarget.forward, animRootTarget.forward);

        float rayDistance;
        if (rootPlane.Raycast(ray, out rayDistance))
        {
            animRootTarget.position = ray.GetPoint(rayDistance);
        }
    }

    void AnimLerp()
     {
        if(!animRootTarget || isShimmy) return;
   
        if (Vector3.Distance(this.transform.position,animRootTarget.position) > 0.1f)
        {
            this.transform.rotation = Quaternion.Lerp(transform.rotation, 
                                                 animRootTarget.rotation, 
                                                 Time.deltaTime * lerpSpeed);
            this.transform.position = Vector3.Lerp(transform.position, 
                                              animRootTarget.position, 
                                              Time.deltaTime * lerpSpeed);
         }
         else
         {
            this.transform.position = animRootTarget.position;
            this.transform.rotation = animRootTarget.rotation;
         }
        
    }

    void Start()
    {
    	anim = this.GetComponent<Animator>();
        animRootTarget = null;
    }

    void FixedUpdate()
    {
        AnimLerp();
    }

    void Update() 
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        
        if(!isHanging)
            transform.Rotate(0, rotation, 0);

        if(translation != 0)
        {
        	anim.SetBool("isWalking",true);
            anim.SetFloat("speed",translation * 0.5f);
        }
        else
        {
        	anim.SetBool("isWalking",false);
            anim.SetFloat("speed",0);
        }

        if(Input.GetKeyDown("space"))
        {
            anim.SetTrigger("isJumping");
        }

        if(Input.GetKeyDown("w"))
        {
            if(isHanging)
            {
                anim.SetTrigger("isClimbing");
                animRootTarget = null;
            }
        }

        if (Input.GetKeyDown("a"))
        {
            if(isHanging)
            {
                anim.SetTrigger("shimmyLeft");
                isShimmy = true;
            }
        }

        if (Input.GetKeyDown("d"))
        {
            if (isHanging)
            {
                anim.SetTrigger("shimmyRight");
                isShimmy = true;
            }
        }

        if (Input.GetKeyDown("space"))
        {
            if (isHanging)
            {
                anim.SetTrigger("drop");
                this.GetComponent<Rigidbody>().isKinematic = false;
                animRootTarget = null;
            }
        }

    }
}
