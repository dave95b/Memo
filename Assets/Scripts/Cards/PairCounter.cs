using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PairCounter {

    private IntValue remainingPairs;
    private GameEvent onGameOver;

    public PairCounter(IntValue remainingPairs, GameEvent onGameOver) {
        this.remainingPairs = remainingPairs;
        this.onGameOver = onGameOver;
    }


    public void Decrement() {
        remainingPairs.Value--;
        if (remainingPairs.Value == 0)
            onGameOver.Invoke();
    }
}
