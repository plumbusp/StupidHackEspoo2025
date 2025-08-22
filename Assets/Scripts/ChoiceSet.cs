using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ChoiceSet", menuName = "ChoiceSet")]
public class ChoiceSet : ScriptableObject
{
    public List<ChoiceObject> Choices = new List<ChoiceObject>();
}
