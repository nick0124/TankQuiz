using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "QuestionData", menuName = "TankQuiz/QuestionData", order = 0)]
public class QuestionsData : ScriptableObject
{
    [field: SerializeField] public List<TankInfo> tanks { private set; get; }
}
