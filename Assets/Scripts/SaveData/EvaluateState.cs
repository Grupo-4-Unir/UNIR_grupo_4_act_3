using UnityEngine;

public class EvaluateState : MonoBehaviour
{
    [SerializeField]
    PlayerData playerData;

    [SerializeField]
    GameObject startScreen, door, portal;
    private void Start()
    {
        if (playerData.doorOpened)
        {
            door.SetActive(false);
            portal.SetActive(true);
        }

        if (playerData.satarScreenSaw)
        {
            startScreen.SetActive(false);
        }
    }

    public void SetDoorOpened()
    {
        playerData.doorOpened = true;        
    }

    public void SetStartScreenSaw()
    {        
        playerData.satarScreenSaw = true;
    }
}
