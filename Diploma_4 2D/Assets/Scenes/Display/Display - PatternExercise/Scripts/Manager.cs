using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Manager : MonoBehaviour
{
    //Поля
    public GameObject blockPrefab; //для хранения плитки

    //Поле для закрепления префаба + X, Y, Z
    private Transform letterAnchor;
    private float posX;
    private float posY;
    private float posZ;

    private RusEngPattern_PatternExercise currentPattern; //Речевой образец, показываемый на экране
    //Списки
    public static List<RusEngPattern_PatternExercise> patterns = new List<RusEngPattern_PatternExercise>();
    public static List<RusEngPattern_PatternExercise> notTypedPatterns = new List<RusEngPattern_PatternExercise>();

    //Поля для доступа отдельно к рус. речевым образцам
    [SerializeField] private Text rusText;

    [SerializeField] private float letterSize;//размер букв
    [SerializeField] private Rect wordArea = new Rect(); //X, Y, ширина, высота

    //список плиток
    public List<Wyrd> wyrds = new List<Wyrd>();
    public List<Plate> plates = new List<Plate>();

    //Эксперимент
    public int plateIndex; //всего букв в речевом образце
    public int letterIndex; //букв в слове
    public int wordIndex; //слова в речвом образце

    //метод ShowPatterns()
    public GameObject go; //переменная для доступа к префабу
    char c; //символ в плитке
    Letter letter; //переменная (буква) на основе касса TestLetter, доступ к классу TestLetter

    string[] wordSplitArray; //массив для обращения к словам и буквам английского речевого образца

    //WrongLetter
    public GameObject wrongLetterPrefab; //создаем Prefab в unity
    GameObject wrongL; //внутренний эелемнт, которому назначим Prefab
    string wLetter; //сама фраза
    [SerializeField] private Text wrongLetterText; //получить доступ к текстовому элементу Prefab
    public Transform wrongLetterAnchor; //закрепить создаваемый Prefab в отдельном элементе unity
    private Vector3 scaleChange;

    //Список нужный, чтобы можно было удалять буквы из letterAnchor и заменять их новым английским речевым образцом
    public List<GameObject> cloneListForPrefabLetter = new List<GameObject>();

    //кнопка "Продолжить"
    public Button startAndContinueButton;
    public GameObject startAndContinueButtonContainer;

    //
    //public List<Plate> plates = new List<Plate>();
    //

    //первый метод, при запуске сцены (перед Start)
    void Start()
    {
        letterAnchor = new GameObject("LetterAnchor").transform; //закрепляет префаб за LetterAnchor

        ShowPatterns();
        //Эксперимент
        //letterIndex = 0;
        //wordIndex = 0;
        //plateIndex = 0;
        //

        //убрал парсинг массива, перенес в ShowPatterns() т.к. при переходе к след массиву не переходит к новому, а работает со старым
        //wordSplitArray = currentPattern.EngPatternName.Split(char.Parse(" ")); //заносим в массив английский речевой образец
        //Debug.Log(wordSplitArray[1]);

        //WrongLeter
        setWrongLetter();

        //подсвечивает красным первый символ
        //highlightFirstLetter();

        //
        //Удаляет с экрана кнопку "Продолжить"
        startAndContinueButtonContainer.SetActive(false);
        //
    }
    private void Update()
    {
        //fixLetterAnchorInTheCenter();
    }

    //кнопка "начать (и продолжить) выполнять задание"
    public void startPattern()
    {
        startPatternClick();
    }
    void startPatternClick()
    {
        ShowPatterns();
        Debug.Log(wordSplitArray[1]);
    }

    public void fixLetterAnchorInTheCenter() //Закрепляет префабы на конкретной позиции на экране
    {
        //posX = letterAnchor.GetComponent<Transform>().transform.localPosition.x;
        posX = (float)-2.80;
        //posY = letterAnchor.GetComponent<Transform>().transform.localPosition.y;
        posY = 0;
        //posZ = letterAnchor.GetComponent<Transform>().transform.localPosition.z;
        posZ = 0;
        letterAnchor.GetComponent<Transform>().position = new Vector3(posX, posY, posZ);
    }
    public void highlightFirstLetter() //подсвечивает красным первый символ
    {
        Debug.Log(plateIndex);
        wyrds[plateIndex].color = Color.red;
        //plates[plateIndex].color = Color.red;
    }
    public void setWrongLetter()
    {
        wLetter = "Неправильная буква";
        wrongLetterText.text = wLetter;
        wrongL = Instantiate<GameObject>(wrongLetterPrefab);
        wrongL.transform.SetParent(wrongLetterAnchor);
        wrongL.SetActive(false); //по-умолчанию Prefab не создается
        wrongL.transform.position = wrongLetterAnchor.transform.position; //размер Prefab равен размеру "контейнера" 
        scaleChange = new Vector3(1.2f, 1.2f, 1.2f); //изменяем размер под текующий экран
        wrongL.transform.localScale = scaleChange;
        var wLetterColor = wrongL.GetComponent<Text>(); //изменяем цвет Prefab
        wLetterColor.color = Color.red;
    }
    public void ShowPatterns()
    {
        //Локальные поля
        Vector3 pos; //для координат плитки
        Wyrd wyrd; //Чтобы иметь доступ к конкретной букве и менять ее видимость (НО не видимость всего слова)
        Plate plate;
        letterIndex = 0;
        wordIndex = 0;
        plateIndex = 0;
        //
        //Plate plate;
        //

        patterns.Clear(); //Очищаем список patterns

        letterAnchor.GetComponent<Transform>().position = new Vector3(0, 0, 0); //обнуляет позицию letterAnchor

        //Запрос к базе данных
        string queryString = "SELECT patternID, rusText, engText, isTyped FROM Pattern";
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {

            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        patterns.Add(new RusEngPattern_PatternExercise(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3)));
                    }
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }

            notTypedPatterns.Clear(); //Очищаем список notTypedPatterns

            //Цикл foreach. Как только речевой образец isTyped, то он удаляется из списка notTypedPatterns
            foreach (RusEngPattern_PatternExercise p in patterns)
            {
                if (!p.isTyped)
                    notTypedPatterns.Add(p);
            }

            //Случайный выбор речевого образца из списка 
            int randomIndex = Random.Range(0, notTypedPatterns.Count);
            currentPattern = notTypedPatterns[randomIndex];

            //Доступ отдельно к рус. речевым образцам
            rusText.text = currentPattern.RusPatternName;

            //Перенес парсинг массива сюда, чтобы при переходе на другой массив шла работа именно с ним, а не с предыдущим массивом
            wordSplitArray = currentPattern.EngPatternName.Split(char.Parse(" ")); //заносим в массив английский речевой образец
            Debug.Log(wordSplitArray[1]);
            //

            //Устанавливаем зависимость от длины слова
            int numRows = Mathf.RoundToInt(wordArea.width / letterSize);

            //Debug.Log(letterAnchor.childCount);

            //добавить символ в плитку, работаем с EngPatternName
            for (int l = 0; l < currentPattern.EngPatternName.Length; l++)
            {
                c = currentPattern.EngPatternName[l]; //получаем символ 
                cloneListForPrefabLetter.Add(go = Instantiate<GameObject>(blockPrefab)); //создаем префаб и сразу добавляем его в список, чтобы затем можно было удалить
                go.transform.SetParent(letterAnchor); //закрепляет префаб за LetterAnchor, попадает в середину 
                //if (l == 0) Debug.Log(go.transform.localPosition.x);
                letter = go.GetComponent<Letter>();
                //Debug.Log(letter.tRend.transform.localPosition.x);
                letter.c = c;
                //установить координаты плиток
                pos = new Vector3(0, 0, 0); //создаем position с Vector3
                pos.x = (l % numRows) * letterSize; //Задаем ограничения - сколько возможных плиток по оси X
                pos.y -= l / numRows * (float)0.4; //Переносим не поместившиеся плитки ниже, (float)0.4 - это расстояние между плитками (чем оно больше, тем больше расстояние)
                letter.pos = pos; //выстроить плитки в ряд
                //установить размер плиток
                go.transform.localScale = Vector3.one * letterSize;
                //Убирает с экрана пробелы
                if (c == ' ') //если символ равен пробелу
                {
                    go.SetActive(false); //то диактивировать prefab
                }

                //Делает буквы невидимыми
                letter.visible = false;

                //Добавляем в список символы
                wyrd = new Wyrd();
                wyrd.Add(letter);
                wyrds.Add(wyrd);

                //
                plate = new Plate();
                plate.Put(letter);
                plates.Add(plate);
                //
            }

        }

        //Удалить кнопку "Продолжить" с экрана
        startAndContinueButtonContainer.SetActive(false);

        fixLetterAnchorInTheCenter();
        highlightFirstLetter();
    }
    public void typeWordByFirstLetter(char c)
    {
        //string word = wordSplitArray[wordIndex];
        //if (word[letterIndex] == c)
        //{
        //    wyrds[wyrdIndex].color = Color.white;
        //    if (wrongL.active = true) wrongL.SetActive(false); //WrongLetter - при нажатии верной буквы, wrongLetterPrefab отключается
        //    while (letterIndex < word.Length)
        //    {
        //        wyrds[wyrdIndex++].visible = true;
        //        letterIndex++;
        //    }
        //    wordIndex++;
        //    wyrdIndex++;
        //    letterIndex = 0;
        //    wyrds[wyrdIndex].color = Color.red;
        //}
        //else
        //{
        //    Debug.Log("Неверная буква" + word[letterIndex] + " " + word + " " + c);
        //    wrongL.SetActive(true); //WrongLetter
        //}

        string word = wordSplitArray[wordIndex];
        //try
        //{
        //    if (word[letterIndex] == c)
        //    {
        //        wyrds[plateIndex].color = Color.white;
        //        //
        //        //plates[plateIndex].color = Color.white;
        //        //
        //        if (wrongL.active = true) wrongL.SetActive(false); //WrongLetter - при нажатии верной буквы, wrongLetterPrefab отключается
        //        while (letterIndex < word.Length)
        //        {
        //            wyrds[plateIndex++].visible = true;
        //            //
        //            //plates[plateIndex++].visible = true;
        //            //
        //            letterIndex++;
        //        }
        //        wordIndex++;
        //        plateIndex++;
        //        letterIndex = 0;
        //        wyrds[plateIndex].color = Color.red;
        //        //
        //        //plates[plateIndex].color = Color.red;
        //        //
        //    }
        //    else
        //    {
        //        Debug.Log("Неверная буква" + word[letterIndex] + " " + word + " " + c);
        //        wrongL.SetActive(true); //WrongLetter
        //    }
        //}
        //catch (ArgumentOutOfRangeException e) { isTyped(); }

        try
        {
            if (word[letterIndex] == c)
            {
                Debug.Log(plates.Count+" "+plateIndex);
                plates[plateIndex].color = Color.white;
                //
                //plates[plateIndex].color = Color.white;
                //
                if (wrongL.active = true) wrongL.SetActive(false); //WrongLetter - при нажатии верной буквы, wrongLetterPrefab отключается
                while (letterIndex < word.Length)
                {
                    plates[plateIndex++].visible = true;
                    //
                    //plates[plateIndex++].visible = true;
                    //
                    letterIndex++;
                }
                wordIndex++;
                plateIndex++;
                letterIndex = 0;
                Debug.Log(plateIndex);
                plates[plateIndex].color = Color.red;
                //
                //plates[plateIndex].color = Color.red;
                //
            }
            else
            {
                Debug.Log("Неверная буква" + word[letterIndex] + " " + word + " " + c);
                wrongL.SetActive(true); //WrongLetter
            }
        }
        catch (ArgumentOutOfRangeException e) { isTyped(); }
    }

    //public bool wordtyped()
    //{
    //    //если index было увеличен достаточно раз, что
    //    //он равен или больше длины слова
    //    //то все 
    //    bool wordtyped = (letterindex >= currentpattern.engpatternname.length);
    //    //if (wordtyped)
    //    //{
    //    //    //удалить слово
    //    //    destroy(gameobject);
    //    //}
    //    return wordtyped;
    //}
    //

    //метод отмечающий, что речевой образец напечатан
    public void isTyped()
    {
        currentPattern.isTyped = true; //Отмечает речевой образец isTyped

        // Удаляем буквы из letterAnchor
        for (int i = 0; i < cloneListForPrefabLetter.Count; i++)
        {
            Destroy(cloneListForPrefabLetter[i].gameObject);
        }
        cloneListForPrefabLetter.Clear();
        wyrds.Clear();
        plates.Clear();

        //
        startAndContinueButtonContainer.SetActive(true); //появляется кнопка "Продолжить"

        letterIndex = 0;
        wordIndex = 0;
        plateIndex = 0;
        //

        //Вносит в базу данные об отмеченном речевом образце isTyped
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            string queryString_2 = "UPDATE Pattern SET isTyped = 1 WHERE patternID = " + currentPattern.patternID;
            SqlCommand command_2 = new SqlCommand(queryString_2, conn);
            try
            {
                conn.Open();
                command_2.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }

        //Если все речевые образцы напечатаны, то появляются две кнопки:"Попробовать снова" и "Возврат в меню Present Simple Tense"
        if (notTypedPatterns.Count == 0 || notTypedPatterns.Count == 1)
        {
            //дописать метод позже
        }
    }
}
