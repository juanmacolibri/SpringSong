using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjects/SaveData", order = 2)]
public class SaveData : ScriptableObject
{
    public bool dataExists;
    public InputContainer IP;
    public Vector3 birbPosition;
    public List<string> learningAreas, deadObjects;
}
