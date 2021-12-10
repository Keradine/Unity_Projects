using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour {
    //UI
    public GameObject BackwardsButton;
    public GameObject ConfigurationButton;

    //UI Methods
    public void LoadScene_SubCategoryPresentSimpleTense(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene_Display_GameConfiguration(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
