using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocatorPath
{
    public class InstallerServiceLocator : MonoBehaviour
    {
        [SerializeField] private ShowingErrors showingErrors;
        [SerializeField] private List<AnimationClip> clips;
        [SerializeField] private Factory characterFactory;
        [SerializeField] private CharactersConfiguration configurationOfCharacters;
        private void Awake()
        {
            if (FindObjectsOfType<InstallerServiceLocator>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            var saveData = new SaveDataPlayerPref();
            var animationController = new AnimationsController(clips);
            showingErrors.Configurate();
            characterFactory.Configurate(Instantiate(configurationOfCharacters));
            ServiceLocator.Instance.RegisterService<ISaveData>(saveData);
            ServiceLocator.Instance.RegisterService<IShowErrors>(showingErrors);
            ServiceLocator.Instance.RegisterService<ILocalization>(showingErrors);
            ServiceLocator.Instance.RegisterService<IAnimations>(animationController);
            ServiceLocator.Instance.RegisterService<ICharacterFactory>(characterFactory);
            DontDestroyOnLoad(gameObject);
            Debug.Log("save all service");
        }
    }
}