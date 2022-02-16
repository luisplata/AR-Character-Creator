using System;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public delegate void ButtonClick();

    public ButtonClick onAnimLess, onAnimMore;
    public ButtonClick onCharacterLess, onCharacterMore;
    public ButtonClick onScaleLess, onScaleMore;

    public void AnimLess()
    {
        Debug.Log("click");
        onAnimLess?.Invoke();
    }
    public void AnimMore()
    {
        Debug.Log("click");
        onAnimMore?.Invoke();
    }
    public void CharacterLess()
    {
        Debug.Log("click");
        onCharacterLess?.Invoke();
    }
    public void CharacterMore()
    {
        Debug.Log("click");
        onCharacterMore?.Invoke();
    }
    public void ScaleLess()
    {
        Debug.Log("click");
        onScaleLess?.Invoke();
    }
    public void ScaleMore()
    {
        Debug.Log("click");
        onScaleMore?.Invoke();
    }
}
