using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System;

public class GameModeChooser : MonoBehaviour {

    [SerializeField]
    private GameModeRepository repository;

    [SerializeField]
    private GameMode gameMode;

    [SerializeField]
    private Dropdown gameModeDropdown;
    [SerializeField]
    private Text dropdownLabel;


    private void Start() {
        InitDropdown();
    }


    private void InitDropdown() {
        gameModeDropdown.options.Clear();
        foreach (var gameMode in repository.Items) {
            var option = new Dropdown.OptionData(gameMode.name);
            gameModeDropdown.options.Add(option);
        }

        gameModeDropdown.onValueChanged.AddListener(SelectGameMode);
        gameModeDropdown.value = Array.IndexOf(repository.Items, gameMode.CardsPrefab.GetComponent<CardsController>());
        dropdownLabel.text = gameMode.CardsPrefab.name;
    }

    private void SelectGameMode(int index) {
        gameMode.CardsPrefab = repository.Items[index].gameObject;
    }
}
