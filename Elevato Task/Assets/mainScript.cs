using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Canvas canvasMain;
    public Canvas canvasPopUp;
    public Animator popUp;
    public Animator off;
    public Text textSecondTask;
    public float timerSecondTask;
    public bool boolSecondTask;
    public float timeSecond = 3;
    public AudioClip BMW;
    public AudioClip Mercedes;
    public AudioClip Porsche;
    public int randomSound;
    public AudioSource sound;
    public int random;
    public int bmwChoose;
    public int mercedesChoose;
    public int porsheChoose;
    public Image bmwSquare;
    public Image mercedesSquare;
    public Image porsheSquare;
    public Image randomSquare;

    private const string idleBool = "idle";
    private const string showBool = "show";
    private const string closeBool = "close";

    public float timeToClose;
    public bool timeToCloseBool;
   

    void Start()
    {
        canvasMain.enabled = true;
        canvasPopUp.enabled = false;

        textSecondTask.enabled = false;

        popUp = GetComponent<Animator>();

        random = 1;
        mercedesChoose = 0;
        bmwChoose = 0;
        porsheChoose = 0;

    }

    // Update is called once per frame
    void Update()
    {

  

        if(porsheChoose == 1)
        {
            porsheSquare.color = Color.green;
        }

        if(porsheChoose != 1)
        {
            porsheSquare.color = Color.red;
        }

        if(bmwChoose == 1)
        {
            bmwSquare.color = Color.green;
        }

        if(bmwChoose != 1)
        {
            bmwSquare.color = Color.red;
        }

        if(mercedesChoose == 1)
        {
            mercedesSquare.color = Color.green;
        }

        if(mercedesChoose != 1)
        {
            mercedesSquare.color = Color.red;
        }

        if(random == 1)
        {
            randomSquare.color = Color.green;
        }

        if(random != 1)
        {
            randomSquare.color = Color.red;
        }

        if (boolSecondTask)
        {

            textSecondTask.enabled = true;
            timerSecondTask += Time.deltaTime;

            textSecondTask.text = "Znikam za: " +(timeSecond -= Time.deltaTime).ToString("F1"); 

            if(timerSecondTask >= 3)
            {
                boolSecondTask = false;
                textSecondTask.enabled = false;
                timerSecondTask = 0;
                timeSecond = 3;
            }
        }

        if (timeToCloseBool)
        {
            timeToClose += Time.deltaTime;


            if(timeToClose >= 1)
            {
                timeToCloseBool = false;
                canvasPopUp.enabled = false;
                timeToClose = 0;
            }
        }
    }

    public void thirdButtonClicked()
    {
        if (random == 1)
        {



            randomSound = Random.RandomRange(1, 4);

            if (randomSound == 1)
            {
                sound.clip = BMW;

            }

            if (randomSound == 2)
            {
                sound.clip = Mercedes;
            }

            if (randomSound == 3)
            {
                sound.clip = Porsche;
            }

            sound.Play();
        }

        if(bmwChoose == 1)
        {
            sound.clip = BMW;

            sound.Play();
        }

        if(mercedesChoose == 1)
        {
            sound.clip = Mercedes;
            sound.Play();
        }

        if(porsheChoose == 1)
        {
            sound.clip = Porsche;
            sound.Play();
        }

        
    }

    public void bmwClicked()
    {
        bmwChoose = 1;
        mercedesChoose = 0;
        porsheChoose = 0;
        random = 0;
    }

    public void mercedesClicked()
    {
        bmwChoose = 0;
        mercedesChoose = 1;
        porsheChoose = 0;
        random = 0;
    }

    public void porscheClicked()
    {
        bmwChoose = 0;
        mercedesChoose = 0;
        porsheChoose = 1;
        random = 0;
    }

    public void randomClicked()
    {
        bmwChoose = 0;
        mercedesChoose = 0;
        porsheChoose = 0;
        random = 1;
    }

    public void secondButtonClicked()
    {
        boolSecondTask = true;

        textSecondTask.color = Random.ColorHSV();
    }
    public void firstButtonClicked()
    {
        canvasPopUp.enabled = true;

        showAnimation(showBool);

        off.Play("off");
    }

    public void closeButtonClicked()
    {

        showAnimation(closeBool);

        timeToCloseBool = true;

        off.Play("on");
    }

    public void showAnimation(string boolName)
    {
        disableAll(popUp, boolName);

        popUp.SetBool(boolName, true);

    }

    public void disableAll(Animator popUp, string animation)
    {
        foreach(AnimatorControllerParameter parameter in popUp.parameters)
        {
            if(popUp.name != animation)
            {
                popUp.SetBool(parameter.name, false);
            }
        }
    }
}
