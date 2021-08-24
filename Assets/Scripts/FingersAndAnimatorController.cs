using UnityEngine;
using UnityEngine.Serialization;

public class FingersAndAnimatorController : MonoBehaviour
{
    [FormerlySerializedAs("Model")] public GameObject model;
    [FormerlySerializedAs("hand_left")] public int handLeft = 1;
    [FormerlySerializedAs("hand_right")] public int handRight = 1;

    [FormerlySerializedAs("hand_left_coded")]
    public string[] handLeftCoded = { "0", "0", "0", "1" };

    [FormerlySerializedAs("hand_right_coded")]
    public string[] handRightCoded = { "1", "0", "0", "0" };

    private void Start()
    {
        PlayFingerChangeAnimation();
    }


    public void RightHandChange(int newFingerToAdd)
    {
        handRight += newFingerToAdd;

        if (handRight >= 5)
            handRight -= 5;

        string[] handcoded = { "0", "0", "0", "0" };

        for (var i = 0; i < handRight; i++)
        {
            handcoded[i] = "1";
        }

        handRightCoded = handcoded;
        PlayFingerChangeAnimation();
        GameManager.instance.Turn();
    }

    public void LeftHandChange(int newFingerToAdd)
    {
        handLeft += newFingerToAdd;

        if (handLeft >= 5)
            handLeft -= 5;

        string[] handcoded = { "0", "0", "0", "0" };

        for (var i = 3; i > 3 - handLeft; i--)
        {
            handcoded[i] = "1";
        }

        handLeftCoded = handcoded;
        PlayFingerChangeAnimation();
        GameManager.instance.Turn();
    }

    private void PlayFingerChangeAnimation()
    {
        var animCode = string.Join("", handLeftCoded) + string.Join("", handRightCoded);
        SetAnimationCrossFade(animCode);
        Debug.Log(animCode);
    }

    private void SetAnimationCrossFade(string aniName)
    {
        model.GetComponent<Animator>().CrossFade(aniName, 1);
    }
}