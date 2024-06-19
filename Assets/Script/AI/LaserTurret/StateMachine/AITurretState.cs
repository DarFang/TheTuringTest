public abstract class AITurretState
{
    protected AITurretController controller;
    public AITurretState(AITurretController contr)
    {
        controller = contr;
    }   
    public abstract void OnStateEnter();
    public abstract void OnStateRun();
    public abstract void OnStateExit();
    public abstract void NextState();
}