using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public ClickToMove()
    {
        // This is a constructor.
    }
    public float speed = 5.0f; 
    private Vector3 targetPosition;
    private bool isMoving = false;
    private string WALK_ANIMATION = "Walk";
    void Update()
    {
        if (Input.GetMouseButton(0)& Input.GetKey(KeyCode.E))
        {
            SetTargetPosition();
        }

        if (isMoving)
        {
            Move();
        }
        AnimatePlayer();
    }
    void SetTargetPosition() 
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }
    void Move() 
    {   
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition) 
        {
            isMoving = false;
        }
    }
    void AnimatePlayer() {
        if (movementX > 0) {
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
        } else if (movementX < 0) {
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
        } else {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
}
