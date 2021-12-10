using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
    //Списки
    public static List<RusEngPattern> patternsList = new List<RusEngPattern>();
    public static List<RusEngPattern> notMemorizedPatternsList = new List<RusEngPattern>();

    //Для контроля заполняемости списка в Log
    private int previousPatternsCount;
    private int currentPatternsCount;
    private int previousNotMemorizedPatternsCount;
    private int currentNotMemorizedPatternsCount;

    //Речевой образец, показываемый на экране
    private RusEngPattern currentPattern;

    //Поля для доступа отдельно к рус. и англ. речевым образцам
    [SerializeField] private Text rusText;
    [SerializeField] private Text engText;

    //Кнопки "Следующий р.о." и "Я запомнил"
    public Button I_Memorized_Button;
    public GameObject IMemorizedButtonContainer;
    public Button NextButton;
    public GameObject NextButtonContainer;

    //Кнопка "Попробовать снова"
    public GameObject tryAgainButtonParent;
    [SerializeField] private Button tryAgainButton;

    //Кнопка "Перейти к следующему заданию"
    public GameObject patternExButtonParent;
    [SerializeField] private Button patternExerciseButton;

    //Для доступа к счетчику снизу
    [SerializeField] private GameObject counterContainer;

    //Для доступа к счетчику сверху
    [SerializeField] private Image counterImage_1;
    [SerializeField] private Image counterImage_2;
    [SerializeField] private Image counterImage_3;
    [SerializeField] private Image counterImage_4;
    [SerializeField] private Image counterImage_5;
    [SerializeField] private Image counterImage_6;
    [SerializeField] private Image counterImage_7;
    [SerializeField] private Image counterImage_8;
    [SerializeField] private Image counterImage_9;
    [SerializeField] private Image counterImage_10;

    //"Вспомни речевой образец" aka "?"
    public GameObject rememberButtonContainer;
    //Потворная кнопка NextPattern
    public Button NextButton_2;
    public GameObject NextButtonContainer_2;


    private void Start()
    {
        //Удаление с экрана кнопок "Попробовать снова" и "Следующее задание"
        tryAgainButtonParent.SetActive(false);
        patternExButtonParent.SetActive(false);

        //Удаляет с экрана кнопку "Вспомни речевой образец"
        rememberButtonContainer.SetActive(false);
        NextButtonContainer_2.SetActive(false);
    }

    //"Next Pattern" Method
    public void NextPattern()
    {
        Next_Click();
    }
    void Next_Click()
    {
        patternsList.Clear(); //Очищаем список patterns

        //Запрос к базе данных
        string queryString = "SELECT patternID, rusText, engText, isMemorized FROM Pattern";
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
                        patternsList.Add(new RusEngPattern(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3)));
                    }
                }
                conn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }

            notMemorizedPatternsList.Clear(); //Очищаем список notMemorizedPatterns

            //Цикл foreach. Как только речеовой образец isMemorized, то он удаляется из списка notMemorizedPatterns
            foreach (RusEngPattern p in patternsList) {
                if (!p.isMemorized)
                    notMemorizedPatternsList.Add(p);
            }

            //Случайный выбор речевого образца из списка notMemorizedPatterns
            int randomPatternIndex = Random.Range(0, notMemorizedPatternsList.Count);
            currentPattern = notMemorizedPatternsList[randomPatternIndex];

            //Доступ отдельно к рус. и англ. речевым образцам
            rusText.text = currentPattern.RusPatternName;
            engText.text = currentPattern.EngPatternName;

            //"Вспомни речевой образец" aka "?"
            rememberButtonContainer.SetActive(true); //Возвращает на экран "Вспомни речевой образец" aka "?"
            engText.enabled = false; //убирает с экрана английский речевой образец

            NextButtonContainer.SetActive(false); //Убирает с экрана кнопку NextPattern
            NextButtonContainer_2.SetActive(true); //Возвращает на экран потворную кнопку NextPattern_2
        }

    }

    //Потворная кнопка NextPattern
    public void NextPattern_2()
    {
        Next_Click_2();
    }
    void Next_Click_2()
    {
        rememberButtonContainer.SetActive(false); //Убирает с экрана "Вспомни речевой образец" aka "?"
        engText.enabled = true; //Возвращает на экран английский речевой образец

        NextButtonContainer.SetActive(true); //Возвращает на экран кнопку NextPattern
        NextButtonContainer_2.SetActive(false); //Убирает с экрана повторную кнопку NextPattern_2
    }    

    //"I Memorized" Method
    public void I_Memorized()
    {
        I_Memorized_Click();
    }
    void I_Memorized_Click()
    {
        currentPattern.isMemorized = true; //Отмечает речевой образец isMemorized

        //Устанавливает условие: если нажимаем "Я запомнил", то прибавляется одно очко
        if (currentPattern.isMemorized == true)
        {
            Counter.patternCounter += 1;
        }

        //Счетчик сверху
        if(currentPattern.patternID == 1 & currentPattern.isMemorized == true) counterImage_1.GetComponent<Image>().color = Color.green;
        if (currentPattern.patternID == 2 & currentPattern.isMemorized == true) counterImage_2.GetComponent<Image>().color = Color.green;
        if (currentPattern.patternID == 3 & currentPattern.isMemorized == true) counterImage_3.GetComponent<Image>().color = Color.green;
        if (currentPattern.patternID == 4 & currentPattern.isMemorized == true) counterImage_4.GetComponent<Image>().color = Color.green;
        if (currentPattern.patternID == 5 & currentPattern.isMemorized == true) counterImage_5.GetComponent<Image>().color = Color.green;
        if (currentPattern.patternID == 6 & currentPattern.isMemorized == true) counterImage_6.GetComponent<Image>().color = Color.green;
        if (currentPattern.patternID == 7 & currentPattern.isMemorized == true) counterImage_7.GetComponent<Image>().color = Color.green;
        if (currentPattern.patternID == 8 & currentPattern.isMemorized == true) counterImage_8.GetComponent<Image>().color = Color.green;
        if (currentPattern.patternID == 9 & currentPattern.isMemorized == true) counterImage_9.GetComponent<Image>().color = Color.green;
        if (currentPattern.patternID == 10 & currentPattern.isMemorized == true) counterImage_10.GetComponent<Image>().color = Color.green;

        //Вносит в базу данные об отмеченном речевом образце isMemorized
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            string queryString_2 = "UPDATE Pattern SET isMemorized = 1 WHERE patternID = " + currentPattern.patternID;
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

        //Если все речевые образцы запомнены, то появляются две кнопки: "Переход к другому упражнению" и "Попробовать снова"
        if (notMemorizedPatternsList.Count == 0 || notMemorizedPatternsList.Count == 1)
        {
            //Появление на экране кнопок "Попробовать снова" и "Следующее задание"
            tryAgainButtonParent.SetActive(true);
            patternExButtonParent.SetActive(true);

            //Удаление с экрана речевого образца
            rusText.enabled = false;
            engText.enabled = false;

            //Удаление с экрана кнопок "Я запомнил", "Следующий речевой образец" и повторной кнопки NextPattern_2
            IMemorizedButtonContainer.SetActive(false);
            NextButtonContainer.SetActive(false);
            NextButtonContainer_2.SetActive(false);

            //Счетчик
            Counter.patternCounter = 0; //Обнуляем значение после запоминания всех речевых образцов
            counterContainer.SetActive(false); //Убираем счетчик с экрана

            //Убирает с экрана счетчик сверху
            counterImage_1.enabled = false;
            counterImage_2.enabled = false;
            counterImage_3.enabled = false;
            counterImage_4.enabled = false;
            counterImage_5.enabled = false;
            counterImage_6.enabled = false;
            counterImage_7.enabled = false;
            counterImage_8.enabled = false;
            counterImage_9.enabled = false;
            counterImage_10.enabled = false;

            //Убирает с экрана кнопку "Вспомни речевой образец"
            rememberButtonContainer.SetActive(false);
        }
    }

    //Метод для просмотра в инспекторе изменения значений списков
    void OnValidate()
    {
        //patterns.Count()
        currentPatternsCount = patternsList.Count();
        if (previousPatternsCount != currentPatternsCount)
            Debug.Log($"patterns count has changed: {previousPatternsCount} => {currentPatternsCount}");
        previousPatternsCount = currentPatternsCount;

        //notMemorizedPatterns.Count()
        currentNotMemorizedPatternsCount = notMemorizedPatternsList.Count();
        if (previousNotMemorizedPatternsCount != currentNotMemorizedPatternsCount)
            Debug.Log($"notMemorizedPatterns count has changed: {previousNotMemorizedPatternsCount} => {currentNotMemorizedPatternsCount}");
        previousNotMemorizedPatternsCount = currentNotMemorizedPatternsCount;
    }

    //Кнопка "Попробовать снова"
    public void TryAgain()
    {
        TryAgain_Click();
    }
    void TryAgain_Click()
    {
        //Обнуляет значения isMemorized
        using (SqlConnection conn = DBUtils.GetDBConnection())
        {
            string queryString = "UPDATE Pattern SET isMemorized = 0";
            SqlCommand command = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }

        //Появление на экране речевого образца
        rusText.enabled = true;
        engText.enabled = true;

        //Удаление с экрана кнопок "Попробовать снова" и "Следующее задание"
        tryAgainButtonParent.SetActive(false);
        patternExButtonParent.SetActive(false);

        //Появление на экране кнопок "Я запомнил" и "Следующий речевой образец"
        IMemorizedButtonContainer.SetActive(true);
        NextButtonContainer.SetActive(true);

        //Возвращаем счетчик на экран
        counterContainer.SetActive(true);

        //Возвращает на экран счетчик сверху
        counterImage_1.enabled = true;
        counterImage_2.enabled = true;
        counterImage_3.enabled = true;
        counterImage_4.enabled = true;
        counterImage_5.enabled = true;
        counterImage_6.enabled = true;
        counterImage_7.enabled = true;
        counterImage_8.enabled = true;
        counterImage_9.enabled = true;
        counterImage_10.enabled = true;

        //Обнуляет счетчик сверху
        counterImage_1.GetComponent<Image>().color = Color.white;
        counterImage_2.GetComponent<Image>().color = Color.white;
        counterImage_3.GetComponent<Image>().color = Color.white;
        counterImage_4.GetComponent<Image>().color = Color.white;
        counterImage_5.GetComponent<Image>().color = Color.white;
        counterImage_6.GetComponent<Image>().color = Color.white;
        counterImage_7.GetComponent<Image>().color = Color.white;
        counterImage_8.GetComponent<Image>().color = Color.white;
        counterImage_9.GetComponent<Image>().color = Color.white;
        counterImage_10.GetComponent<Image>().color = Color.white;
    }

    //Кнопка "Следующее задание"
    public void PatternExercise()
    {
        PatternExercise_Click("Display - PatternExercise");
    }
    void PatternExercise_Click(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
