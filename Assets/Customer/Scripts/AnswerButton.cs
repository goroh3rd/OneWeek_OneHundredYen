using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    public Answer answer;
    [SerializeField] TextMeshProUGUI answerText;
    [SerializeField] Button button;
    [SerializeField] DialogManager dialogManager;

    private void Start()
    {
        answerText.text = answer.answer;
        dialogManager = FindAnyObjectByType<DialogManager>();
    }
    public void SetAnswer()
    {
        dialogManager.SetAnswer(answer);
    }
}
