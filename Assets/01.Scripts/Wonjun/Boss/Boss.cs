using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    public BossState currentState;
    public TextAnimatorPlayer textplayer;
    public TextMeshProUGUI battleText;
    private void Start()
    {
        TransitionState(new IdleState(this));
    }

    private void Update()
    {
        currentState.Update();
    }

    public void TransitionState(BossState bossState)
    {
        currentState = bossState;
        currentState.EnterState();
    }
}


public abstract class BossState
{
    protected Boss boss;

    public BossState(Boss boss)
    {
        this.boss = boss;
    }

    public virtual void EnterState()
    {
    }

    public abstract void Update();

    public virtual void ExitState()
    {

    }
}

public class IdleState : BossState
{
    public IdleState(Boss boss) : base(boss) { }

    public override void EnterState()
    {
        boss.battleText.SetText("<fade d=3><shake> 3���� �������� ������ ���۵˴ϴ�!</shake>\n<bounce>�غ��ϼ���!");
        boss.textplayer.ShowText(boss.battleText.text);
        
        base.EnterState();
    }

    public override void Update()
    {

    }
    public override void ExitState()
    {
        base.ExitState();
    }
}

public class AttackState : BossState
{
    public AttackState(Boss boss) : base(boss) { }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void Update()
    {
        Debug.LogError("���û��� �԰�");
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
