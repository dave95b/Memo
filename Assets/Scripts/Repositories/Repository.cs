using UnityEngine;
using System.Collections;

public abstract class Repository<T> : ScriptableObject {

    public T[] Items;
}
