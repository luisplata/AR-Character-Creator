using System.Collections;
using System.Collections.Generic;
using ServiceLocatorPath;
using UnityEngine;

public class PjController : MonoBehaviour
{
    private EnemyController character;
    private UiController _uiController;

    public void Configure(UiController uiController)
    {
        _uiController = uiController;
        character = ServiceLocator.Instance.GetService<ICharacterFactory>().Create("0");
        character.gameObject.transform.SetParent(transform);
        character.Configure();
        _uiController.onAnimLess += () =>
        {
            Debug.Log("animLess");
            character.PlayPreviousAnim();
        };
        _uiController.onAnimMore += () =>
        {
            Debug.Log("animMore");
            character.PlayNextAnim();
        };
        _uiController.onScaleLess += () =>
        {
            gameObject.transform.localScale *= 0.5f;
        };
        _uiController.onScaleMore += () =>
        {
            gameObject.transform.localScale /= 0.5f;
        };
        
        _uiController.onCharacterLess += () =>
        {
            Destroy(character.gameObject);
            character = ServiceLocator.Instance.GetService<ICharacterFactory>().GetPreviousCharacter();
            character.gameObject.transform.SetParent(transform);
            character.Configure();
        };
        _uiController.onCharacterMore += () =>
        {
            Destroy(character.gameObject);
            character = ServiceLocator.Instance.GetService<ICharacterFactory>().GetNextCharacter();
            character.gameObject.transform.SetParent(transform);
            character.Configure();
        };
        
        gameObject.transform.localScale =
            Vector3.one * ServiceLocator.Instance.GetService<ISaveData>().GetFloat("scale");
    }
}
