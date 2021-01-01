using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodItem : MonoBehaviour, IInteractive
{
    [Range(0,100)][SerializeField] private int _food;
    [SerializeField] private float _minSecondCoolDown;
    [SerializeField] private float _maxSecondCoolDown;
    [SerializeField] private GameObject _eat;

    private PlayerCatAI _playerCatAI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ActionModule actionModeul))
        {
            _playerCatAI = actionModeul.GetComponent<PlayerCatAI>();
            actionModeul.TakeActiveItem(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ActionModule actionModeul))
        {
            _playerCatAI = null;
            actionModeul.RemoveActiveItem();
        }
    }
    public void Action()
    {
        _playerCatAI.Eated(_food);
        _eat.SetActive(false);
        StartCoroutine(CoolDownStart(Random.Range(_minSecondCoolDown, _maxSecondCoolDown)));
    }
    public string GetNameTrigerAnimator()
    {
        if (_eat.activeSelf)
            return "Eat";
        else
            return "Nothing";
    }
    private void Recovery()
    {
        _eat.SetActive(true);
    }
    private IEnumerator CoolDownStart(float second)
    {
        yield return new WaitForSeconds(second);
        Recovery();
    }
}
