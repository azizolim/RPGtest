using System.Collections.Generic;
using UnityEngine;

namespace UI.Inventory
{
    public class Inventory : MonoBehaviour
    {
    
        [SerializeField] private int slots = 20;
        public List<Item> items = new List<Item>();

        public delegate void OnItemChanged();

        public OnItemChanged OnItemChangedCallBack;
        public bool Add(Item item)
        {
            if (!item.IsDefaultItem)
            {
                if (items.Count>=slots)
                {
                    Debug.Log("Don't have enough space");
                    return false;
                }
                items.Add(item);
                if(OnItemChangedCallBack != null)
                    OnItemChangedCallBack.Invoke();
            }
            return true;
        }


        public void Remove(Item item)
        {
            items.Remove(item);
            if(OnItemChangedCallBack != null)
                OnItemChangedCallBack.Invoke();
        }
    }
}
