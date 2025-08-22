using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    [SerializeField] private TMP_Text questionText;
    private int stepIndex = 0;
    public List<ChoiceSet> Sets = new List<ChoiceSet>();
    public List<ChoiceUI> UIs = new List<ChoiceUI>();

    private void Start()
    {
        InitializeChoices();
    }

    public void InitializeChoices()
    {
        int choiceCount = 0;
        questionText.text = Sets[stepIndex].SetQuistion;
        foreach (var ui in UIs)
        {
            ui.InitializeNew(Sets[stepIndex].Choices[choiceCount]);
            ui.OnClicked += EvaluateClick;
            choiceCount++;
        }
    }
    private void EvaluateClick(bool isCorrect)
    {
        if (isCorrect)
        {
            NextStep();
        }
        else
        {
            Debug.LogWarning("A ROBOT!!!");
        }

        foreach (var ui in UIs)
        {
            ui.OnClicked -= EvaluateClick;
        }
    }

    private void NextStep()
    {

        stepIndex++;
        if (stepIndex >= Sets.Count)
        {
            Debug.Log("Good job!");
            return;
        }
        InitializeChoices();
    }
}
