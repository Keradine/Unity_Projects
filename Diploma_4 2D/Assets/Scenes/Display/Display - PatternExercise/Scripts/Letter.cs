using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour {
    //Поля
    public TextMesh tMesh; //TextMesh отображает символ
    private char _c; //символ,отображаемый на плитке

    //Поля, которые понадобятся позже
    public Renderer tRend; //Компонент Rendered объекта 3D текст, определяет видимость символа
    private Renderer rend;

    //Поля для линейной интерполяции
    public List<Vector3> pts = null;
    public float timeStart = -1;

    void Awake() {
        tMesh = GetComponentInChildren<TextMesh>();
        tRend = tMesh.GetComponent<Renderer>();
        rend = GetComponent<Renderer>();
    }

    //Свойство для чтения/записи буквы в поле _c, отображаемой объеком 3D Text
    public char c {
        get { return (_c); }
        set
        {
            _c = value;
            tMesh.text = _c.ToString();
        }
    }

    // Свойство для чтения/записи буквы в поле _с в виде строки
    public string str {
        get { return (_c.ToString()); }
        set { c = value[0]; }
    }

    //Свойство для чтения/записи координат плитки, позволит выстроить плитки в ряд
    public Vector3 pos {
        set
        {
            transform.position = value;
        }
    }

    // Разрешает или запрещает отображение 3D Text, что делает букву видимой или невидимой соответственно.
    public bool visible
    {
        get { return (tRend.enabled); }
        set { tRend.enabled = value; }
    }
    // Свойство для чтения/записи цвета плитки
    public Color color
    {
        get { return (rend.material.color); }
        set { rend.material.color = value; }
    }
    // Немедленно перемещает в новую позицию
    public Vector3 posImmediate
    {
        set
        {
            transform.position = value;
        }
    }
}
