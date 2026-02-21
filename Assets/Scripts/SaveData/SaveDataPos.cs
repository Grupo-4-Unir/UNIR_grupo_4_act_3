using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataPos : MonoBehaviour
{
    [SerializeField]
    PlayerData playerData;    

    public void SaveDataPosition()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:                
                   playerData.PlayerPos_scene0 = transform.position;
                break;
            case 1:                
                    playerData.PlayerPos_scene0 = transform.position;
                break;
        }

    }
}
