using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionGenerator : MonoBehaviour
{
    [SerializeField] private QuestionData data;

    public List<TankInfo> tanksForQuestions;

    public Image tankImage;
    public List<TankInfo> answers;
    public TankInfo correctAnswer;
    public List<TankInfo> tanksForAnswers;

    public Button[] answerButtons;

    public int correctAnswers;

    // Start is called before the first frame update
    void Start()
    {
        tanksForQuestions = new List<TankInfo>(data.tanks);

        this.GenerateQuestion();

        //this.SetButtons();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateQuestion();
        }
    }

    private void GenerateQuestion()
    {
        if (this.tanksForQuestions.Count > 0)
        {

            //берем рандомныйтанк из списка танков для ответа
            int rdm = Random.Range(0, this.tanksForQuestions.Count);
            this.correctAnswer = this.tanksForQuestions[rdm];
            //удаляем танк из списка ответов, потому что уже использовали
            this.tanksForQuestions.RemoveAt(rdm);

            //создаем лист с танками для ответов, со всеми танками
            this.tanksForAnswers = new List<TankInfo>(data.tanks);
            //удалаяем из ответов который является правильным ответом
            tanksForAnswers.Remove(this.correctAnswer);



            this.answers.Clear();

            int answerRandomizer = Random.Range(0, this.tanksForAnswers.Count);
            this.answers.Add(this.tanksForAnswers[answerRandomizer]);
            this.tanksForAnswers.RemoveAt(answerRandomizer);

            answerRandomizer = Random.Range(0, this.tanksForAnswers.Count);
            this.answers.Add(this.tanksForAnswers[answerRandomizer]);
            this.tanksForAnswers.RemoveAt(answerRandomizer);

            answerRandomizer = Random.Range(0, this.tanksForAnswers.Count);
            this.answers.Add(this.tanksForAnswers[answerRandomizer]);
            this.tanksForAnswers.RemoveAt(answerRandomizer);

            answerRandomizer = Random.Range(0, this.tanksForAnswers.Count);
            this.answers.Add(this.tanksForAnswers[answerRandomizer]);
            this.tanksForAnswers.RemoveAt(answerRandomizer);

            int corrctAnswerRandomizer = Random.Range(0, this.answers.Count);
            this.answers[corrctAnswerRandomizer] = this.correctAnswer;

            this.tankImage.sprite = this.correctAnswer.tankImage;

            //this.UpdateButtonsText();
            this.SetButtons();
        }
        else
        {
            //finish
        }
    }

    private void SetButtons(){
        for (int i = 0; i < 4; i++)
        {
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = this.answers[i].tankName;
            TankInfo aaa = this.answers[i];
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() =>PressButton(aaa));
        }
    }

    private void UpdateButtonsText(){
        // for (int i = 0; i < 4; i++)
        // {
        //     answerButtons[i].GetComponentInChildren<TMP_Text>().text = this.answers[i].tankName;
        // }
    }

    private void PressButton(TankInfo tankInfo){
        Debug.Log(tankInfo);
        if(tankInfo == this.correctAnswer){
            Debug.Log("correct");
            correctAnswers++;
        }else{
            Debug.Log("wrong");
        }
        GenerateQuestion();
    }

    private void NewGame(){

    }
}
