using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CounterTime
{
    //UnityAction doneAction;
    private float time;
    private float counter;
    public bool IsRunning => counter > 0;

    //public void Start(UnityAction doneAction, float time)
    //{
    //    this.doneAction = doneAction;
    //    this.time = time;
    //}
    public CounterTime(float time)
    { 
        this.time = time;
        this.counter = time;
    }

    public void Execute()
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                Exit();
            }
        }
    }
    public void StartCount()
    {
        //Debug.Log(counter);
        if (counter > 0)
        {
            counter -= 1 * Time.deltaTime;
            
            if (counter <= 0)
            {
                //Debug.Log("0000");
            }
        }
    }
    public void ResetCounter()
    {
        counter = time;
    }
    public void Exit()
    {
        //doneAction?.Invoke();
    }

    public void Cancel()
    {
        //doneAction = null;
        time = -1;
        counter = -1;
    }
}
