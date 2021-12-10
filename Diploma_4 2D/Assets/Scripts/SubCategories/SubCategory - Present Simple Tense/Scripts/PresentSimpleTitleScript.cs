using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentSimpleTitleScript : MonoBehaviour
{
    public GameObject presentSimpleTitleName;

    public void SetPresentSimpleTitle(string presentSimpleTitleName)
    {
        this.presentSimpleTitleName.GetComponent<Text>().text = presentSimpleTitleName;
    }
}
