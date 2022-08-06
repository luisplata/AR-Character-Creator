using System.Collections;
using System.Collections.Generic;
using ServiceLocatorPath;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RulesEscenaSinAR : MonoBehaviour
{
    [SerializeField] private GameObject pointToSpawn;
    private EnemyController character;
    private Vector3 currentScale = Vector3.one;

    void Start()
    {
        character = ServiceLocator.Instance.GetService<ICharacterFactory>().GetNextCharacter();
        character.transform.position = pointToSpawn.transform.position;
        character.transform.rotation = pointToSpawn.transform.rotation;
        character.transform.localScale = currentScale;
    }

    public void NextCharacter()
    {
        Destroy(character.gameObject);
        character = ServiceLocator.Instance.GetService<ICharacterFactory>().GetNextCharacter();

        character.transform.position = pointToSpawn.transform.position;
        character.transform.rotation = pointToSpawn.transform.rotation;
        character.transform.localScale = currentScale;
    }
    
    public void PreviousCharacter()
    {
        Destroy(character.gameObject);
        character = ServiceLocator.Instance.GetService<ICharacterFactory>().GetPreviousCharacter();
        
        character.transform.localPosition = pointToSpawn.transform.position;
        character.transform.localRotation = pointToSpawn.transform.rotation;
        character.transform.localScale = currentScale;
    }

    public void ScaleMore()
    {
        character.transform.localScale *= 2;
        currentScale = character.transform.localScale;
    }
    
    public void ScaleLess()
    {
        character.transform.localScale /= 2;
        currentScale = character.transform.localScale;
    }

    public void AnimationNext()
    {
        character.PlayNextAnim();
    }

    public void AnimationPrevious()
    {
        character.PlayPreviousAnim();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
