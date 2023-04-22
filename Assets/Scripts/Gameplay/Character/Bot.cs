using System.Collections;
using System.Collections.Generic;
using UIExample;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    
    Vector3 destination;
    [SerializeField] protected NavMeshAgent agent;
    
    //private bool IsCanRunning => (GameManager.Ins.IsState(GameState.GamePlay) || GameManager.Ins.IsState(GameState.Revive) || GameManager.Ins.IsState(GameState.Setting));
    

    private void Start()
    {
        ChangeState(new IdleState());
    }
    
}
