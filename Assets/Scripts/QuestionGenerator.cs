using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionGenerator : MonoBehaviour
{
    private QuestionsData _questionsData;
    private List<TankInfo> _tanksForQuestions;

    public List<Question> GenerateQuestions(QuestionsData questionsData)
    {
        _questionsData = questionsData;
        _tanksForQuestions = new List<TankInfo>(_questionsData.tanks);

        List<Question> questions = new List<Question>();
        for (int i = 0; i < _questionsData.tanks.Count; i++)
        {
            Question question = GenerateQuestion();
            questions.Add(question);
        }
        return questions;
    }

    private Question GenerateQuestion()
    {
        TankInfo correctAnswer = GenerateCorrectnaswer();
        List<TankInfo> answers = GenerateAnswers(correctAnswer);
        return new Question(answers, correctAnswer);
    }

    private TankInfo GenerateCorrectnaswer()
    {
        int corectAnswerRandomizer = Random.Range(0, _tanksForQuestions.Count);
        TankInfo corectAnswer = _tanksForQuestions[corectAnswerRandomizer];
        _tanksForQuestions.RemoveAt(corectAnswerRandomizer);
        return corectAnswer;
    }

    private List<TankInfo> GenerateAnswers(TankInfo correctAnswer)
    {
        List<TankInfo> tanksForAnswers = new List<TankInfo>(_questionsData.tanks);
        tanksForAnswers.Remove(correctAnswer);

        List<TankInfo> answers = new List<TankInfo>();
        for (int i = 0; i < 4; i++)
        {
            int answerRandomizer = Random.Range(0, tanksForAnswers.Count);
            answers.Add(tanksForAnswers[answerRandomizer]);
            tanksForAnswers.RemoveAt(answerRandomizer);
        }

        int corrctAnswerRandomizer = Random.Range(0, answers.Count);
        answers[corrctAnswerRandomizer] = correctAnswer;

        return answers;
    }
}