using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Controls_Category_Simple_Tense : MonoBehaviour
{
    //UI
    public GameObject BackwardsButton;
    public GameObject ConfigurationButton;

    //SubCategories
    public GameObject PresentSimpleButton;
    public GameObject PastSimpleButton;
    public GameObject FutureSimpleButton;

    //UI Methods
    public void LoadScene_Display_Grammar()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadScene_Display_GameConfiguration()
    {
        SceneManager.LoadScene(14);
    }

    //SubCategories Methods
    public void LoadScene_Display_Present_Simple_Tense(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene_Display_Past_Simple_Tense()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadScene_Display_Future_Simple_Tense()
    {
        SceneManager.LoadScene(6);
    }
}
