using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using UnityEngine.UI;

[Game, Unique]
public class UIElementsComponent : IComponent
{
    public ProgressBarPro PlayerHealthSlider;
    public GameObject LoosePanel;
    public BuildPanel BuildPanel;
}