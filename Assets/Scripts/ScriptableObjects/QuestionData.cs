using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "QuestionData", menuName = "TankQuiz/QuestionData", order = 0)]
public class QuestionData : ScriptableObject
{
    [field: SerializeField] public List<TankInfo> tanks { private set; get; }
}
