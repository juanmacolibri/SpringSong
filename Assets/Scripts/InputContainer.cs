using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumLib;

[CreateAssetMenu(fileName = "InputContainer", menuName = "ScriptableObjects/InputContainer", order = 1)]
public class InputContainer : ScriptableObject
{
    public Dictionary<MoveType, string> inputList;

    public void ResetInputs()
    {
        inputList = new Dictionary<MoveType, string>();
    }

    public void SetInputs(MoveType move, string input)
    {
        inputList.Add(move, input);
        Debug.Log("Move added");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Birb>().SetInput(move, input);
        //añadir al script de personaje
        //la siguiente funcion es temporaria
    }

    public void InitiateInputs()
    {
        //añadir al script de personaje
    }
}
