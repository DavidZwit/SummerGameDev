using UnityEngine;
using System.Collections;

public class GameStateHandeler : MonoBehaviour {

    StateMachine gameStates;

	void Start()
    {
        gameStates = new StateMachine(gameObject, StatesEnum.idle);

        gameStates.AddState(StatesEnum.idle, new GameStates.Idle());
        gameStates.AddState(StatesEnum.slomo, new GameStates.Slomo());
        gameStates.AddState(StatesEnum.good, new GameStates.Good());
        gameStates.AddState(StatesEnum.bad, new GameStates.Bad());

        gameStates.Start();
    }

    void Update()
    {
        gameStates.UpdateState();
    }
}
