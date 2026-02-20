using UnityEngine;
using UnityEngine.SceneManagement;

public class MyScenesManager : MonoBehaviour
{
    public void LoadNewScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
