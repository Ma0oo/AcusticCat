using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerState : StateMachineBehaviour
{
    protected CatMover CatMover;
    protected PlayerCatAI PlayerCatAI;
    protected PlayerInput PlayerInput;
    protected ActionModule ActionModul;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (CatMover == null)
            CatMover = animator.GetComponentInParent<CatMover>();
        if (PlayerCatAI == null)
            PlayerCatAI = animator.GetComponentInParent<PlayerCatAI>();
        if (PlayerInput == null)
            PlayerInput = animator.GetComponentInParent<PlayerInput>();
        if (ActionModul == null)
            ActionModul = animator.GetComponentInParent<ActionModule>();

    }
}
