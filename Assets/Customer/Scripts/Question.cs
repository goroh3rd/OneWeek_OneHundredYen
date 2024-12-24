using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Question", menuName = "Scriptable Objects/Question")]
public class Question : ScriptableObject
{
    public int id;
    public string question;
    [Header("ID��1����n�܂邽��0�Ԗڂ̐����ɈӖ��͂Ȃ�")]
    public List<int> bonusOfAnswers;
}
