using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransitSmt : MonoBehaviour
{
    public event UnityAction<TagCanTransit> StartTransition;

    private Door _door;
    private BlackScreen _blackScreen;
    private TagCanTransit _targetForTransit;

    private void Awake()
    {
        _door = GetComponentInParent<Door>();
        _blackScreen = Camera.main.GetComponent<BlackScreen>();
    }
    private void OnEnable()
    {
        _blackScreen.NowBlackScreen += OnBlackScreen;    
    }
    private void OnDisable()
    {
        _blackScreen.NowBlackScreen -= OnBlackScreen;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out TagCanTransit tagCanTransit))
        {
            if (!tagCanTransit.IsPlayer)
            {
                _door.EnterSomething(tagCanTransit);
            }
            else
            {
                _blackScreen.StartToBlackScreen();
                Debug.Log(_targetForTransit == null);
                _targetForTransit = tagCanTransit;
                Debug.Log(_targetForTransit == null);
            }
        }
    }

    private void OnBlackScreen()
    {
        if (_targetForTransit != null)
        {
            Debug.Log(_targetForTransit == null);
            _door.EnterSomething(_targetForTransit);
            _blackScreen.StartToWhiteScreen();
            _targetForTransit = null;
        }
    }
}
