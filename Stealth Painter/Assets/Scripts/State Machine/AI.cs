using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using StateStuff;

public class AI : MonoBehaviour
{
    public bool switchState = false;
    public float gameTimer;
    public int seconds = 0;

    public StateMachine<AI> stateMachine { get; set; }

    private void Start()
    {
        stateMachine = new StateMachine<AI>(this);
        stateMachine.ChangeState(FirstState.Instance);
        gameTimer = Time.time;
    }

    private void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if (Time.time > gameTimer + 1)
            {
                gameTimer = Time.time;
                seconds++;
                Debug.Log(seconds);
            }

            if (seconds == 3)
            {
                Debug.Log("Nothing found!");
                seconds = 0;
            }
        }

        if (other == GameObject.FindWithTag("Player"))
        {
            Debug.Log("Player found!");
            switchState = !switchState;
            stateMachine.Update();
        }
    }
}
