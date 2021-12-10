using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {
    public static int patternCounter = 0; //переменная, хранящая счетчик
    Text counterText; //получаем доступ к компоненту Text

    void Start()
    {
        counterText = GetComponent<Text>(); //получаем доступ к компоненту Text
    }

    void Update() {
        counterText.text = patternCounter + "/10"; //устанавливаем счетчик
    }
}
