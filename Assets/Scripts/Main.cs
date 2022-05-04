using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{   /*******************************INT INT INT INT INT INT INT INT INT INT INT INT INT INT *********************************************************/
    // public int[] additionNums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    // public int[] additionNumsForAdv = { 0, 1, 2, 3, 4, 5, 6 };
    // public int[] declarationNums1 = { 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    // public int[] declarationNums2 = { 0, 1, 2, 3, 4, 5, 6, 7 };
    // public int[] multiplicationNums1 = { 1, 2, 3, 4};
    // public int[] multiplicationNums2 = { 1, 2, 3, 4, 5, 6, 7};

    public int ekaLuku;
    public int tokaLuku;
    public int kolmasLuku;
    public int oikeaVastaus;
    public int kayttajanVastaus;
    public int starScore;

    /*******************************STRINGS STRINGS STRINGS STRINGS STRINGS STRINGS STRINGS *********************************************************/
    public string key = "score";

    /*******************************GAMEOBJECTS GAMEOBJECTS GAMEOBJECTS GAMEOBJECTS GAMEOBJECTS *********************************************************/
    public GameObject seuraavaNappula;
    public GameObject star;
    public GameObject starCounter;


    /*******************************TMP TMP TMP TMP TMP TMP TMP TMP TMP TMP TMP TMP TMP TMP *********************************************************/
    public TextMeshProUGUI lasku;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI kauppaPisteet; //Sama kuin starScore

    public TMP_InputField input;

    public TMP_Dropdown dropdown;

    /*******************************AUDIOT AUDIOT AUDIOT AUDIOT AUDIOT AUDIOT AUDIOT AUDIOT*********************************************************/
    public AudioClip kazing;
    public AudioSource audioSource;

    public TouchScreenKeyboard keyboard;
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

            HaePisteet();
            ResetoiVari();
            PiilotaNappula();
            AktivoiInputField();

        if (scene.buildIndex == 1) 
        {
            UusiYhteenLasku();
        }
        if (scene.buildIndex == 2)
        {
            UusiVahennysLasku();
        }
        if (scene.buildIndex == 3)
        {
            UusiYhteenLaskuAdvanced();
        }
        if (scene.buildIndex == 4)
        {
            UusiKertoLasku();
        }
        if (scene.buildIndex == 5)
        {
            HaePisteetKauppaan();
        }
    }
    
    public void UusiYhteenLasku()
    {
        ekaLuku = Random.Range(0, 12);
        tokaLuku = Random.Range(0, 12);
        //ekaLuku = additionNums[Random.Range(0, additionNums.Length)];
        //tokaLuku = additionNums[Random.Range(0, additionNums.Length)];
        lasku.text = ekaLuku.ToString() + " + " + tokaLuku.ToString();
        oikeaVastaus = ekaLuku + tokaLuku;
        star.SetActive(false);
        AktivoiInputField();
        AvaaNumPad();
    }
    public void UusiKertoLasku()
    {
        ekaLuku = Random.Range(0, 5);
        tokaLuku = Random.Range(0, 6);
        //ekaLuku = multiplicationNums1[Random.Range(0, multiplicationNums1.Length)];
        //tokaLuku = multiplicationNums2[Random.Range(0, multiplicationNums2.Length)];
        lasku.text = ekaLuku.ToString() + " * " + tokaLuku.ToString();
        oikeaVastaus = ekaLuku * tokaLuku;
        star.SetActive(false);
        AktivoiInputField();
        AvaaNumPad();
    }
    public void UusiYhteenLaskuAdvanced()
    {
        ekaLuku = Random.Range(0, 8);
        tokaLuku = Random.Range(0, 8);
        kolmasLuku = Random.Range(0, 8);
        //ekaLuku = additionNumsForAdv[Random.Range(0, additionNumsForAdv.Length)];
        //tokaLuku = additionNumsForAdv[Random.Range(0, additionNumsForAdv.Length)];
        //kolmasLuku = additionNumsForAdv[Random.Range(0, additionNumsForAdv.Length)];
        lasku.text = ekaLuku.ToString() + " + " + tokaLuku.ToString() + " + " + kolmasLuku.ToString();
        oikeaVastaus = ekaLuku + tokaLuku + kolmasLuku;
        star.SetActive(false);
        AktivoiInputField();
        AvaaNumPad();
    }
    public void UusiVahennysLasku()
    {
        ekaLuku = Random.Range(8, 20);
        tokaLuku = Random.Range(0, 8);
        //ekaLuku = declarationNums1[Random.Range(0, declarationNums1.Length)];
        //tokaLuku = declarationNums2[Random.Range(0, declarationNums2.Length)];
        lasku.text = ekaLuku.ToString() + " - " + tokaLuku.ToString();
        oikeaVastaus = ekaLuku - tokaLuku;
        star.SetActive(false);
        AktivoiInputField();
        AvaaNumPad(); 
    }
    public void TarkistaVastaus()
    {
        kayttajanVastaus = int.Parse(input.text.ToString());
        if (kayttajanVastaus == oikeaVastaus)
        {
            VastausVihreaksi();
            NaytaNappula();
            Invoke("SoitaKazingAani", 0.25f);
            star.SetActive(true);
            StartCoroutine(MuutaTahdenKokoa());
            StartCoroutine(MuutaTahtilaskurinKokoa());
            PaivitaScore();
            TallennaPisteet();
            TouchScreenKeyboard.hideInput = true;
            keyboard.active = false;
            
        }
        else 
        { 
            VastausPunaiseksi();
        }
    }
    public void HaePisteet()
    {
        starScore = PlayerPrefs.GetInt(key);
        countText.text = starScore.ToString();
        PlayerPrefs.Save();
    }
    public void HaePisteetKauppaan()
    {
        starScore = PlayerPrefs.GetInt(key);
        kauppaPisteet.text = starScore.ToString();
        PlayerPrefs.Save();
    }
    public void TallennaPisteet()
    {
        PlayerPrefs.SetInt(key, starScore);
        PlayerPrefs.Save();
    }
    public void Vahenna50Pistetta()
    {
        if (starScore >= 50) {
            starScore -= 50;
        } else { return; }
        PlayerPrefs.SetInt(key, starScore);
        PlayerPrefs.Save();
    }
    public void DropDownScenes()
    {
        SceneManager.LoadScene(dropdown.value + 1);
    }
    public void VastausVihreaksi()
    {
        input.text = kayttajanVastaus.ToString();
        input.textComponent.color = new Color32(0, 255, 0, 255);
    }
    public void VastausPunaiseksi()
    {
        input.text = kayttajanVastaus.ToString();
        input.textComponent.color = new Color32(255, 0, 0, 255);
    }
    public void ResetoiVari()
    {
        input.textComponent.color = new Color32(0, 0, 0, 255);
        input.text = "";
    }
    public void NaytaNappula()
    {
        seuraavaNappula.gameObject.SetActive(true); 
    }
    public void PiilotaNappula()
    {
        seuraavaNappula.gameObject.SetActive(false);
    }
    public void AktivoiInputField()
    {
        input.ActivateInputField();
        input.Select();
    }
    public void AvaaNumPad()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad);
    }
    public void PaivitaScore()
    {
        starScore++;
        PlayerPrefs.SetInt(key, starScore);
        countText.text = starScore.ToString();
        PlayerPrefs.Save();
    }

    public void SoitaKazingAani()
    {
        audioSource.PlayOneShot(kazing, 0.7F);
    }
    public IEnumerator MuutaTahdenKokoa()  //todo muuta forloopiksi
    {
        star.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        yield return new WaitForSeconds(0.05f);
        star.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        yield return new WaitForSeconds(0.05f);
        star.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        yield return new WaitForSeconds(0.05f);
        star.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        yield return new WaitForSeconds(0.05f);
        star.transform.localScale = new Vector3(1f, 1f, 1f);
        yield return new WaitForSeconds(0.05f);
        star.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        yield return new WaitForSeconds(0.15f);
        star.SetActive(false);
    }
    public IEnumerator MuutaTahtilaskurinKokoa()  //todo muuta forloopiksi
    {
        yield return new WaitForSeconds(0.5f);
        starCounter.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        yield return new WaitForSeconds(0.05f);
        starCounter.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        yield return new WaitForSeconds(0.05f);
        starCounter.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public IEnumerator MuutaTahtilaskurinKokoaNopeasti()  //todo muuta forloopiksi
    {
        yield return new WaitForSeconds(0.5f);
        starCounter.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        yield return new WaitForSeconds(0.05f);
        starCounter.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        yield return new WaitForSeconds(0.05f);
        starCounter.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlusSceneLoader()
    {
        SceneManager.LoadScene("Yhteenlaskut");
    }
    public void AdvPlusSceneLoader()
    {
        SceneManager.LoadScene("AdvYhteenlaskut");
    }
    public void MiinusSceneLoader()
    {
        SceneManager.LoadScene("Vähennyslaskut");
    }
    public void KertoSceneLoader()
    {
        SceneManager.LoadScene("Kertolaskut");
    }
    public void KauppaSceneLoader()
    {
        SceneManager.LoadScene("Kauppa");
    }
    public void VariKauppaSceneLoader()
    {
        SceneManager.LoadScene("VariKauppa");
    }
}
