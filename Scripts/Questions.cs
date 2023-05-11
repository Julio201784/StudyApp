using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Questions : MonoBehaviour
{
    public GameObject explenationtoggle;
    // change amount_questions in correlation to your question count and project
    // will change for you in accordance, make sure you put the question, and the 2
    // wrong plus correct answer choice and explenations in the correct places
    // in the arrays below
    const int amount_questions = 15;
    string[] questions = { "What is the function of an ALU?"
    ,"What is the function of the PC?"
    ,"What is the function of a mux?"
    ,"What is the function of the register file?"
    ,"What is the function of the on-chip data memory?"
    ,"Which type of instruction uses data memory?"
    ,"Which type of instruction will compare two operands and then possibly jump to a different instruction?"
    ,"Which type of instruction performs an arithmetic or logic operation on two operands and then writes the result into a register?"
    ,"What is the function of the Control Unit?"
    ,"What is the purpose of pipelining?"
    ,"What occurs in the Instruction Fetch stage of the MIPS pipeline?"
    ,"What occurs in the Instruction Decode stage of the MIPS pipeline?"
    ,"What occurs in the Execute stage of the MIPS pipeline?"
    ,"What occurs in the Memory stage of the MIPS pipeline?"
    ,"What occurs in the Write back stage of the MIPS pipeline?"};

    string[] correct_choice = { "Takes 2 operands as input and performs an arithmetic or logic operation on them, outputting the result"
    ,"Holds the memory address of the current instruction"
    ,"Takes 2 operands as input and uses a control signal to decide which to output"
    ,"Stores small amounts of data, but is relatively fast to access"
    ,"Stores large amounts of data, but is relatively slow to access"
    ,"Load/Store"
    ,"Branch"
    ,"ALU"
    ,"Send 1s or 0s to other datapath elements depending on the type of instruction being executed"
    ,"To make programs run faster by making more efficient use of processor resources"
    ,"A new instruction is fetched from instruction memory and the value of the PC is updated"
    ,"The bits of the instruction are sent to different places, and value(s) are read from the register file"
    ,"The main ALU operation is executed and a new memory address is calculated for branching"
    ,"Data memory is written to or read from"
    ,"Data is written into the register file"};

    string[] wrong_1 = { "Takes 2 operands as input and uses a control signal to decide which to output"
    ,"Send 1s or 0s to other datapath elements depending on the type of instruction being executed"
    ,"Holds the memory address of the current instruction"
    ,"Stores large amounts of data, but is relatively slow to access"
    ,"Stores small amounts of data, but is relatively fast to access"
    ,"ALU"
    ,"Load/Store"
    ,"Branch"
    ,"Holds the memory address of the current instruction"
    ,"To make accessing data faster by storing some data memory on the processor"
    ,"Data is written into the register file"
    ,"The main ALU operation is executed and a new memory address is calculated for branching"
    ,"A new instruction is fetched from instruction memory and the value of the PC is updated"
    ,"Data is written into the register file"
    ,"Data memory is written to or read from"};

    string[] wrong_2 = { "Stores large amounts of data, but is relatively slow to access"
    ,"Stores small amounts of data, but is relatively fast to access"
    ,"Takes 2 operands as input and perform an arithmetic operation on them, outputting the result"
    ,"Holds the memory address of the current instruction"
    ,"Takes 2 operands as input and uses a control signal to decide which to output"
    ,"Branch"
    ,"ALU"
    ,"Load/Store"
    ,"Takes 2 operands as input and uses a control signal to decide which to output"
    ,"To make complicated programs more readable"
    ,"The bits of the instruction are sent to different places, and value(s) are read from the register file"
    ,"Data memory is written to or read from"
    ,"Data is written into the register file"
    ,"A new instruction is fetched from instruction memory and the value of the PC is updated"
    ,"The bits of the instruction are sent to different places, and value(s) are read from the register file"};

    string[] explenations = { "Explanation: An ALU performs an arithmetic or logic operation on 2 operands and outputs the result."
    ,"Explanation: The PC holds the memory address of the current instruction"
    ,"Explanation: A mux takes in 2 operands and returns one or the other, depending on which control signal is inputted."
    ,"Explanation: The register file can hold a small amount of data, but that data can be accessed very quickly."
    ,"Explanation: The data memory can hold a relatively large amount of data, but it is not quick to access that data."
    ,"Explanation: In a load or store instruction, data is either loaded from the data memory and saved into a register, or read from a register and stored into the data memory. Both operations use the data memory."
    ,"Explanation: A branch instruction compares two operands and then, depending on the instruction and type of comparison, may jump to another instruction. This could consist of branching if two values are equal or unequal, similarly to if statements in higher level languages."
    ,"Explanation: An ALU instruction performs an arithmetic or logic operation on two operands, using the ALU. The result is then written into a register."
    ,"Explanation: The Control Unit receives the first few bits of an instruction. It then sends out 1s or 0s known as control signals to the other datapath elements so that only the elements necessary for the current type of instruction will be used."
    ,"Explanation: Pipelining is a process in which the datapath is split into several stages so that multiple instructions can be run simultaneously. This is done to increase speed by minimizing wasted time."
    ,"Explanation: In the Instruction Fetch stage, the next instruction is fetched from instruction memory. Also, the value of the PC is incremented by 4, so that in the next cycle PC will refer to the next instruction."
    ,"Explanation: In the Instruction Decode stage, the bits of the instruction are sent to different places, including the Control Unit and the register file. Also, the value of one or more registers (specified in the instruction) are read and outputted."
    ,"Explanation: In the Execute stage, an arithmetic or logic operation is performed by the main ALU. Also, a mux is used to determine whether the PC will use the next instruction in sequential order or a different instruction (in the case of a successful branch instruction)."
    ,"Explanation: In the Memory stage, data memory is interacted with. This interaction could be loading data to be written back into a register, or storing the result of an ALU operation. Because not all instructions use memory, some instructions will do nothing in this stage."
    ,"Explanation: In the Write back stage, data is written back into the register file. This data is either a result of the ALU operation or a value loaded from the data memory. Not all instructions will write back."};

    // leave alone //
    int ammountCorrect, highScore = 0;

    public Button option1, option2, option3, new_question;

    public Text option1T, option2T, option3T, explenationforQ, numQon, nextOrFinBtn;
    bool option1B, option2B, option3B, finished = false;

    public Canvas Questons_Page, finished_page;

    public Text question_text, ammount_Right, HighScoreText;

    int currentQuestion = 0;

    bool current_Answered = true;
    bool[] Qdone= new bool[amount_questions];
    // leave alone //


    // Start is called before the first frame update and generates
    // a initial question
    void Start()
    {
        Button newQ = new_question.GetComponent<Button>();
        newQ.onClick.AddListener(newQuestion);

        Button choice1 = option1.GetComponent<Button>();
        choice1.onClick.AddListener(answerChoice1);
        Button choice2 = option2.GetComponent<Button>();
        choice2.onClick.AddListener(answerChoice2);
        Button choice3 = option3.GetComponent<Button>();
        choice3.onClick.AddListener(answerChoice3);

        newQuestion();
    }

    //generates a new queston at random, and does not allow skipping questions
    void newQuestion()
    {
        
        if(current_Answered)
        {
            ResetButton();
            checkiffinished();
            int question_num = Random.Range(0, amount_questions);
            if (!Qdone[question_num])
            {
                question_text.text = questions[question_num];
                explenationforQ.text = explenations[question_num];
                explenationtoggle.gameObject.SetActive(false);
                set_AnswerBtns(question_num);
                current_Answered = false;
                Qdone[question_num] = true;
                currentQuestion++;
                setQnumTxt();
                checkAllQFin();
            }
            else
            {
                newQuestion();
            }
        }   
    }



    // sets middle box above the question text to
    // show what question number currently on
    void setQnumTxt()
    {
        numQon.text = "Question:\n" + currentQuestion + "/" + amount_questions;
    }


    // checks if all Questions have been finished,
    // if have sets "next question" text to "Finished" 
    // if not keeps "Next Question"
    void checkAllQFin()
    {
        if(currentQuestion == amount_questions)
        {
            nextOrFinBtn.text = "Finish";
        }
        else
        {
            nextOrFinBtn.text = "Next Question";
        }
        
    }


    

    // sets answers into textbox at random order
    void set_AnswerBtns(int question_num)
    {
        int order = Random.Range(0, 100);
        order %= 3;
        option1B = false;
        option2B = false;
        option3B = false;
        switch (order)
        {
            case 0:
                option1T.text = correct_choice[question_num];
                option2T.text = wrong_1[question_num];
                option3T.text = wrong_2[question_num];
                option1B = true;
                break;
            case 1:
                option1T.text = wrong_1[question_num];
                option2T.text = correct_choice[question_num];
                option3T.text = wrong_2[question_num];
                option2B = true;
                break;
            case 2:
                option1T.text = wrong_1[question_num];
                option2T.text = wrong_2[question_num];
                option3T.text = correct_choice[question_num];
                option3B = true;
                break;
            default:
                set_AnswerBtns(question_num);
                break;
        }
    }
   
    //checks if correct, if is turns green, if not red 
    void answerChoice1()
    {
        if (!current_Answered && option1B)
        {
            option1.GetComponent<Image>().color = Color.green;
            addCorrect();
            updateScores();
        }
        else if (!current_Answered)
        {
            option1.GetComponent<Image>().color = Color.red;

            current_Answered = true;
        }
        explenationtoggle.gameObject.SetActive(true);
    }

    //checks if correct, if is turns green, if not red 
    void answerChoice2()
    {
        if (!current_Answered && option2B)
        {
            option2.GetComponent<Image>().color = Color.green;
            addCorrect();
            updateScores();
        }
        else if(!current_Answered)
        {
            option2.GetComponent<Image>().color = Color.red;

            current_Answered = true;
        }
        explenationtoggle.gameObject.SetActive(true);
    }

    //checks if correct, if is turns green, if not red 
    void answerChoice3()
    {
        if (!current_Answered && option3B)
        {
            option3.GetComponent<Image>().color = Color.green;
            addCorrect();
            updateScores();
        }
        else if (!current_Answered)
        {
            option3.GetComponent<Image>().color = Color.red;

            current_Answered = true;
        }
        explenationtoggle.gameObject.SetActive(true);
    }

    // checks if all questions have been done, if has calls completeScreen()
    bool checkiffinished()
    {
        finished = true;
        for (int i= 0; i < amount_questions; i++)
        {
            if (Qdone[i]==false)
            {
                finished = false;
                 break;
            }
        }
        if (finished)
        {
            completeScreen();
        }
        return finished;
    }

    // resest buttons colors
    // only called when generated new question and finished
    private void ResetButton()
    {
        option1.GetComponent<Image>().color = Color.white;
        option2.GetComponent<Image>().color = Color.white;
        option3.GetComponent<Image>().color = Color.white;
    }

    // sets highscore resetting score anf current question
    // only called when completed
    void isHighScore()
    {
        if (ammountCorrect > highScore)
        {
            highScore = ammountCorrect;
            //need to add save file code
        }
        ammountCorrect = 0;
        currentQuestion = 0;
        updateScores();
    }
    // only called if all questions are answered and resets all variables
    void completeScreen()
    {
        isHighScore();
        
        for(int i = 0; i < amount_questions; i++)
        {
            Qdone[i] = false;
        }
        Questons_Page.gameObject.SetActive(false);
        finished_page.gameObject.SetActive(true);
    }

    // adds a counter for each correct question
    void addCorrect()
    {
        if (!current_Answered)
        {
            ammountCorrect++;
            current_Answered = true;
        }
    }
    void updateScores()
    {
        ammount_Right.text = "Score:\n" + ammountCorrect.ToString();
        HighScoreText.text = "High Score:\n" + highScore.ToString();
    }
}
