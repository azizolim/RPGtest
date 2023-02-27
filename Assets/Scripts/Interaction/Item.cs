using UnityEngine;

[CreateAssetMenu (fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite Icon = null;
    public bool IsDefaultItem = false;
}
