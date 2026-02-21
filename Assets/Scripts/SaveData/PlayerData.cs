using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public Vector3 PlayerPos_scene0;
    public Vector3 PlayerPos_scene1;    
    public bool doorOpened;
    public bool satarScreenSaw;
}
