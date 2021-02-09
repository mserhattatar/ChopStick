using UnityEngine;

public class MoveArmManager : MonoBehaviour
{

    public bool MOVMENTUPDATE;
    private bool Stop;

    public GameObject rightSholder;
    public GameObject rightHand;

    public GameObject leftSholder;
    public GameObject leftHand;

    private Vector3 rightSholderVector3;
    private Vector3 leftSholderVector3;

    void Update()
    {
        if((CanvasManager.instance.leftHandActive && !Stop) || (CanvasManager.instance.rightHandActive && !Stop))
        {
            rightSholderVector3 = rightHand.transform.position;
            leftSholderVector3 = leftHand.transform.position;
            Stop = true;
        }
       
        


        if (CanvasManager.instance.leftHandActive && MOVMENTUPDATE)
            LeftHandMovment();
        if (CanvasManager.instance.rightHandActive && MOVMENTUPDATE)
            RightHandMovment();
    }
    void RightHandMovment()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, rightHand.transform.position.z);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            rightHand.transform.position = Vector3.Lerp(rightHand.transform.position, objPosition, Time.deltaTime * 3f);
        }
        else if (rightHand.transform.position != rightSholderVector3)
            rightHand.transform.position = Vector3.Lerp(rightHand.transform.position, rightSholderVector3, Time.deltaTime * 3f);  
    }

    void LeftHandMovment()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, leftHand.transform.position.z);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            leftHand.transform.position = Vector3.Lerp(leftHand.transform.position, objPosition, Time.deltaTime * 3f);
        }
        else if (leftHand.transform.position != leftSholderVector3)
            leftHand.transform.position = Vector3.Lerp(leftHand.transform.position, leftSholderVector3, Time.deltaTime * 3f);      
    }
}
