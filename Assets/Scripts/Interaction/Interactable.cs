using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
   
   [SerializeField] private float radius = 3f;
   [SerializeField] private Transform interactionTransform;
   private PlayerController _controller;
   private bool isFocus;
   private bool hasInteracted;
   public float Radius => radius;
   public Transform InteractionTransform => interactionTransform;

   public virtual Item Interact()
   {
      Debug.Log("Interacting with" + interactionTransform.name);
      return null;
   }
   

   private void OnTriggerEnter(Collider other)
   {
      if (isFocus && !hasInteracted)
      {
               _controller.SetItemToInventory(Interact());
               hasInteracted = true;
      }

   }

   public void OnFocused(PlayerController controller)
   {
      isFocus = true;
      hasInteracted = false;
      _controller = controller;
   }

   public void DeFocused()
   {
      isFocus = false;
      hasInteracted = false;
      _controller = null;
   }

   private void OnDrawGizmos()
   {

      if (interactionTransform == null)
         interactionTransform = transform;
      
      Gizmos.color = Color.yellow;
      Gizmos.DrawWireSphere(interactionTransform.position, radius);
   }
}
