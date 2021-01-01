using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction DownKeyMoveForward;
    public event UnityAction DownKeyRotateRight;
    public event UnityAction DownKeyRotateLeft;
    public event UnityAction DownKeyIdel;

    public event UnityAction DownKeyInterect;

    private void Update()
    {
        CheckKey(KeyCode.W, DownKeyMoveForward, ModePress.down);
        CheckKey(KeyCode.D, DownKeyRotateRight, ModePress.down);
        CheckKey(KeyCode.A, DownKeyRotateLeft, ModePress.down);
        CheckKey(KeyCode.S, DownKeyIdel, ModePress.down);

        CheckKey(KeyCode.E, DownKeyInterect, ModePress.down);
    }

    private void CheckKey(KeyCode keyCode, UnityAction unityAction, ModePress modePress)
    {
        switch (modePress)
        {
            case ModePress.down:
                if (Input.GetKeyDown(keyCode))
                    unityAction?.Invoke();
                break;
            case ModePress.hold:
                if (Input.GetKey(keyCode))
                    unityAction?.Invoke();
                break;
            case ModePress.up:
                if (Input.GetKeyUp(keyCode))
                    unityAction?.Invoke();
                break;
            default:
                throw new System.Exception("Ты шо сюда засунул?! о_0");
        }
    }
    private enum ModePress
    {
        down, hold, up
    }
}
