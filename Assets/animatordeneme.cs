using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class animatordeneme : MonoBehaviour
{
    public AnimatorController cont;


    public int hand_left = 1; 
    public int hand_right = 1;
    public string[] hand_left_coded = { "0", "0", "0", "1" };
    public string[] hand_right_coded = { "1", "0", "0", "0" };



    private void Start()
    {
        PlayFingerChangeAnimation();
    }

    //TODO
    // Elini rakibe vur
    // Kendi iki elini birbirine vur (Iki elde de ayni sayida parmak varsa?) 0011 1100 -> 1111 0000 yada 0000 1111
    // Bir elini bos olan diger eline vur (Elinde cift sayida parmak varsa vurabilirsin. Vurduktan sonra yari yariya paylasilacak parmaklar) 0000 1111 -> 0011 1100
   
    // This funciton is to change the finger amount when somene hits that hand
    // Elinde 1 vardi + 


    private void RightHandChange(int newFingerToAdd)
    {
        hand_right += newFingerToAdd;

        if (hand_right > 5)
            hand_right -= 5;

        string[] handcoded = { "0", "0", "0", "0" };

        for (var i = 0; i < hand_right; i++)
        {
            handcoded[i] = "1";
        }
        hand_right_coded = handcoded;
        PlayFingerChangeAnimation();
    }

    private void LeftHandChange(int newFingerToAdd)
    {
        hand_left += newFingerToAdd;

        if (hand_left > 5)
            hand_left -= 5;

        string[] handcoded = { "0", "0", "0", "0" };

        for (var i = 3; i > 3 - hand_left; i--)
        {
            handcoded[i] = "1";
        }
        hand_left_coded = handcoded;
        PlayFingerChangeAnimation();
    }

    private void PlayFingerChangeAnimation()
    {
        var animCode = string.Join("", hand_left_coded) + string.Join("", hand_right_coded);
        SetAnimationCrossFade(animCode);
        Debug.Log(animCode);
    }

    private void SetAnimationCrossFade(string aniname)
    {
        gameObject.GetComponent<Animator>().CrossFade(aniname, 1);        
    }
}
