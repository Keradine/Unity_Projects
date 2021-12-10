using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Control_Display_Grammar : MonoBehaviour
{
    //UI
    public GameObject BackwardsButton;
    public GameObject ConfigurationButton;

    //Categories
    public GameObject SimpleButton;
    public GameObject ProgressiveButton;
    public GameObject PerfectButton;

    //SubCategories
    public GameObject PresentSimpleButton;
    public GameObject PastSimpleButton;
    public GameObject FutureSimpleButton;
    public GameObject PresentProgressiveButton;
    public GameObject PastProgressiveButton;
    public GameObject FutureProgressiveButton;
    public GameObject PresentPerfectButton;
    public GameObject PastPerfectButton;
    public GameObject FuturePerfectButton;

    //UI Methods
    public void LoadScene_Display_Intro()
    {
        SceneManager.LoadScene(13);
    }

    public void LoadScene_Display_GameConfiguration()
    {
        SceneManager.LoadScene(14);
    }

    //Categories Methods
    public void LoadSceneSimpleTenses()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSceneProgressiveButton()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadScenePerfectButton()
    {
        SceneManager.LoadScene(3);
    }

    //SubCategories Methods
    public void LoadScene_Display_Present_Simple_Tense()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadScene_Display_Past_Simple_Tense()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadScene_Display_Future_Simple_Tense()
    {
        SceneManager.LoadScene(6);
    }

    public void LoadScene_Display_Present_Progressive_Tense()
    {
        SceneManager.LoadScene(7);
    }

    public void LoadScene_Display_Past_Progressive_Tense()
    {
        SceneManager.LoadScene(8);
    }

    public void LoadScene_Display_Future_Progressive_Tense()
    {
        SceneManager.LoadScene(9);
    }

    public void LoadScene_Display_Present_Perfect_Tense()
    {
        SceneManager.LoadScene(10);
    }

    public void LoadScene_Display_Past_Perfect_Tense()
    {
        SceneManager.LoadScene(11);
    }

    public void LoadScene_Display_Future_Perfect_Tense()
    {
        SceneManager.LoadScene(12);
    }
}
