using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactionTest : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Button StopButton;
    [SerializeField] Button ContinueButton;

    [SerializeField] TextMeshProUGUI stopwatch;

    enum State { Idle, wait, start, stop };
    State myState = State.Idle;

    float time;
    float timeTreshHold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartButton.onClick.AddListener(OnStartButtonClicked);
        StopButton.onClick.AddListener(OnStopButtonClicked);
        ContinueButton.onClick.AddListener(OnContinueButtonClicked);
        upDateUI();

        stopwatch.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(myState == State.Idle)
        {
            time += Time.deltaTime;
           stopwatch.text = time.ToString("F2");
            if(time > timeTreshHold)
            {
                myState = State.start;
                time = 0;
                upDateUI();
            }
        }

        if(myState == State.start)
        {
            time += Time.deltaTime;
            stopwatch.text = time.ToString("F2");
        }

    }

    void OnStartButtonClicked()
    {
        // print("op start geclikt");
        myState = State.wait;
        timeTreshHold = Random.Range(2, 5);

    }

    void OnStopButtonClicked()
    {
        //print("OnStopButtonClicked");
        myState = State.stop;
    }

    void OnContinueButtonClicked()
    {
        //print("OnContinueButtonClicked");
        myState = State.Idle;
    }

    void upDateUI()
    {
        StartButton.gameObject.SetActive(myState == State.Idle);
        StopButton.gameObject.SetActive(myState == State.start);
        ContinueButton.gameObject.SetActive(myState == State.stop);

    }
}
