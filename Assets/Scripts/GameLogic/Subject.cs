using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Subject : MonoBehaviour
{
    private List<IObserver> Observers=new List<IObserver>();
    public void AddObserver(IObserver Observer){
        Observers.Add(Observer);
    }

    public void RemoveObserver(IObserver Observer){
        Observers.Remove(Observer);
    }

    protected void NotifyAll(string Event){
        foreach(IObserver Observer in Observers){
            Observer.OnNotify(Event);
        }
    }
}
