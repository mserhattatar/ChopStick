using UnityEngine;

public class LeftHandController : MonoBehaviour
{
    public GameObject rightcube;
    public GameObject leftcube;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rightcube")
        {
            if (Input.GetMouseButton(1)) return;
            if (other.gameObject == rightcube)
            {
                Debug.Log("benim sol elim kendi sağ elime çarptı");
            }
            else
            {
                Debug.Log("benim sol elim karşı tarafın sağ eline çarptı");
                var fingerNumber = gameObject.GetComponentInParent<FingersAndAnimatorController>().hand_left;
                other.GetComponentInParent<FingersAndAnimatorController>().RightHandChange(fingerNumber);
            }              
        }
        if (other.gameObject.tag == "leftcube")
        {
            if (Input.GetMouseButton(1)) return;
            if (other.gameObject != leftcube)
            { 
                Debug.Log("benim sol elim karşı tarafın sol eline çarptı");
                var fingerNumber = gameObject.GetComponentInParent<FingersAndAnimatorController>().hand_left;
                other.GetComponentInParent<FingersAndAnimatorController>().LeftHandChange(fingerNumber);
            }
        }
    }
}
