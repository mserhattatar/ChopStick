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
            }
            else
            {
                Debug.Log("benim sağ elim karşı tarafın sol eline çarptı");
                var fingerNumber = gameObject.GetComponentInParent<FingersAndAnimatorController>().hand_right;
                other.GetComponentInParent<FingersAndAnimatorController>().LeftHandChange(fingerNumber);
            }
        }
    }
}
