using System;
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
        [SerializeField] private DebugText debug;
        private void Awake()
        {
            try
            {
                if (FindObjectsOfType<InstallerServiceLocator>().Length > 1)
                {
                    Destroy(gameObject);
                    return;
                }
                debug.Log("start service");
                var saveData = new SaveDataPlayerPref();
                debug.Log("SaveDataPlayerPref");
                var animationController = new AnimationsController(clips);
                debug.Log("AnimationsController");
                //showingErrors.Configurate();
                debug.Log("Configurate");
                characterFactory.Configurate(Instantiate(configurationOfCharacters));
                ServiceLocator.Instance.RegisterService<ICharacterFactory>(characterFactory);
                debug.Log("ICharacterFactory");
                ServiceLocator.Instance.RegisterService<ISaveData>(saveData);
                debug.Log("ISaveData");
                ServiceLocator.Instance.RegisterService<IShowErrors>(showingErrors);
                debug.Log("IShowErrors");
                ServiceLocator.Instance.RegisterService<ILocalization>(showingErrors);
                debug.Log("ILocalization");
                ServiceLocator.Instance.RegisterService<IAnimations>(animationController);
                debug.Log("IAnimations");
                ServiceLocator.Instance.RegisterService<IDebugText>(debug);
                debug.Log("IDebugText");
                DontDestroyOnLoad(gameObject);
                debug.Log("save all service register");
            }
            catch (Exception e)
            {
                showingErrors.ShowError(e.Message);
            }
        }
    }
}