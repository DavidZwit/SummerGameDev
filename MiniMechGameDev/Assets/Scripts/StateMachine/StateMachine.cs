using UnityEngine;
using System.Collections.Generic;

public enum StatesEnum {
    good,
    bad,
    slomo,
    idle
}

class StateMachine {

    GameObject obj;
    Animation anim;
    State currentState;
    StatesEnum defaultState;
    Dictionary<StatesEnum, State> States = new Dictionary<StatesEnum, State>();

    public StateMachine(GameObject _obj, StatesEnum _defautState, Animation _anim = null)
    {
        obj = _obj;
        defaultState = _defautState;
        anim = _anim;
    }

    public void Start() {
        currentState = States[defaultState];
        currentState.Enter(obj);
    }

    public void AddState (StatesEnum  enumPos, State theState) {
        States.Add(enumPos, theState);
    }

    public void UpdateState()
    {

        if (currentState.Reason()) {
            currentState.Act();
        } else {
            try { currentState = States[currentState.Leave()]; }
            catch { currentState = States[defaultState]; }

            currentState.Enter(obj);
        }
    }
}
