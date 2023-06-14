using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankInfo", menuName = "TankQuiz/TankInfo", order = 0)]
public class TankInfo : ScriptableObject
{
    [field: SerializeField] public Sprite tankImage { private set; get; }
    [field: SerializeField] public string tankName { private set; get; }
}
