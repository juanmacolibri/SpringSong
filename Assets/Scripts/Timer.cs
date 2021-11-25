using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float setTime = 5;
    public float timer;
    public bool thisIsTrue;

    void Update()
    {
        if(thisIsTrue) TimerMethod(setTime);
    }

    void TimerMethod(float timeToReach)
    {
        if (timer <= timeToReach)
        {
            timer += Time.deltaTime;
            Debug.Log("Lalalaa" + timer);
            if (timer >= timeToReach)
            {
                timer = 0;
                thisIsTrue = false;
            }
        }
    }
}
