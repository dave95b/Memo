using UnityEngine;
using System.Linq;
using System.Collections;


public class CardMover : MonoBehaviour {

    private MovingCard[] movingCards;
    private const float speedModifier = 0.03f;


    void Start() {
        CreateMovingCards();
        StartCoroutine(SetMovementVectors());
    }

    private void Update() {
        MoveCards();
    }


    public void ReflectCard(Transform cardTransform, Vector3 collisionNormal) {
        MovingCard card = movingCards.First(c => c.Transform == cardTransform);
        card.MovementVector = Vector3.Reflect(card.MovementVector, collisionNormal);
    }

    private void CreateMovingCards() {
        Card[] cards = GetComponentsInChildren<Card>();
        int cardCount = cards.Length;
        movingCards = new MovingCard[cardCount];

        for (int i = 0; i < cardCount; i++)
            movingCards[i] = new MovingCard(cards[i].transform);
    }

    private IEnumerator SetMovementVectors() {
        yield return new WaitForSeconds(1f);

        foreach (var card in movingCards) {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            Vector3 vector = new Vector3(x, y, 0) * speedModifier;

            card.MovementVector = vector;
        }
    }

    private void MoveCards() {
        foreach (var card in movingCards) {
            card.Transform.Translate(card.MovementVector);
        }
    }
}
