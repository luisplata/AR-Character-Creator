using ServiceLocatorPath;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class MainMenuRules : MonoBehaviour
{
    [SerializeField] private Animator optionsAnimator;
    [SerializeField] private TMP_InputField inputScale;
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SaveScaleObjects()
    {
        Debug.Log("Salvo");
        if (float.TryParse(inputScale.text, out var f))
        {
            ServiceLocator.Instance.GetService<ISaveData>().SaveFloat("scale", f);
            return;
        }

        ServiceLocator.Instance.GetService<IShowErrors>().ShowError(ServiceLocator.Instance.GetService<ILocalization>().Get("error_numero_invalido"));
    }

    public void Open()
    {
        optionsAnimator.SetBool("open", true);
    }

    public void Close()
    {
        optionsAnimator.SetBool("open", false);
    }

    public void ChangeLanguageTo(string languageIdentifier)
    {
        LocalizationSettings settings = LocalizationSettings.Instance;
        LocaleIdentifier localeCode = new LocaleIdentifier(languageIdentifier);//can be "en" "de" "ja" etc.
        for(int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        {
            Locale aLocale = LocalizationSettings.AvailableLocales.Locales[i];
            LocaleIdentifier anIdentifier = aLocale.Identifier;
            if(anIdentifier == localeCode)
            {
                LocalizationSettings.SelectedLocale = aLocale;
            }
        }
    }

}