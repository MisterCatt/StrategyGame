using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public State(int i = 0)
    {
        n = i;
    }

    private void Awake()
    {
        GetComponent<StateMachine>().myStates.Add(this);
    }

    //for loading specific level purposes. If n == 0 do whatever
    public int n { get; set; }

    [HideInInspector] public StateMachine mySm = null;
    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void FixedUpdateState() { }
    public virtual void ExitState() { }
}

public class StateMachine : MonoBehaviour
{
    State myCurrentState;
    public List<State> myStates = new List<State>();

    public void InitializeStateMachine()
    {
        foreach (State s in myStates)
        {
            s.mySm = this;
        }
    }

    private void FixedUpdate()
    {
        myCurrentState?.FixedUpdateState();
    }

    private void Update()
    {
        myCurrentState?.UpdateState();
    }

    public void ChangeState<T>(int i = 0) where T : State
    {
        foreach (State s in myStates)
        {
            if (s is T)
            {
                myCurrentState?.ExitState();
                myCurrentState = s;
                myCurrentState.n = i;
                myCurrentState.EnterState();
                return;
            }
        }
    }
}
