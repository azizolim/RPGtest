using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Button removeButton;
        public Button RemoveButton => removeButton;

        private Item _item;
        public Item Item => _item;

        public void AddItem(Item newItem)
        {
            _item = newItem;
            icon.sprite = _item.Icon;
            icon.enabled = true;
            removeButton.interactable = true;
        }

        public void ClearSlot()
        {
            _item = null;

            icon.sprite = null;
            icon.enabled = false;
            removeButton.interactable = false;
        }
    }
}
