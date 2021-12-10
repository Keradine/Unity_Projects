using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate 
{
    public string str;

    Letter letter; 
    //= new Letter();

    public void Put (Letter l)
    {
        letter = l;
        str = l.c.ToString();
    }

    public bool visible
    {
        set
        {
            letter.visible = true;
        }
    }

    public Color color
    {
        set
        {
            letter.color = value;
        }
    }
}
