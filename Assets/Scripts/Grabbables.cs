using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbables : MonoBehaviour, IInteractable
{
    public void EndInteraction()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().freezeRotation = false;
        Physics2D.IgnoreLayerCollision(6, 7, false);
        transform.parent = null;
    }

    public void InitInteraction(GameObject bird)
    {

        Physics2D.IgnoreLayerCollision(6, 7);
        transform.parent = bird.transform;
        transform.position = bird.transform.GetChild(0).transform.position;
    }
}
