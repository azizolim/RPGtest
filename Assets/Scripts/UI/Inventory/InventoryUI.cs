using UnityEngine;

namespace UI.Inventory
{
    public class InventoryUI : MonoBehaviour
    {

        [SerializeField] private Inventory inventory;
    
        [SerializeField] private Slot[] _slots;
       
        void Start()
        {
            inventory.OnItemChangedCallBack += UpdateUI;
            for (int i = 0; i < _slots.Length; i++)
            {
                var item = _slots[i].Item;
                _slots[i].RemoveButton.onClick.AddListener(()=>inventory.Remove(item));
                _slots[i].RemoveButton.onClick.AddListener(_slots[i].ClearSlot);
            }
        }

       

        private void UpdateUI()
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (i<inventory.items.Count)
                {
                    _slots[i].AddItem(inventory.items[i]);
                }
            }
            Debug.Log("Updating UI");
        }
    }
}
