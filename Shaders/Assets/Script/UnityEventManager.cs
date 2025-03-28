using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DelayedEvent
{
    public UnityEvent unityEvent; 
    public float delay; 
}

public class UnityEventManager : MonoBehaviour
{
    public List<DelayedEvent> events = new List<DelayedEvent>(); 

    public void InvokeAllEvents()
    {
        foreach (var delayedEvent in events)
        {
            StartCoroutine(InvokeEventWithDelay(delayedEvent));
        }
    }

    private IEnumerator InvokeEventWithDelay(DelayedEvent delayedEvent)
    {
        yield return new WaitForSeconds(delayedEvent.delay);
        delayedEvent.unityEvent?.Invoke();
    }
}