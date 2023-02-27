using System;
using System.Collections;
using System.Collections.Generic;
using UI.Inventory;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask movementMask;
    [SerializeField] private PlayerMotor motor;
    [SerializeField] private Interactable focus;
    [SerializeField] private Inventory inventory;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                hit.collider.TryGetComponent(out Interactable interactable);
                if (interactable != null)
                    SetFocus(interactable);
            }
        }
    }

    private void RemoveFocus()
    {
        if (focus != null)
            focus.DeFocused();

        focus = null;
        motor.StopFollowing();
    }

    private void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.DeFocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(this);
    }
    

    public void SetItemToInventory(Item item)
    {
        inventory.Add(item);
    }
}