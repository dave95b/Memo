using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardsController : MonoBehaviour {

    [SerializeField]
    private SpriteRepository repository;

    [SerializeField]
    private BoolValue cardsMatched, selectingEnabled;

    [SerializeField]
    private IntValue remainingPairs;

    [SerializeField]
    private Theme theme;

    [SerializeField]
    private GameEvent OnGameOver;


    private Card[] cards;
    private CardComparer comparer;
    private PairCounter pairCounter;
    private WaitForSeconds hideCardsDelay = new WaitForSeconds(1.25f);


	void Start () {
        comparer = new CardComparer(CardComparerCallback);
        InitCards();
        remainingPairs.Value = cards.Length / 2;
        pairCounter = new PairCounter(remainingPairs, OnGameOver);
    }

	
    private void InitCards() {
        cards = GetComponentsInChildren<Card>();

        cards.Shuffle();
        repository.Items.Shuffle();

        int j = 0;
        for (int i = 0; i < cards.Length; i++) {
            Card first = cards[i];
            Card second = cards[++i];

            first.Image = repository.Items[j];
            second.Image = repository.Items[j];

            first.OnClick.AddListener(comparer.AddCard);
            second.OnClick.AddListener(comparer.AddCard);
            j++;

            first.BackImage = theme.CardBack;
            second.BackImage = theme.CardBack;
        }
    }

    private void CardComparerCallback(bool success) {
        cardsMatched.Value = success;

        if (success)
            pairCounter.Decrement();
        else
            StartCoroutine(HideCards());
    }

    private IEnumerator HideCards() {
        selectingEnabled.Value = false;

        yield return hideCardsDelay;

        foreach (Card card in comparer.cards)
            card.ShowBack();

        comparer.cards.Clear();
        selectingEnabled.Value = true;
    }
}
