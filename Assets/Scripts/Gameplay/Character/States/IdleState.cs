using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Character>
{
    public void OnEnter(Character t)
    {
        t.ChangeState(new PatrolState());
    }

    public void OnExecute(Character t)
    {
        
    }

    public void OnExit(Character t)
    {

    }

}
