
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DragNDrop : MonoBehaviour, IDropHandler
{
    // Original positions of 5 drag and drop answers
    Vector2 pos1 = new Vector2(0, -340);
    Vector2 pos2 = new Vector2(-260, -480);
    Vector2 pos3 = new Vector2(260, -480);
    Vector2 pos4 = new Vector2(-260, -620);
    Vector2 pos5 = new Vector2(260, -620);

    
    // change number_Questions to correlating questions and answers
    const int number_Questions = 5;
    

    // add answer choices in line with correct answers in order of
    // datapathSpt[] to set correct answer choices at end
    public Sprite[] datapathSpt = new Sprite[number_Questions];
    string[] answerChoices = { "ALU", "BRANCH", "LOAD", "NOT VALID", "STORE" };

    // leave alone //
    public Text EndScreentxt;
    public Canvas DND, completeDND;

    int num_Qon = 0;

    public Image datapathImg;

    public GameObject[] choices = new GameObject[number_Questions];

    bool[] choicesb = new bool[number_Questions];
    bool[] datapathDone = new bool[number_Questions];

    string[] correctAnswers = new string[number_Questions];
    string[] userAnswers = new string[number_Questions];
    bool isFinished = false;
    // leave alone //

    //generates new question on start
    void Start()
    {
        newImage();
    }
    void newImage()
    {

        isFinished = checkiffinished();
        if (isFinished)
        {
            completeScreen();
        }
        else
        {
            int question_num = Random.Range(0, number_Questions);
            if (!datapathDone[question_num])
            {
                resetCorrect();
                setCorrect(question_num);

                datapathDone[question_num] = true;
            }
            else
            {
                newImage();
            }
        }
    }
    void resetCorrect()
    {
        for (int i = 0; i < number_Questions; i++)
        {
            choicesb[i] = false;
        }
    }
    void setCorrect(int question_num)
    {
        switch (question_num)
        {
            case 0:
                choicesb[0] = true;
                datapathImg.sprite = datapathSpt[0];
                break;
            case 1:
                choicesb[1] = true;
                datapathImg.sprite = datapathSpt[1];
                break;
            case 2:
                choicesb[2] = true;
                datapathImg.sprite = datapathSpt[2];
                break;
            case 3:
                choicesb[3] = true;
                datapathImg.sprite = datapathSpt[3];
                break;
            case 4:
                choicesb[4] = true;
                datapathImg.sprite = datapathSpt[4];
                break;
            default:

                break;
        }
        setCorrectChoice(question_num);
    }
    void setCorrectChoice(int question_num)
    {
        correctAnswers[num_Qon] = answerChoices[question_num];
        Debug.Log(correctAnswers[num_Qon] + "  " + answerChoices[question_num] + "  " + num_Qon);
        
    }
    // get rid of inner correct wrong if else
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        
        if (choices[0].GetComponent<RectTransform>().anchoredPosition == new Vector2(0, -255))
            {
                userAnswers[num_Qon] = answerChoices[0];
                num_Qon++;
                choices[0].gameObject.SetActive(false);
                choices[0].GetComponent<RectTransform>().anchoredPosition = pos1;
                

                newImage();
            }
            if (choices[1].GetComponent<RectTransform>().anchoredPosition == new Vector2(0, -255))
            {
                userAnswers[num_Qon] = answerChoices[1];
                num_Qon++;
                choices[1].gameObject.SetActive(false);
                choices[1].GetComponent<RectTransform>().anchoredPosition = pos2;
               

                newImage();
            }
            if (choices[2].GetComponent<RectTransform>().anchoredPosition == new Vector2(0, -255))
            {
                userAnswers[num_Qon] = answerChoices[2];
                num_Qon++;
                choices[2].gameObject.SetActive(false);
                choices[2].GetComponent<RectTransform>().anchoredPosition = pos3;    

                newImage();
            }
            if (choices[3].GetComponent<RectTransform>().anchoredPosition == new Vector2(0, -255))
            {
                userAnswers[num_Qon] = answerChoices[3];
                num_Qon++;
                choices[3].gameObject.SetActive(false);
                choices[3].GetComponent<RectTransform>().anchoredPosition = pos4;              

                newImage();
            }
            if (choices[4].GetComponent<RectTransform>().anchoredPosition == new Vector2(0, -255))
            {
                userAnswers[num_Qon] = answerChoices[4];
                num_Qon++;
                choices[4].gameObject.SetActive(false);
                choices[4].GetComponent<RectTransform>().anchoredPosition = pos5;
                
                newImage();
            }


        }
    }
    bool checkiffinished()
    {
        bool finished = true;
        for (int i = 0; i < number_Questions; i++)
        {
            if (datapathDone[i] == false)
            {
                finished = false;
                break;
            }
        }

        return finished;
    }
    void completeScreen()
    {
        completeDND.gameObject.SetActive(true);
        EndScreentxt.text = "Question 1:\nCorrect Answer: " + correctAnswers[0] + "\nYou Answered: " + userAnswers[0] + "\n"
                            + "Question 2:\nCorrect Answer: " + correctAnswers[1] + "\nYou Answered: " + userAnswers[1] + "\n"
                            + "Question 3:\nCorrect Answer: " + correctAnswers[2] + "\nYou Answered: " + userAnswers[2] + "\n"
                            + "Question 4:\nCorrect Answer: " + correctAnswers[3] + "\nYou Answered: " + userAnswers[3] + "\n"
                            + "Question 5:\nCorrect Answer: " + correctAnswers[4] + "\nYou Answered: " + userAnswers[4];

        resetAll();
        DND.gameObject.SetActive(false);
        
    }

    void resetAll()
    {
        for (int i = 0; i < number_Questions; i++)
        {
            datapathDone[i] = false;
            choices[i].GetComponent<CanvasGroup>().alpha = 1.0f;
            choices[i].GetComponent<CanvasGroup>().blocksRaycasts = enabled;
            choices[i].gameObject.SetActive(true);
        }
        resetCorrect();
        num_Qon = 0;
        newImage();



    }

}
