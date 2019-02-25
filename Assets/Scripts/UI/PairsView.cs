using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PairsView : MonoBehaviour {

    [SerializeField]
    private IntValue remainingPairs;

    private Text text;
    private const string textPrefix = "Remaining pairs: ";


    private void Start() {
        text = GetComponent<Text>();
        remainingPairs.OnValueChanged += UpdatePairsText;
        UpdatePairsText(remainingPairs.Value);
    }

    private void UpdatePairsText(int pairsLeft) {
        text.text = textPrefix + pairsLeft;
    }


    private void OnDestroy() {
        remainingPairs.OnValueChanged -= UpdatePairsText;
    }
}
