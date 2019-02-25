using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {

    
    public void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenuScene() {
        SceneManager.LoadScene(0);
    }

    public void LoadGameScene() {
        SceneManager.LoadScene(1);
    }
}
