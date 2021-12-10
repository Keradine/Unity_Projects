using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FutureSimpleButtonScript : MonoBehaviour
{
    public GameObject futureSimpleButtonName;

    public void SetFutureSimpleButton(string futureSimpleButtonName)
    {
        this.futureSimpleButtonName.GetComponent<Text>().text = futureSimpleButtonName;
    }
}
