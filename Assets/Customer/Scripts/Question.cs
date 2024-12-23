using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Question", menuName = "Scriptable Objects/Question")]
public class Question : ScriptableObject
{
    public int id;
    public string question;
    [Header("IDは1から始まるため0番目の数字に意味はない")]
    public List<int> bonusOfAnswers;
}
