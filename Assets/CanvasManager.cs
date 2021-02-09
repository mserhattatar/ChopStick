using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public Button rightButton;
    public Button leftButton;
    public bool rightHandActive;
    public bool leftHandActive;
    private void Awake()
    {
        instance = this;
    }

    public void RightButton()
    {
        Debug.Log("rightButton");
        rightHandActive = true;
        leftHandActive = false;
        rightButton.interactable = false;
        leftButton.interactable = true;
    }
    public void LeftButton()
    {
        Debug.Log("LeftButton");
        leftHandActive = true;
        rightHandActive = false;
        leftButton.interactable = false;
        rightButton.interactable = true;
    }
}
