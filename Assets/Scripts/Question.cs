using UnityEngine;

[System.Serializable]
public class Question
{
    [TextArea(3, 10)]
    public string questionText;
    
    [TextArea(3, 10)]
    public string answerA;
    
    [TextArea(3, 10)]
    public string answerB;
    
    [TextArea(3, 10)]
    public string answerC;
    
    [TextArea(3, 10)]
    public string answerD;
    
    [TextArea(3, 10)]
    public string correctAnswer;
}
