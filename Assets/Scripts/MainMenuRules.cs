using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuRules : MonoBehaviour
{
    [SerializeField] private Animator optionsAnimator;
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }


    public void Open()
    {
        optionsAnimator.SetBool("open", true);
    }

    public void Close()
    {
        optionsAnimator.SetBool("open", false);
    }

    public void ChangeLanguageTo(int language)
    {
        switch (language)
        {
            case 0://English
                break;
            case 1://spanish
                break;
        }
    }
}
