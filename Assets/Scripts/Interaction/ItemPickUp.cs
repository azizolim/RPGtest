using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ItemPickUp : Interactable
{
    [SerializeField] private Item item;

    public override Item Interact()
    {
        return PickUp();
    }

    private Item PickUp()
    {
        Debug.Log("Picking up " + item.name);
        WaitOnDestroy();
        return item;
    }

    private async void WaitOnDestroy()
    {
        await Task.Delay(1);
        Destroy(gameObject);
    }
}