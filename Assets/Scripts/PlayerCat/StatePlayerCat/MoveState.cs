using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : BasePlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        SoundManagerCat.PlaySound(0, SoundManagerPlayerCat.TypeSound.Step, true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundManagerCat.StopSound(0);
    }
}
