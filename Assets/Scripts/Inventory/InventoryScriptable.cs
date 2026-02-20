using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryScriptable", menuName = "Scriptable Objects/InventoryScriptable")]
public class InventoryScriptable : ScriptableObject
{
    public List<item> items = new List<item>();
}
