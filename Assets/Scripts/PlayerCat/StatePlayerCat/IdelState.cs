using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdelState : BasePlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if (Random.Range(0, 1f) < 0.1)
            SoundManagerCat.PlaySound(1, SoundManagerPlayerCat.TypeSound.Meow, false);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
