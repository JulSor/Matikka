using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThemeColors : MonoBehaviour
{
    //public Main main;


    //  NAVBAR PANEL COLORS ----------- [0 IS DEFAULT BLUE], [1] IS PINK, [2] IS YELLOW, [3] IS PURPLE
    [System.NonSerialized] public Color32[] navBarColors = 
    { 
        new Color32(93, 183, 255, 255), 
        new Color32(255, 107, 225, 255), 
        new Color32(255, 200, 64, 255), 
        new Color32(143, 98, 255, 255) 
    };

    //  BODYPANEL COLORS ----------- [0] IS DEFAULT BLUE, [1] IS PINK, [2] IS YELLOW, [3] IS PURPLE
    [System.NonSerialized] public Color32[] bodyColors = 
    { 
        new Color32(179, 224, 255, 255), 
        new Color32(253, 161, 236, 255), 
        new Color32(255, 221, 138, 255), 
        new Color32(175, 143, 255, 255) 
    };

    public GameObject navBarPanel;
    public GameObject bodyPanel;
    public GameObject dropdown;
    public GameObject inputField;

    public Button[] variNapit;

    public static int colorIndex;
    public static string colorKey = "taustaVari";

    void Start()
    {
        HaeVarit();

        Scene scene = SceneManager.GetActiveScene();

        navBarPanel.GetComponentInChildren<Image>().color = navBarColors[colorIndex];
        bodyPanel.GetComponentInChildren<Image>().color = bodyColors[colorIndex];

        if (scene.buildIndex == 1 || scene.buildIndex == 2 || scene.buildIndex == 3 || scene.buildIndex == 4)
        {
            dropdown.GetComponentInChildren<Image>().color = bodyColors[colorIndex];
            inputField.GetComponentInChildren<Image>().color = bodyColors[colorIndex];
        }
    }

    public void HaeVarit()
    {
        colorIndex = PlayerPrefs.GetInt(colorKey);
        PlayerPrefs.Save();
    }
    public void TallennaTaustaVari()
    {
        PlayerPrefs.SetInt(colorKey, colorIndex);
        PlayerPrefs.Save();
    }
    public void TaustaDefaultBlue()
    {
        colorIndex = 0;
        navBarPanel.GetComponentInChildren<Image>().color = navBarColors[colorIndex];
        bodyPanel.GetComponentInChildren<Image>().color = bodyColors[colorIndex];
        TallennaTaustaVari();
    }
    
    public void TaustaPinkiksi()
    {
        colorIndex = 1;
        navBarPanel.GetComponentInChildren<Image>().color = navBarColors[colorIndex];
        bodyPanel.GetComponentInChildren<Image>().color = bodyColors[colorIndex];
        TallennaTaustaVari();
    }
    public void TaustaKeltaiseksi()
    {
        colorIndex = 2;
        navBarPanel.GetComponentInChildren<Image>().color = navBarColors[colorIndex];
        bodyPanel.GetComponentInChildren<Image>().color = bodyColors[colorIndex];
        TallennaTaustaVari();
    }
    public void TaustaLilaksi()
    {
        colorIndex = 3;
        navBarPanel.GetComponentInChildren<Image>().color = navBarColors[colorIndex];
        bodyPanel.GetComponentInChildren<Image>().color = bodyColors[colorIndex];
        TallennaTaustaVari();
    }

}
