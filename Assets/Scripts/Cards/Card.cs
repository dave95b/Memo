using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler {

    private Sprite image;
    public Sprite Image {
        get { return image; }
        set {
            image = value;
            childSpriteRenderer.sprite = image;
        }
    }

    private Sprite backImage;
    public Sprite BackImage {
        set {
            backImage = value;
            spriteRenderer.sprite = backImage;
        }
    }

    public int SortingOrder {
        set {
            spriteRenderer.sortingOrder = value;
            childSpriteRenderer.sortingOrder = value + 1;
        }
    }

    [SerializeField]
    private Sprite frontImage;
    [SerializeField]
    private GameObject childImage;

    public CardEvent OnClick;

    private Animator animator;
    private SpriteRenderer spriteRenderer, childSpriteRenderer;
    private bool isSelected;


    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        childSpriteRenderer = childImage.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    public void ShowFront() {
        animator.SetBool("Show", true);
    }

    public void ShowBack() {
        animator.SetBool("Show", false);
    }


    public void OnPointerDown(PointerEventData eventData) {
        if (!isSelected) {
            OnClick.Invoke(this);
        }
    }


    private void SwapImages() {
        bool showFront = !childImage.activeInHierarchy;
        Sprite cardSprite = showFront ? frontImage : backImage;

        spriteRenderer.sprite = cardSprite;
        childImage.SetActive(showFront);
        isSelected = showFront;
    }
}
