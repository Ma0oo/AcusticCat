using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EateState : BasePlayerState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        SoundManagerCat.PlaySound(1, SoundManagerPlayerCat.TypeSound.Eating, false);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ActionModul.Action();
        animator.ResetTrigger(ActionModul.ActiveItem.GetNameTrigerAnimator());
        ActionModul.RemoveActiveItem();
    }
}
