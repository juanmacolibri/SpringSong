using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peckable : MonoBehaviour, IInteractable
{
    public enum PeckType { Break, Button, Food}
    public PeckType PT;
    [SerializeField] Sprite brokenText;
    bool pecked;
    public void InitInteraction(GameObject bird)
    {
        switch (PT)
        {
            case PeckType.Break:
                BreakInteraction();
                break;
        }
    }

    public void EndInteraction()
    {

    }

    private void BreakInteraction()
    {
        if (pecked)
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = brokenText;
            pecked = true;
        }
    }

    private void FoodInteraction()
    {

    }
}
