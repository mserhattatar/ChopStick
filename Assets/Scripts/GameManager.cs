using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool turnPlayer;
    private void Awake()
    {
        instance = this;
        turnPlayer = true;
    }
    
    public void Turn()
    {
        if (turnPlayer)
            turnPlayer = false;
        else
            turnPlayer = true;
       
    }
}
