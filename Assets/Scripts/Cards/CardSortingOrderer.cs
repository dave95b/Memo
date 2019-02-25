using UnityEngine;

public class CardSortingOrderer : MonoBehaviour {

    private void Start() {
        Card[] cards = GetComponentsInChildren<Card>();

        int order = 0;
        foreach (Card card in cards) {
            card.SortingOrder = order;
            order += 2;
        }

        Destroy(this);
    }
}
