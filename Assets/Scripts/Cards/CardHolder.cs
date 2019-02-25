using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour {

    [SerializeField]
    private GameMode gameMode;

    private void Start() {
        Instantiate(gameMode.CardsPrefab, transform);
    }
}
