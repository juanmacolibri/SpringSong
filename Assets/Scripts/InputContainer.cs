using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumLib;

[CreateAssetMenu(fileName = "InputContainer", menuName = "ScriptableObjects/InputContainer", order = 1)]
public class InputContainer : ScriptableObject
{
    public Dictionary<MoveType, string> inputList;
    public MoveType[] moves;
    public string[] keys;

    public void ResetInputs()
    {
        inputList = new Dictionary<MoveType, string>();
    }

    public void SetInputs(MoveType move, string input)
    {
        inputList.Add(move, input);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_FSM>().SetInput(move, input);
        //añadir al script de personaje
        //la siguiente funcion es temporaria
        if (!IsEmpty())
        {
            Debug.Log("Inputs not empty now");
        }
    }

    public void InitiateInputs()
    {
        //añadir al script de personaje
        int j = 0;
        inputList = new Dictionary<MoveType, string>();
        foreach (string x in keys)
        {
            inputList.Add(moves[j], keys[j]);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_FSM>().SetInput(moves[j], keys[j]);
            j++;
        }
    }

    public void SaveInputs()
    {
        moves = new MoveType[inputList.Count];
        keys = new string[inputList.Count];
        int i = 0;
        foreach (System.Collections.Generic.KeyValuePair<MoveType, string> ms in inputList)
        {
            moves[i] = ms.Key;
            keys[i] = ms.Value;
            i++;
        }
    }

    public void DeleteInputs()
    {
        ResetInputs();
        moves = new MoveType[0];
        keys = new string[0];
    }

    public bool IsEmpty()
    {
        return moves.Length == 0;
    }
}
