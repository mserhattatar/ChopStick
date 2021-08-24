using UnityEngine;

public class RightHandController : MonoBehaviour
{
    public GameObject rightcube;
    public GameObject leftcube;
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.tag == "rightcube")
        {
            if (Input.GetMouseButton(1)) return;
            if (other.gameObject != rightcube)
            {
                Debug.Log("benim sağ elim karşı tarafın sağ eline çarptı");
                var fingerNumber = gameObject.GetComponentInParent<FingersAndAnimatorController>().hand_right;
                other.GetComponentInParent<FingersAndAnimatorController>().RightHandChange(fingerNumber);
            }
        }
        if (other.gameObject.tag == "leftcube")
        {
            if (Input.GetMouseButton(1)) return;
            if (other.gameObject == leftcube)
            {
                Debug.Log("benim sağ elim kendi sol elime çarptı");
                //if my hand hit my óther hand, than must be calling finger changed function.
            }
            else
            {
                Debug.Log("benim sağ elim karşı tarafın sol eline çarptı");
                // if it you have a 3 fingers and target have 3 fingers than you must be 3+3 = x-5 =1 than you need to show 1 fingers ani
                var fingerNumber = gameObject.GetComponentInParent<FingersAndAnimatorController>().hand_right;
                other.GetComponentInParent<FingersAndAnimatorController>().LeftHandChange(fingerNumber);
            }
        }
    }
}
