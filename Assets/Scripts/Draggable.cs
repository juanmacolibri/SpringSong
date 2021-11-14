using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour, IInteractable
{
    public void EndInteraction()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Birb>().turn = true;
        transform.GetChild(0).GetComponent<FixedJoint2D>().connectedBody = null ;
        transform.GetChild(0).GetComponent<FixedJoint2D>().enabled = false ;
    }

    public void InitInteraction(GameObject bird)
    {
        bird.GetComponent<Birb>().turn = false;
        transform.GetChild(0).GetComponent<FixedJoint2D>().connectedBody = bird.GetComponent<Rigidbody2D>();
        transform.GetChild(0).GetComponent<FixedJoint2D>().enabled = true;
    }
}