using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class GameEventListener : MonoBehaviour {

    public GameEvent Event;
    public UnityEvent Response;


    private void OnEnable() {
        if (Event != null)
            Event.RegisterListener(this);
    }

    private void OnDisable() {
        if (Event != null)
            Event.UnregisterListener(this);
    }
}
