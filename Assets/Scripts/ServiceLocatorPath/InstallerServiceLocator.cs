using UnityEngine;

namespace ServiceLocatorPath
{
    public class InstallerServiceLocator : MonoBehaviour
    {
        [SerializeField] private ShowingErrors showingErrors;
        private void Awake()
        {
            if (FindObjectsOfType<InstallerServiceLocator>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            var saveData = new SaveDataPlayerPref();
            showingErrors.Configurate();
            ServiceLocator.Instance.RegisterService<ISaveData>(saveData);
            ServiceLocator.Instance.RegisterService<IShowErrors>(showingErrors);
            ServiceLocator.Instance.RegisterService<ILocalization>(showingErrors);
            DontDestroyOnLoad(gameObject);
            Debug.Log("save all service");
        }
    }
}