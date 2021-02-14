using UnityEngine;

public class MoveArmManager : MonoBehaviour
{

    public bool MOVMENTUPDATE;
    private bool Stop;

    public GameObject rightSholder;
    public GameObject rightHand;

    public GameObject leftSholder;
    public GameObject leftHand;

    private Vector3 rightHandFirstPos;
    private Vector3 leftHandFirstPos;
    private Vector3 leftSholderFirstPos;
    private Vector3 rightSholderFirstPos;

    private Vector3 leftArmLength;
    private Vector3 rightArmLength;

    void Update()
    {
        if((CanvasManager.instance.leftHandActive && !Stop) || (CanvasManager.instance.rightHandActive && !Stop))
        {
            Stop = true;
            rightSholderFirstPos = rightSholder.transform.position;
            leftSholderFirstPos = leftSholder.transform.position;
            rightHandFirstPos = rightHand.transform.position;
            leftHandFirstPos = leftHand.transform.position;
            leftArmLength = leftHand.transform.position - leftSholder.transform.position;
            rightArmLength = rightHand.transform.position - rightSholder.transform.position;
            Debug.Log("leftHandFirstPos  " + leftHandFirstPos);
            Debug.Log("rightHandFirstPos  " + rightHandFirstPos);            
        }


        if (CanvasManager.instance.leftHandActive && MOVMENTUPDATE)
            LeftHandMovment();
        if (CanvasManager.instance.rightHandActive && MOVMENTUPDATE)
            RightHandMovment();
    }

    void MoveHand(GameObject hand, Vector3 handfirstpos, GameObject sholder, Vector3 sholderfirstpos, Vector3 armlenght)
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, handfirstpos.z + 0.08f);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 ss = objPosition - armlenght;
            sholder.transform.position = Vector3.Lerp(sholder.transform.position, ss, Time.deltaTime * 3f);
            
        }
        else if (hand.transform.position != handfirstpos)
        {
            sholder.transform.position = Vector3.Lerp(sholder.transform.position, sholderfirstpos, Time.deltaTime * 3f);
        }
            
    }

    void RightHandMovment()
    {
        MoveHand(rightHand, rightHandFirstPos, rightSholder,rightSholderFirstPos, rightArmLength);
    }

    void LeftHandMovment()
    {
        MoveHand(leftHand, leftHandFirstPos, leftSholder, leftSholderFirstPos,leftArmLength);       
    }
}
