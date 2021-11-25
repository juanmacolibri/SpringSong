using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavaManager : MonoBehaviour
{
    [SerializeField] SaveData SD;
    List<string> tempAreaList, tempObjectList;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        tempAreaList = new List<string>();
        tempObjectList = new List<string>();
        if (SD.dataExists)
        {
            Debug.Log("data exists");
            GameObject.FindGameObjectWithTag("Player").transform.position = SD.birbPosition;
            foreach (string g in SD.learningAreas)
            {
                GameObject.Find(g).GetComponent<AreaScript>().active = false;
            }
            foreach (string g in SD.deadObjects)
            {
                GameObject.Find(g).SetActive(false);
            }
        }
        if (!SD.IP.IsEmpty())
        {
            Debug.Log("Inputs not empty");
            SD.IP.InitiateInputs();
        }
        else
        {
            Debug.Log("Inputs empty");
            SD.IP.ResetInputs();
        }
    }

    private void Update()
    {
        // WARNING!!!! ADVERTENCIA
        //remover al buildear el juego. Simula la destruccion de los inputs cuando se completa el juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SD.IP.DeleteInputs();
            SD.dataExists = false;
        }
    }

    public void SaveGame(Vector3 pos)
    {
        Debug.Log(pos);
        SD.dataExists = true;
        SD.birbPosition = pos;
        SD.learningAreas = tempAreaList;
        SD.deadObjects = tempObjectList;
        SD.IP.SaveInputs();
    }

    public void NextLevel()
    {
        SD.dataExists = false;
        SD.birbPosition = Vector3.zero;
        SD.learningAreas = new List<string>();
    }

    public void AddArea(string g)
    {
        tempAreaList.Add(g);
    }

    public void AddObject(string g)
    {
        tempObjectList.Add(g);
    }
}
