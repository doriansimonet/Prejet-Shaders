using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void InvokeUnityEventManager(UnityEventManager eventManager)
    {
        eventManager.InvokeAllEvents();
    }
}