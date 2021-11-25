using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Beak : MonoBehaviour
{
    [SerializeField] public LayerMask interactableLayer;
    [SerializeField] public float detectionDistance;
    private Vector3 originalPos;
    private Quaternion originalRot;
    Player_FSM playerFSM;

    private void Start()
    {
        playerFSM = GetComponentInParent<Player_FSM>();
        originalPos = gameObject.transform.localPosition;
        originalRot = gameObject.transform.localRotation;
    }

    private void Update()
    {
        if (Methods.CheckInteractable(playerFSM))
        {
            Debug.Log("Lalalala");
            playerFSM.interactableObject = Methods.CheckInteractable(playerFSM).gameObject;
            Vector3 lookAtPoint = Methods.CheckInteractable(playerFSM).transform.position;
            transform.transform.rotation = Quaternion.LookRotation(Vector3.forward, lookAtPoint - transform.position);
        }
        else
        {
            playerFSM.interactableObject = null;
            gameObject.transform.localPosition = originalPos;
            gameObject.transform.localRotation = originalRot;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
    }
}
