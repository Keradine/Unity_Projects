using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentSimpleButtonScript : MonoBehaviour
{
    public GameObject presentSimpleButtonName;

    public void SetPresentSimpleButton(string presentSimpleButtonName)
    {
        this.presentSimpleButtonName.GetComponent<Text>().text = presentSimpleButtonName;
    }
}
