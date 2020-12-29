using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionModule : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerCatAI _playerCatAI;

    public IInteractive ActiveItem { get; private set; }

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerCatAI = GetComponent<PlayerCatAI>();
    }
    private void OnEnable()
    {
        _playerInput.DownKeyInterect += Interactive;
    }
    private void OnDisable()
    {
        _playerInput.DownKeyInterect -= Interactive;

    }
    public void TakeActiveItem(IInteractive activeItem)
    {
        ActiveItem = activeItem;
    }
    public void RemoveActiveItem()
    {
        ActiveItem = null;
    }
    public void Action()
    {
        Debug.Log("Вызывают эекшен у активного предмета");
        ActiveItem.Action();
    }

    private void Interactive()
    {
        if(ActiveItem != null)
        {
            Debug.Log("Запускаю интерактивную анимацию");
             _playerCatAI.SetTriggerAnimator(ActiveItem.GetNameTrigerAnimator());
        }
    }
}
