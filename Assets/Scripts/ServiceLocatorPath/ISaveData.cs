namespace ServiceLocatorPath
{
    public interface ISaveData
    {
        void Save(string key, string value);
        void SaveFloat(string key, float value);
        float GetFloat(string key);
    }
}