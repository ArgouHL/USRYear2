using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionUIControl : MonoBehaviour
{
    public static QuestionUIControl instance;


    [SerializeField]
    DialogBubbleControl dialogBubble1, dialogBubble2, dialogBubble3;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void ShowQuestion(Question questions)
    {
        ShowQuestion(questions.questions);
    }


    public void ShowQuestion(List<string> questions)
    {
        dialogBubble1.Show(questions[0]);
        if (questions.Count > 1)
            dialogBubble2.Show(questions[1]);
        if (questions.Count >2)
            dialogBubble3.Show(questions[2]);
    }
    public void HideQuestion()
    {
        dialogBubble1.Hide();
        dialogBubble2.Hide();
        dialogBubble3.Hide();
    }

}
