using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Character  : AbCharacter
{
    //firing---------------------
    public Transform[] projectilePoints;
    public Projectile projectilePrefab;
    //List<Projectile> projectiles = new List<Projectile>();
    public const float MIN_SIZE = 1f;
    private string animName;
    public bool isMoving = false;
    public CounterTime fireRate = new CounterTime(2);
    protected IState<Character> currentState;
    
    
    //targeting---------------------
    public Transform indicatorPoint;
    //protected TargetIndicator indicator;
    public List<Character> targets;
    protected Character target;
    public Vector3 targetPoint;

    //character var-----------------
    private int score;
    protected float size = 1;
    public int Score => score;
    public float Size => size;
    public bool IsDead { get; protected set; }
    public bool IsCanAttack { get; protected set; }
    //public bool IsCanRunning { get; protected set; }

    //Customization-----------------
    public WeaponData weaponData;
    public Transform hand;
    

    public void WeaponController()
    {

    }
    public override void OnInit()
    {
        IsDead = false;
        IsCanAttack = true;
        score = 0;
        targets = new List<Character>();
    }
    
    public override void OnDespawn()
    {
        throw new System.NotImplementedException();
    }

    public override void OnDeath()
    {
        throw new System.NotImplementedException();
    }
    //Attack
    public override void OnAttack()
    {
        //target = GetFirstTarget();

        if (IsCanAttack && target != null && !target.IsDead/* && currentSkin.Weapon.IsCanAttack*/)
        {
            targetPoint = target.TF.position;
            TF.LookAt(targetPoint + (TF.position.y - targetPoint.y) * Vector3.up);
            //ChangeAnim(Constant.ANIM_ATTACK);
        }
    }
    public void Update()
    {
        Target();
        fireRate.StartCount();
        if (isMoving && currentState != null && !IsDead)
        {
            currentState.OnExecute(this);

        }
    }
    public Character GetFirstTarget()
    {
         return targets[0];
    }
    public void AddTarget(Character c)
    {
        targets.Add(c);
        
    }
    public void RemoveTarget(Character c)
    {
        if (targets.Contains(c) && targets.Count > 0)
        {
            targets.Remove(c);
        }
    }
    protected void ClearTarget()
    {
        targets.Clear();
    }
    public override void OnMoveStop()
    {
        transform.LookAt(target.transform);
    }
    public void printTargetList()
    {
        Debug.Log(targets.Count.ToString());
    }
    public void ChangeState(IState<Character> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = state;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }

    }
    public void ChangeAnim(string animName)
    {
        
    }
    public void Target()
    {
        if (targets.Count > 0)
        {
            target = GetFirstTarget();
        }
        else if(targets.Count <= 0)
        {
            target = null;
        }
    }
    public void Fire()
    {
        if(target != null  && !fireRate.IsRunning)
        {
            ChangeAnim(Constant.ANIM_ATTACK);
            SimplePool.Spawn<Projectile>(PoolType.Projectile, transform.position, transform.rotation).OnInit();
            fireRate.ResetCounter();
        }
        
    }
}
