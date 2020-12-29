using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerState : StateMachineBehaviour
{
    private CatMover _catMover;
    private PlayerCatAI _playerCatAI;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_catMover == null)
            _catMover = animator.GetComponentInParent<CatMover>();
        if (_playerCatAI == null)
            _playerCatAI = animator.GetComponentInParent<PlayerCatAI>();
    }
}
