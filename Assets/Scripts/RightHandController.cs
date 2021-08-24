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
                var fingerNumber = gameObject.GetComponentInParent<FingersAndAnimatorController>().handRight;
                other.GetComponentInParent<FingersAndAnimatorController>().RightHandChange(fingerNumber);
            }
        }

        if (other.gameObject.tag == "leftcube")
        {
            if (Input.GetMouseButton(1)) return;
            if (other.gameObject == leftcube)
            {
                //if my hand hit my óther hand, than must be calling finger changed function.
            }
            else
            {
                // if it you have a 3 fingers and target have 3 fingers than you must be 3+3 = x-5 =1 than you need to show 1 fingers ani
                var fingerNumber = gameObject.GetComponentInParent<FingersAndAnimatorController>().handRight;
                other.GetComponentInParent<FingersAndAnimatorController>().LeftHandChange(fingerNumber);
            }
        }
    }
}