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
            case PeckType.Food:
                FoodInteraction(bird);
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

    private void FoodInteraction(GameObject bird)
    {
        if (gameObject.activeSelf)
        {
            GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SavaManager>().SaveGame(GameObject.FindGameObjectWithTag("Player").transform.position);
            GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SavaManager>().AddObject(gameObject.name);
            bird.GetComponent<Player_FSM>().isWeak = false;
            //mejorar salud
            gameObject.SetActive(false);
        }
    }
}
