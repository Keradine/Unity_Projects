using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Controls_SubCategory_Present_Simple_Tense : MonoBehaviour
{
    //UI
    public GameObject BackwardsButton;
    public GameObject ConfigurationButton;

    //Buttons
    public GameObject PresentSimpleTheoryButton;
    public GameObject CardExerciseButton;
    public GameObject PatternExerciseButton;
    
    //UI Methods
    public void LoadScene_Display_Grammar()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadScene_Display_GameConfiguration()
    {
        SceneManager.LoadScene(14);
    }

    //Buttons Methods
    public void LoadScene_Display_PresentSimpleTheory(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene_Display_CardExercise(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene_Display_PatternExercise(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
