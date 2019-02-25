using UnityEngine;
using System.Collections;

public class CardCollisionDetector : MonoBehaviour {

    [SerializeField]
    private CardMover cardMover;


    private void OnCollisionEnter2D(Collision2D collision) {
        Vector3 normal = collision.contacts[0].normal;
        cardMover.ReflectCard(collision.transform, normal);
    }
}
