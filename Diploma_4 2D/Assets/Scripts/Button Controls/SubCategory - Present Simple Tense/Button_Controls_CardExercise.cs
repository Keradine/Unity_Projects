using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Controls_CardExercise : MonoBehaviour
{
    //UI
    public GameObject BackwardsButton;
    public GameObject ConfigurationButton;

    //UI Methods
    public void LoadScene_Display_PresentSimple()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadScene_Display_GameConfiguration()
    {
        SceneManager.LoadScene(14);
    }
}
