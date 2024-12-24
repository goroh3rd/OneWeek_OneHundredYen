using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System;

public class DialogManager : MonoBehaviour
{
    [SerializeField] int numberOfQuestions = 20;
    [SerializeField] int currentQuestionIndex = 0;
    [SerializeField] List<Question> questions;
    [SerializeField] List<Answer> answers;
    private Question currentQuestion;
    private Answer currentAnswer;
    private void Start()
    {
        InitQA();
        ShowQuestion();
    }
    void InitQA()
    {
        currentQuestion = null;
        currentAnswer = null;
    }
    void ShowQuestion()
    {
        currentQuestion = questions[UnityEngine.Random.Range(0, questions.Count)];
        Debug.Log(currentQuestion.question);
        StartCoroutine(WaitForAnswer(() =>
        {
            Debug.Log(currentAnswer.answer);
            Debug.Log(GetBonusQA(currentQuestion, currentAnswer)); // GetBonusQA�𗘗p���ē_���̉��Z���s���\��
            if (++currentQuestionIndex < numberOfQuestions)
            {
                InitQA();
                ShowQuestion();
            }
            else
            {
                Debug.Log("Finish");
                // �����Ō��ʂ�\�����鏈��������
            }
        }));
    }
    IEnumerator WaitForAnswer(Action action)
    {
        yield return new WaitUntil(() => currentAnswer != null);
        action();
    }
    int GetBonusQA(Question question, Answer answer)
    {
        return question.bonusOfAnswers[answer.id];
    }
    public void SetAnswer(Answer answer)
    {
        currentAnswer = answer;
    }
}
