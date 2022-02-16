using UnityEngine;

namespace ServiceLocatorPath
{
    public class SaveDataPlayerPref : ISaveData
    {
        public void Save(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }

        public void SaveFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }

        public float GetFloat(string key)
        {
            return PlayerPrefs.GetFloat(key);
        }
    }
}