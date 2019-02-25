using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverView : MonoBehaviour {

    [SerializeField]
    private IntValue score;
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private GameObject panel;



    public void Show() {
        scoreText.text = "Your Score: \n" + score.Value;
        StartCoroutine(ShowCoroutine());
    }

    private IEnumerator ShowCoroutine() {
        yield return new WaitForSeconds(1f);

        GetComponent<Image>().enabled = true;
        panel.SetActive(true);
    }
}
