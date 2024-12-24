using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Question", menuName = "Scriptable Objects/Question")]
public class Question : ScriptableObject
{
    public int id;
    public string question;
    [Header("ID‚Í1‚©‚çn‚Ü‚é‚½‚ß0”Ô–Ú‚Ì”š‚ÉˆÓ–¡‚Í‚È‚¢")]
    public List<int> bonusOfAnswers;
}
