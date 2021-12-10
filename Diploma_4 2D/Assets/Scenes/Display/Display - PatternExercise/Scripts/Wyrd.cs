using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//класс, который нужен для управления видимостью объектов
public class Wyrd {
    //поля
    public string str; //строковое представление слова
    public List<Letter> letters = new List<Letter>();

    //добавляет плитку в спиcок Letters
    public void Add(Letter l) {
        letters.Add(l);
        str += l.c.ToString();
    }

    //Св-о, управляющее видимостью объекта 3dText каждой плитки
    public bool visible {
        get
        {
            if (letters.Count == 0) return (false);
            return (letters[0].visible);
        }
        set
        {
            foreach (Letter l in letters)
            {
                l.visible = value;
            }
        }
    }

    //для цвета
    public Color color {
        get
        {
            if (letters.Count == 0) return (Color.black);
            return (letters[0].color);
        }
        set
        {
            foreach (Letter l in letters)
            {
                l.color = value;
            }
        }
    }
}
