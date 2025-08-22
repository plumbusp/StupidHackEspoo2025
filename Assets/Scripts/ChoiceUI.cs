using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChoiceUI : MonoBehaviour
{
    public event Action OnClicked;
    [SerializeField] private Image image;

    public bool isCorrect { get; private set; }
    private Button button;
    
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => OnClicked?.Invoke());
        OnClicked += ResetButton;
    }
    private void OnDestroy()
    {
        OnClicked -= ResetButton;
        button.onClick.RemoveAllListeners();
    }
    public void InitializeNew(ChoiceObject choice)
    {
        image.sprite = choice.Sprite;
        isCorrect = choice.correctChoice;
    }
    private void ResetButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
