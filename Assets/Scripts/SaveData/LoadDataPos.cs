using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDataPos : MonoBehaviour
{
    [SerializeField]
    PlayerData playerData;

    private void Start()
    {  
        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                if(playerData.PlayerPos_scene0!= Vector3.zero)
                    transform.position = playerData.PlayerPos_scene0;
                break;
            case 1:
                if (playerData.PlayerPos_scene1 != Vector3.zero)
                    transform.position = playerData.PlayerPos_scene1;
                break;
        }
    }
}
