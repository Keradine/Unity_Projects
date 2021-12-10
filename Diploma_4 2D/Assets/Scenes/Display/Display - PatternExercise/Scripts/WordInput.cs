using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour {
    public Manager gameManager;

    private void Update()
    {
        //Input.inputString - все что печатаем на клавиатуре фиксируется благодаря inputString
        foreach (char letter in Input.inputString)
        {
            //слово которое печатаем - это слово, на которое смотрим
            gameManager.typeWordByFirstLetter(letter);
            Debug.Log(letter);
        }
    }
}
