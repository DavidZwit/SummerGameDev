using UnityEngine;
using System.Collections;

public class GameStateHandeler : MonoBehaviour {

    StateMachine gameStates;
    [SerializeField]
    GameObject topVieuw, leftVieuw, rightVieuw;

	void Start()
    {
        gameStates = new StateMachine(gameObject, StatesEnum.idle);

        gameStates.AddState(StatesEnum.idle, new GameStates.Idle(leftVieuw, rightVieuw));
        gameStates.AddState(StatesEnum.slomo, new GameStates.Slomo(topVieuw));
        gameStates.AddState(StatesEnum.good, new GameStates.Good());
        gameStates.AddState(StatesEnum.bad, new GameStates.Bad());

        gameStates.Start();
    }

    void FixedUpdate()
    {
        gameStates.UpdateState();
    }
}
