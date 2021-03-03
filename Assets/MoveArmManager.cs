using UnityEngine;

public class MoveArmManager : MonoBehaviour
{

    public bool Player1;
    public bool Player2;
   

    private bool StopStart;
    private bool StartUpdate;

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

    private void PossitionData()
    {        
        //Void START working after animator fixed
        StopStart = true;
        rightSholderFirstPos = rightSholder.transform.position;
        leftSholderFirstPos = leftSholder.transform.position;
        rightHandFirstPos = rightHand.transform.position;
        leftHandFirstPos = leftHand.transform.position;
        leftArmLength = leftHand.transform.position - leftSholder.transform.position;
        rightArmLength = rightHand.transform.position - rightSholder.transform.position;

        StartUpdate = true;        
    }

    void Update()
    {
        if ((CanvasManager.instance.leftHandActive && !StopStart) || (CanvasManager.instance.rightHandActive && !StopStart))
            PossitionData();
                    
        if (!StartUpdate)
            return;

        PlayerHandMovment();
        PlayerMovmentBack();
    }
    

    void MoveHand(GameObject hand, Vector3 handfirstpos, GameObject sholder, Vector3 sholderfirstpos, Vector3 armlenght)
    {
        if (Input.GetMouseButton(1))
        {    
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, handfirstpos.z + 0.08f);           
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 newHandPos = objPosition - armlenght;            
            sholder.transform.position = Vector3.Lerp(sholder.transform.position, newHandPos, Time.deltaTime * 3f);            
        }
        else if (hand.transform.position != handfirstpos)
            sholder.transform.position = Vector3.Lerp(sholder.transform.position, sholderfirstpos, Time.deltaTime * 4f);        
    }      
    

    private void PlayerHandMovment()
    {
        if (Player1)
        {
            if (CanvasManager.instance.leftHandActive && GameManager.instance.turnPlayer)
                LeftHandMovment();
            if (CanvasManager.instance.rightHandActive && GameManager.instance.turnPlayer)
                RightHandMovment();
        }
        if (Player2)
        {
            if (CanvasManager.instance.leftHandActive && !GameManager.instance.turnPlayer)
                LeftHandMovment();
            if (CanvasManager.instance.rightHandActive && !GameManager.instance.turnPlayer)
                RightHandMovment();
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

    private void PlayerMovmentBack()
    {
        if (Input.GetMouseButton(1))
            Debug.Log("fare kullaniliyor");

        else if (rightHand.transform.position != rightHandFirstPos)
        {
            rightSholder.transform.position = Vector3.Lerp(rightSholder.transform.position, rightSholderFirstPos, Time.deltaTime * 4f);
        }
        else if (leftHand.transform.position != leftHandFirstPos)
        {
            leftSholder.transform.position = Vector3.Lerp(leftSholder.transform.position, leftSholderFirstPos, Time.deltaTime * 4f);
        }
    }
}
