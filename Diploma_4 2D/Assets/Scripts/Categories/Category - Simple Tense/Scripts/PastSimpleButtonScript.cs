using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PastSimpleButtonScript : MonoBehaviour
{
    public GameObject pastSimpleButtonName;

    public void SetPastSimpleButton(string pastSimpleButtonName)
    {
        this.pastSimpleButtonName.GetComponent<Text>().text = pastSimpleButtonName;
    }
}
