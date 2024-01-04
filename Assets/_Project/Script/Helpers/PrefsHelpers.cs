using UnityEngine;

namespace BelumProduktif.Helpers
{
    public static class PrefsHelpers
    {
        #region Int Prefs
        public static void InitIntPrefs(string key, int value)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.SetInt(key,value);
            }
        }
        
        public static void SetIntPrefs(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }
        
        public static int GetIntPrefs(string key)
        {
            return PlayerPrefs.GetInt(key);
        }
        #endregion

        #region Float Prefs
        public static void InitFloatPrefs(string key, float value)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.SetFloat(key,value);
            }
        }
        
        public static void SetFloatPrefs(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }
        
        public static float GetFloatPrefs(string key)
        {
            return PlayerPrefs.GetFloat(key);
        }
        #endregion

        #region String Prefs
        public static void InitStringPrefs(string key, string value)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.SetString(key,value);
            }
        }
        
        public static void SetStringPrefs(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }
        
        public static string GetStringPrefs(string key)
        {
            return PlayerPrefs.GetString(key);
        }
        #endregion
    }
}