using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(order = 160)]
public class GameEvent : ScriptableObject {

    private readonly List<GameEventListener> listeners = new List<GameEventListener>();


    [ContextMenu("Invoke")]
    public void Invoke() {
        int count = listeners.Count;
        for (int i = count - 1; i >= 0; i--)
            listeners[i].Response.Invoke();
    }

    public void RegisterListener(GameEventListener listener) {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener) {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }
}
