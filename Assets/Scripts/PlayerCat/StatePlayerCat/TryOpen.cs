using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryOpen : BasePlayerState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        Debug.Log("Вход в состояние");
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ActionModul.Action();
        animator.ResetTrigger(ActionModul.ActiveItem.GetNameTrigerAnimator());
        ActionModul.RemoveActiveItem();
        Debug.Log("Выход из состояния");
    }
}
