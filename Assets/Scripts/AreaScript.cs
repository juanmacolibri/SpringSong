using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumLib;

public class AreaScript : MonoBehaviour
{
    public enum AreaType { Learning, Hiding, Bathing}
    public AreaType AT;

    [SerializeField] InputContainer inps;
    public bool active = true;
    public MoveType MT;
    List<KeyCode> keyList;
    void Start()
    {
        CreateInputList();
    }
    private void CreateInputList()
    {
        keyList = new List<KeyCode>();
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            keyList.Add(vKey);
        }
        keyList.Remove(KeyCode.A);
        keyList.Remove(KeyCode.S);
        keyList.Remove(KeyCode.W);
        keyList.Remove(KeyCode.D);
        keyList.Remove(KeyCode.RightArrow);
        keyList.Remove(KeyCode.LeftArrow);
        keyList.Remove(KeyCode.UpArrow);
        keyList.Remove(KeyCode.DownArrow);
    }
    public void ActivateArea()
    {
        switch (AT)
        {
            case AreaType.Learning:
                LearningArea();
                break;
            case AreaType.Hiding:
                HidingArea();
                break;
            case AreaType.Bathing:
                break;
        }
    }

    private void LearningArea()
    {
        foreach (KeyCode vKey in keyList)
        {
            if (Input.GetKey(vKey) && active)
            {
                inps.SetInputs(MT, vKey.ToString());
                active = false;
                GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SavaManager>().AddArea(gameObject.name);
            }
        }
    }

    private void HidingArea()
    {
        //si el jugador esta imovil, activar atributo de escondida
    }

    private void BathingArea()
    {
        //si el jugador presiona boton de alas, hara play a animacion de agua
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            ActivateArea();
        }
    }
}
