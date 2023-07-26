using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private QuestionGenerator _questionGenerator;
    [SerializeField] private QuestionsData _questionsData;
    [SerializeField] private UIController _uiController;

    [SerializeField] private Button[] _answerButtons = new Button[4];
    [SerializeField] private Image _tankImage;
    [SerializeField] private TMP_Text _answersInfo;

    private List<Question> _questions;
    private int _currentQuestionNumber;

    private void Start() {
        if(_answerButtons.Length != 4){
            Debug.LogError("Answer Buttons length must be equals 4");
        }

        InitAnswerButtons();
    }

    public void StartNewGame()
    {
        _questions = _questionGenerator.GenerateQuestions(_questionsData);
        _currentQuestionNumber = 0;
        _uiController.OpenGame();
        UpdateUI();
    }

    private void InitAnswerButtons()
    {
        for (int i = 0; i < _answerButtons.Length; i++)
        {
            int answerNumber = i;
            _answerButtons[i].onClick.AddListener(() => CheckAnswer(answerNumber));
        }
    }

    public void CheckAnswer(int answerNumber)
    {
        _questions[_currentQuestionNumber].answer = _questions[_currentQuestionNumber].answers[answerNumber];

        if (GameIsFinished())
        {
            FinishGame();
        }
        else
        {
            GoToNextQuestion();
        }
    }

    private void FinishGame()
    {
        CheckGameResults();
        _uiController.OpenFinish();
    }

    private void GoToNextQuestion()
    {
        _currentQuestionNumber++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _tankImage.sprite = _questions[_currentQuestionNumber].correctAnswer.tankImage;

        for (int i = 0; i < _answerButtons.Length; i++)
        {
            _answerButtons[i].GetComponentInChildren<TMP_Text>().text = _questions[_currentQuestionNumber].answers[i].tankName;
        }

        _answersInfo.text = (_currentQuestionNumber + 1) + "/" + _questions.Count;
    }

    private bool GameIsFinished()
    {
        if (_currentQuestionNumber == _questions.Count - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheckGameResults()
    {
        int correctAnswers = CheckAnswers();
        int rating = CheckRating(correctAnswers);

        Debug.Log("finish game");
        Debug.Log("stars:" + rating);
        Debug.Log("Correct answers:" + correctAnswers + " Answers:" + _questions.Count);
    }

    private int CheckAnswers(){
        int correctAnswersCount = 0;
        for (int i = 0; i < _questions.Count; i++)
        {
            if (_questions[i].answer == _questions[i].correctAnswer)
            {
                correctAnswersCount++;
            }
        }
        return correctAnswersCount;
    }

    private int CheckRating(int correctAnswersCount){
        int ratingCount = 3;
        float oneRatingMeasure = _questions.Count / ratingCount;
        float correctAnswersMeasure = correctAnswersCount * oneRatingMeasure;
        int stars = 0;
        for (int i = 0; i < ratingCount; i++)
        {
            float currentQuestionMeasure = i+1 * oneRatingMeasure;
            
            if (currentQuestionMeasure <= correctAnswersMeasure)
            {
                stars = i+1;
                Debug.Log(correctAnswersMeasure + "<=" + currentQuestionMeasure);
            }
            else
            {
                break;
            }
        }
        return stars;
    }
}
