# localization-csv-unity
- This project is .csv based localization system for Unity

1. 'CSVReader.cs' reads the 'localization.csv' in the Resources folder.
2. 'localization.csv' must be entered from the second column except for the first column, and the first row should be filled in with the local name.
3. Add a local as shown in the example in the switch-case statement in the 'LocalizationManager.cs'.
```cs
switch (language)
{
    case SystemLanguage.Korean:
        _systemLanguage = language.ToString();
        for (int i = 0; i < _localizationData.Count; i++) _localizationData[i][_systemLanguage].ToString();
        break;

    default: // English
        for (int i = 0; i < _localizationData.Count; i++) _localizationData[i][_systemLanguage].ToString();
        break;
}
```
4. Use in 'UIManager.cs' as follows:
```cs
// Enter an index number of the 'localization.csv'
local.text = LocalizationManager.Instance.GetMessage(INDEX);

// Enter the index and keyword of the 'localization.csv'
// Keywords are written as '{0}' in the 'localization.csv'
local2.text = LocalizationManager.Instance.GetMessageWithKeyword(INDEX, KEYWORD);
```
