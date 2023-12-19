using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
   public List<QuestionsAndAnswers> QnA;
   public GameObject[] options;
   public int currentQuestion;

   public GameObject quizPanel;
   public GameObject GOPanel;

   public Text QuestionTxt;
   public Text scoreText;

   int TotalQuestions = 0;
   public int score;

   private void Start()
   {
    TotalQuestions = QnA.Count;
    GOPanel.SetActive(false);
    GenerateQuestions();
   }

   public void Next()
   {
    int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if there is a next scene
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // If the current scene is the last one, go back to the first scene
            SceneManager.LoadScene(0);
        }

   }

   public void GameOver()
   {
    quizPanel.SetActive(false);
    GOPanel.SetActive(true);
    scoreText.text = score + "/" + TotalQuestions;
 
   }

   public void Correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
        
    }

   public void Wrong()
    {
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());
      
    }

      IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(.5f);
        GenerateQuestions();
    }

   void SetAnswers()
   {
    for (int i = 0; i < options.Length; i++)
    {
        options [i].GetComponent <Image>().color = options [i].GetComponent <AnswerScript>().startColor;
        options[i].GetComponent<AnswerScript>().isCorrect = false;
        options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

        if(QnA[currentQuestion].correctAnswer == i+1)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = true;
        }
    }
   }

   void GenerateQuestions()
   {
    if(QnA.Count > 0)
    {
    currentQuestion = Random.Range(0, QnA.Count);

    QuestionTxt.text = QnA[currentQuestion].Questions;
    SetAnswers();
    }
    else
    {
        Debug.Log("Out Of Questions");
        GameOver();
    }
   }

}
