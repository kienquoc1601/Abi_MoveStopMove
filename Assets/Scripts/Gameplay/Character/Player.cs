using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] JoystickControl JoystickControl;
    [SerializeField] Detector detector;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        IsDead = false;
    }

    // Update is called once per frame
     public new void Update()
    {
        
        if (!IsDead)
        {
            Target();
            fireRate.StartCount();
            //Debug.Log(targets.Count);  
            //GetFirstTarget();
            MoveIndicator();
            if (Input.GetMouseButtonDown(0))
            {
                //counter.Cancel();
                isMoving = true;
            }

            if (Input.GetMouseButton(0) && JoystickControl.direct != Vector3.zero)
            {
                //rb.velocity = JoystickControl.direct * moveSpeed;
                rb.MovePosition(rb.position + JoystickControl.direct * moveSpeed * Time.deltaTime);
                TF.position = rb.position;

                TF.forward = JoystickControl.direct;

                ChangeAnim(Constant.ANIM_RUN);
                isMoving = true;
            }
            else
            {
                //counter.Execute();
            }

            if (Input.GetMouseButtonUp(0))
            {
                isMoving = false;
                
                
                OnAttack();
                

            }
            if (!isMoving)
            {
                OnMoveStop();
                Fire();
            }
            

        }
        
         
    }
    void MoveIndicator()
    {
        if (target != null)
        {
            indicatorPoint.GetComponent<SpriteRenderer>().enabled = true;
            indicatorPoint.transform.position = target.transform.position;
        }
        else if (target == null || isMoving == true)
        {
            indicatorPoint.GetComponent<SpriteRenderer>().enabled = false;
        }
    }



}
