using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverSubjects : MonoBehaviour
{
    public List<IObserver> observers = new List<IObserver>();
        
    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }
    
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
    
    public void NotifyObservers(GameConditionEnum gameConditionEnum)
    {
        foreach (var observer in observers)
        {
            observer.AddNotify(gameConditionEnum);
        }
    }
}
