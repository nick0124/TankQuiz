using System.Collections.Generic;

public class Question
{
    public List<TankInfo> answers { get; private set; }
    public TankInfo correctAnswer { get; private set; }
    public TankInfo answer { get; set; }
    public Question(List<TankInfo> answers, TankInfo correctAnswer)
    {
        this.answers = answers;
        this.correctAnswer = correctAnswer;
    }
}
