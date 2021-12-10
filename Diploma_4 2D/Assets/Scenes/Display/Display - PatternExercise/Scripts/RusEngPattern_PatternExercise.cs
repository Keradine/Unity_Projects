[System.Serializable] //все переменные видны в инспекторе

public class RusEngPattern_PatternExercise {

    //Поля и свойства
    public bool isTyped { get; set; }
    public int patternID { get; set; }
    public string RusPatternName { get; set; }
    public string EngPatternName { get; set; }

    //Параметры
    public RusEngPattern_PatternExercise(int patternID)
    {
        this.patternID = patternID;
    }
    public RusEngPattern_PatternExercise(int patternID, string rusPatternName, string engPatternName, bool isTyped) : this(patternID)
    {
        RusPatternName = rusPatternName;
        EngPatternName = engPatternName;
        this.isTyped = isTyped;
    }
    public RusEngPattern_PatternExercise(string rusPatternName, string engPatternName)
    {
        this.RusPatternName = rusPatternName;
        this.EngPatternName = engPatternName;
    }
}
