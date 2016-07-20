public interface State
{
    void Enter(UnityEngine.GameObject theObject);
    bool Reason();
    void Act();
    StatesEnum Leave();
}
