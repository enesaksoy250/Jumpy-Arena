using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{

    Button languageButton;
    TextMeshProUGUI languageText;

    private void Awake()
    {
        languageButton = GetComponent<Button>();
        languageText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {

        SetLanguageButtonText();
        languageButton.onClick.AddListener(delegate { LanguageButtons(); }); 
    }

   
    public void LanguageButtons()
    {

        string language = PlayerPrefs.GetString("Language","English");

        if(language == "English")
        {

            PlayerPrefs.SetString("Language", "Turkish");
            LanguageManager.instance.LoadLocalizedText(PlayerPrefs.GetString("Language"));
            UILanguageManager[] użLanguageManager = FindObjectsOfType<UILanguageManager>();

            foreach (UILanguageManager manager in użLanguageManager)
            {

                manager.UpdateText();

            }
            languageText.text = "TURKCE";

        }

        else if(language == "Turkish")
        {

            PlayerPrefs.SetString("Language", "English");
            LanguageManager.instance.LoadLocalizedText(PlayerPrefs.GetString("Language"));
            languageText.text = "ENGLISH";

        }

        UILanguageManager[] użLanguageManagers = FindObjectsOfType<UILanguageManager>();

        foreach (UILanguageManager manager in użLanguageManagers)
        {

            manager.UpdateText();

        }

    }

    private void SetLanguageButtonText()
    {

        string currentLanguage = PlayerPrefs.GetString("Language","English");

        if (currentLanguage == "English")
        {

            languageText.text = "ENGLISH";

        }

        else if (currentLanguage == "Turkish")
        {

            languageText.text = "TURKCE";

        }


    }
}
