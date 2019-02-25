using System;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableValue<T> : ScriptableObject {

    [SerializeField]
    private T value;
    public T Value {
        get { return value; }
        set {
            this.value = value;

            if (OnValueChanged != null)
                OnValueChanged.Invoke(value);
        }
    }

    public event Action<T> OnValueChanged;
}