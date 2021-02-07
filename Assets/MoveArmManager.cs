using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArmManager : MonoBehaviour
{
    public GameObject rightArm;
    public GameObject leftArm;
    private Vector3 rightArmvec3;
    private Vector3 leftArmvec3;

    void Update()
    {

        OnMouseDrag();


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
            }
        }
    }
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, leftArm.transform.position.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        leftArm.transform.position = objPosition;
    }

    private void MoveArm()
    {

    }

}
