using UnityEngine;
using UnityEngine.Serialization;

public class MoveArmManager : MonoBehaviour
{
    [FormerlySerializedAs("Player1")] public bool player1;
    [FormerlySerializedAs("Player2")] public bool player2;

    private bool _stopStart, _startUpdate;

    [FormerlySerializedAs("rightSholder")] public GameObject rightShoulder;
    public GameObject rightHand;

    [FormerlySerializedAs("leftSholder")] public GameObject leftShoulder;
    public GameObject leftHand;

    private Vector3 _rightHandFirstPos,
        _leftHandFirstPos,
        _leftShoulderFirstPos,
        _rightShoulderFirstPos,
        _leftArmLength,
        _rightArmLength;

    private void HandPositionData()
    {
        _stopStart = true;
        var position3 = rightShoulder.transform.position;
        _rightShoulderFirstPos = position3;
        var position1 = leftShoulder.transform.position;
        _leftShoulderFirstPos = position1;
        var position2 = rightHand.transform.position;
        _rightHandFirstPos = position2;
        var position = leftHand.transform.position;
        _leftHandFirstPos = position;
        _leftArmLength = position - position1;
        _rightArmLength = position2 - position3;
        if (player1)
            Debug.Log("player1 left arm lenght = " + _leftArmLength + "// right arm lenght = " + _rightArmLength);

        if (player2)
            Debug.Log("player2 left arm lenght = " + _leftArmLength + "// right arm lenght = " + _rightArmLength);
        _startUpdate = true;
    }

    private void Update()
    {
        if ((CanvasManager.instance.leftHandActive && !_stopStart) ||
            (CanvasManager.instance.rightHandActive && !_stopStart))
            HandPositionData();

        if (!_startUpdate)
            return;

        PlayerHandMovement();
        PlayerMovementBackPos();
    }


    private void MoveHand(GameObject hand, Vector3 handFirstPos, GameObject shoulder, Vector3 shoulderFirstPos,
        Vector3 armLenght)
    {
        if (Input.GetMouseButton(1))
        {
            var mousePosition = player1
                ? new Vector3(Input.mousePosition.x, Input.mousePosition.y, handFirstPos.z + 0.08f)
                : new Vector3(Input.mousePosition.x, Input.mousePosition.y, handFirstPos.z + 0f);

            var objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 newHandPos;
            if (player1)
                newHandPos = objPosition - armLenght;
            else
                newHandPos = objPosition + armLenght;

            shoulder.transform.position = Vector3.Lerp(shoulder.transform.position, newHandPos, Time.deltaTime * 3f);
        }
        else if (hand.transform.position != handFirstPos)
            shoulder.transform.position =
                Vector3.Lerp(shoulder.transform.position, shoulderFirstPos, Time.deltaTime * 4f);
    }


    private void PlayerHandMovement()
    {
        if (player1)
        {
            if (CanvasManager.instance.leftHandActive && GameManager.instance.turnPlayer)
                LeftHandMovement();
            if (CanvasManager.instance.rightHandActive && GameManager.instance.turnPlayer)
                RightHandMovement();
        }

        else if (player2)
        {
            if (CanvasManager.instance.leftHandActive && !GameManager.instance.turnPlayer)
                LeftHandMovement();
            if (CanvasManager.instance.rightHandActive && !GameManager.instance.turnPlayer)
                RightHandMovement();
        }
    }

    private void RightHandMovement()
    {
        MoveHand(rightHand, _rightHandFirstPos, rightShoulder, _rightShoulderFirstPos, _rightArmLength);
    }

    private void LeftHandMovement()
    {
        MoveHand(leftHand, _leftHandFirstPos, leftShoulder, _leftShoulderFirstPos, _leftArmLength);
    }

    private void PlayerMovementBackPos()
    {
        if (rightHand.transform.position != _rightHandFirstPos)
        {
            rightShoulder.transform.position = Vector3.Lerp(rightShoulder.transform.position, _rightShoulderFirstPos,
                Time.deltaTime * 4f);
        }
        else if (leftHand.transform.position != _leftHandFirstPos)
        {
            leftShoulder.transform.position =
                Vector3.Lerp(leftShoulder.transform.position, _leftShoulderFirstPos, Time.deltaTime * 4f);
        }
    }
}