using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    private static string _replace = "{0}";
    private string _systemLanguage = "English";

    private List<Dictionary<string, object>> _localizationData;
    
    private static LocalizationManager _instance;

    public static LocalizationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LocalizationManager();
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this);
        }

        _localizationData = CSVReader.Read("Localization");
        SetLocalization();
    }

    public string GetMessage(int index) {
        return _localizationData[index][_systemLanguage].ToString();
    }

    public string GetMessageWithKeyword(int index, string keyword) {
        return _localizationData[index][_systemLanguage].ToString().Replace(_replace, keyword);
    }

    private void SetLocalization()
    {
        SystemLanguage language = Application.systemLanguage;

        switch (language) {
            case SystemLanguage.Korean:
                _systemLanguage = language.ToString();
                for (int i = 0; i < _localizationData.Count; i++) _localizationData[i][_systemLanguage].ToString();
                break;

            default: // English
                for (int i = 0; i < _localizationData.Count; i++) _localizationData[i][_systemLanguage].ToString();
                break;
        }
    }
}