using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePage : MonoBehaviour
{
    public Button toQuestionBtn, toMainBtn, bkToMain, bkToMainDND, toDND, fromDND;
    public Canvas mainPage, questionPage, completePage, completePageDND, DND;

    // Start is called before the first frame update
    void Start()
    {
        Button toQbtn = toQuestionBtn.GetComponent<Button>();
        toQbtn.onClick.AddListener(toQuestions);

        Button toMbtn = toMainBtn.GetComponent<Button>();
        toMbtn.onClick.AddListener(toMain);

        Button bktoMbtn = bkToMain.GetComponent<Button>();
        bktoMbtn.onClick.AddListener(backToMain);

        Button bkToMainDNDBTN = bkToMainDND.GetComponent<Button>();
        bkToMainDNDBTN.onClick.AddListener(backToMainDND);

        Button toDNDBTN = toDND.GetComponent<Button>();
        toDNDBTN.onClick.AddListener(toDragNDrop);

        Button fromDNDBTN = fromDND.GetComponent<Button>();
        fromDNDBTN.onClick.AddListener(bktomainfromDND);
    }
    void bktomainfromDND()
    {
        DND.gameObject.SetActive(false);
        mainPage.gameObject.SetActive(true);
    }
    void toDragNDrop()
    {
        DND.gameObject.SetActive(true);
        mainPage.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void backToMainDND()
    {
        completePageDND.gameObject.SetActive(false);
        mainPage.gameObject.SetActive(true);
    }

    void toQuestions()
    {
        mainPage.gameObject.SetActive(false);
        questionPage.gameObject.SetActive(true);
    }
    void toMain()
    {
        questionPage.gameObject.SetActive(false);
        mainPage.gameObject.SetActive(true);
    }

    void backToMain()
    {
        completePage.gameObject.SetActive(false);
        mainPage.gameObject.SetActive(true);
    }
}
