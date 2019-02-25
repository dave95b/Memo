using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour {

    [SerializeField]
    private BoolValue cardsMatched;
    [SerializeField]
    private IntValue score;

    [SerializeField]
    private int correctValue, incorrectValue;

    private Text scoreText;
    private const string scorePrefix = "Score: ";


    private void Start() {
        score.Value = 0;
        scoreText = GetComponent<Text>();
        cardsMatched.OnValueChanged += UpdateScore;
    }

    private void UpdateScore(bool matched) {
        if (matched)
            score.Value += correctValue;
        else
            score.Value = Mathf.Max(0, score.Value - incorrectValue);

        scoreText.text = scorePrefix + score.Value;
    }

    private void OnDestroy() {
        cardsMatched.OnValueChanged -= UpdateScore;
    }
}
