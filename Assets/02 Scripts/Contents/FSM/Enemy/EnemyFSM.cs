public enum EnemyStateType
{
    Idle,
    Patrol,
    Chase,
    Stunned,
    Attack,
    Hurt,
    Dead,
}

public class EnemyFSM : FSM<EnemyBase, EnemyStateType>
{
    public EnemyFSM(EnemyBase owner)
    {
        AddState(EnemyStateType.Idle, new EnemyIdleState(owner));
        AddState(EnemyStateType.Patrol, new EnemyPatrolState(owner));
        AddState(EnemyStateType.Chase, new EnemyChaseState(owner));
        AddState(EnemyStateType.Stunned, new EnemyStunnedState(owner));
        AddState(EnemyStateType.Attack, new EnemyAttackState(owner));
        AddState(EnemyStateType.Hurt, new EnemyHurtState(owner));
        AddState(EnemyStateType.Dead, new EnemyDeadState(owner));
    }
}