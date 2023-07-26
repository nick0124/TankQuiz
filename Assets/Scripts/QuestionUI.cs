using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionsUI : MonoBehaviour
{
    public Image tankImage;
    public Button[] answerButtons;
    public TMP_Text answersInfo;

    public List<Question> questions;
    private int currentQuestion;

    void Start()
    {
        InitButtons();
        UpdateUI();
    }

    public void SetQuestions(List<Question> questions){
        this.questions = questions;
    }

    private void InitButtons()
    {
        for (int i = 0; i < this.answerButtons.Length; i++)
        {
            int answerNumber = i;
            this.answerButtons[i].onClick.AddListener(() => OnAnswerBtnClick(answerNumber));
        }
    }

    private void OnAnswerBtnClick(int answerNumber)
    {
        Question question = this.questions[this.currentQuestion];
        this.questions[this.currentQuestion].answer = question.answers[answerNumber];

        if (GameIsFinished())
        {
            FinishGame();
        }
        else
        {
            GoToNextQuestion();
        }
    }

    private bool GameIsFinished()
    {
        if (this.currentQuestion == this.questions.Count - 1)
        {
            return true;
        }else{
            return false;
        }
    }

    private void FinishGame(){
        //this.finishScreen.CheckAnswers(this.questions);
    }

    private void GoToNextQuestion()
    {
        this.currentQuestion++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        Question question = this.questions[this.currentQuestion];
        this.tankImage.sprite = question.correctAnswer.tankImage;

        for (int i = 0; i < this.answerButtons.Length; i++)
        {
            this.answerButtons[i].GetComponentInChildren<TMP_Text>().text = question.answers[i].tankName;
        }

        this.answersInfo.text = (this.currentQuestion + 1) + "/" + this.questions.Count;
    }
}
