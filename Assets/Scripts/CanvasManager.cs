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

    // if player play then turn is must be changed.

    public void RightButton()
    {
        rightHandActive = true;
        leftHandActive = false;
        rightButton.interactable = false;
        leftButton.interactable = true;
    }

    public void LeftButton()
    {
        leftHandActive = true;
        rightHandActive = false;
        leftButton.interactable = false;
        rightButton.interactable = true;
    }
}