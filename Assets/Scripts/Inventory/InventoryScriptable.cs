using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryScriptable", menuName = "Scriptable Objects/InventoryScriptable")]
public class InventoryScriptable : ScriptableObject
{

    public item itemActive;

    public List<item> items = new List<item>();
}
