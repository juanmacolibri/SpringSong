using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edible : MonoBehaviour, IInteractable
{
    public void EndInteraction()
    {
        
    }

    public void InitInteraction(GameObject bird)
    {
        //Cambiar el estado del personaje a saludable
        //Crear sistema de guardado
        Destroy(gameObject);
    }
}
