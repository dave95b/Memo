using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ThemeChooser : MonoBehaviour {

    [SerializeField]
    private SpriteRepository repository;

    [SerializeField]
    private Theme theme;

    [SerializeField]
    private Button buttonPrefab;


    private void Start() {
        InstantiateChildren(repository.Items.Length);
    }

    private void InstantiateChildren(int amount) {
        for (int i = 0; i < amount; i++) {
            Button child = Instantiate(buttonPrefab, transform);
            Sprite sprite = repository.Items[i];

            child.image.sprite = sprite;
            child.onClick.AddListener(() => SelectTheme(sprite));
        }
    }

    private void SelectTheme(Sprite newCardBack) {
        theme.CardBack = newCardBack;
    }
}
