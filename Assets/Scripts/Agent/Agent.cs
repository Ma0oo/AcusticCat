using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


[RequireComponent(typeof(AngetSound))]
public class Agent : MonoBehaviour
{
    public event UnityAction FinishListen;
    public static event UnityAction AgentWasListenUpdateHud;

    [SerializeField] private float _secondToListen;
    [SerializeField] private Image _imageBar;
    [SerializeField] private ParticleSystem _particle;

    private Animator _animator;
    private Camera _mainCamera;
    private float _currentTimeListed;
    private PlayerCatAI _playerCat;
    private AngetSound _angetSound;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _mainCamera = Camera.main;
        _angetSound = GetComponent<AngetSound>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.TryGetComponent(out PlayerCatAI playerCat))
        {
            _angetSound.PlaySound();
            _playerCat = playerCat;
            StartCoroutine(Listen());
        }
    }
    private void Update()
    {
        _imageBar.transform.LookAt(_mainCamera.transform);
    }
    private void OnTriggerExit(Collider other)
    {
        _angetSound.StopSound();
        _playerCat = null;
    }
    private void OnEnable()
    {
        FinishListen += OnFiniveListen;    
    }
    private void OnDisable()
    {
        FinishListen -= OnFiniveListen;
    }
    public void StartTelephoneTalkAnimatioo()
    {
        _animator.SetInteger("State", (int)State.TelephoneTalk);
    }
    public void StartRealTalkAnimation() 
    {
        _animator.SetInteger("State", (int)State.RealTalk);
    }
    private void StartIdelState()
    {
        _animator.SetInteger("State", (int)State.Idel);
    }
    private void OnFiniveListen()
    {
        StartIdelState();
        Instantiate(_particle, _imageBar.transform.position, Quaternion.identity);
        AgentWasListenUpdateHud?.Invoke();
        Destroy(this);
    }
    private IEnumerator Listen()
    {
        while (_playerCat != null)
        {
            _currentTimeListed += Time.deltaTime;
            _imageBar.fillAmount = _currentTimeListed / _secondToListen;
            if (_currentTimeListed >= _secondToListen)
                FinishListen?.Invoke();
            yield return null;
        }
    }

    private enum State
    {
        Idel, RealTalk, TelephoneTalk
    }
}
