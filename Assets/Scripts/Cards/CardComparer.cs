using UnityEngine;
using System;
using System.Collections.Generic;

public class CardComparer {

    public List<Card> cards = new List<Card>(2);

    private Action<bool> compareCallback;


    public CardComparer(Action<bool> compareCallback) {
        this.compareCallback = compareCallback;
    }


    public void AddCard(Card card) {
        cards.Add(card);

        if (cards.Count == 2)
            Compare();
    }

    private void Compare() {
        bool result = cards[0].Image == cards[1].Image;
        compareCallback.Invoke(result);

        if (result)
            cards.Clear();
    }
}
