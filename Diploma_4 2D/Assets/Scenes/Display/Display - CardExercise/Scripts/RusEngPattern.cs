[System.Serializable]
public class RusEngPattern {

    //Поля и свойства
    public bool isMemorized { get; set; }
    public int patternID { get; set; }
    public string RusPatternName { get; set; }
    public string EngPatternName { get; set; }

    //Параметры
    public RusEngPattern(int patternID)
    {
        this.patternID = patternID;
    }
    public RusEngPattern(int patternID, string rusPatternName, string engPatternName, bool isMemorized) : this(patternID)
    {
        RusPatternName = rusPatternName;
        EngPatternName = engPatternName;
        this.isMemorized = isMemorized;
    }

    //Additional
    public RusEngPattern(string rusPatternName, string engPatternName)
    {
        this.RusPatternName = rusPatternName;
        this.EngPatternName = engPatternName;
    }
}
