 using UnityEngine;
 public class Teleport : MonoBehaviour { 
     public Transform Destination;
     public Transform PlayerController;
     public void OnTriggerEnter(Collider PlayerController) { 
         PlayerController.transform.position = Destination.transform.position;
     }
 }