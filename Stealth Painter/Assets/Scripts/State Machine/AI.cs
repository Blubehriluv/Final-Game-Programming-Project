using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class AI : MonoBehaviour
{
    public bool switchState = false;

    public StateMachine<AI> stateMachine { get; set; }

    private void Start()
    {
        stateMachine = new StateMachine<AI>(this);

    }

    private void Update()
    {
        
    }
}
