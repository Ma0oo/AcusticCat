using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerCatAI))]
public class Special : MonoBehaviour
{
    public static event UnityAction<float> UpdateFood;
    public static event UnityAction<float> UpdateStress;
    public static event UnityAction GameOver;

    [SerializeField] private Bar _food;
    [SerializeField] private Bar _stress;

    private PlayerCatAI _playerCatAI;

    private void Awake()
    {
        _food.CastomStart();
        _stress.CastomStart();

        _playerCatAI = GetComponent<PlayerCatAI>();

        UpdateFood?.Invoke(_food.GetPercent());
        UpdateStress?.Invoke(_stress.GetPercent());
    }
    private void OnEnable()
    {
        _playerCatAI.Eating += OnEating;
        _playerCatAI.Stressing += OnStressing;
    }
    private void OnDisable()
    {
        _playerCatAI.Eating -= OnEating;
        _playerCatAI.Stressing -= OnStressing;
    }
    private void Update()
    {
        _food.LoseValueInUpdate();

        UpdateFood?.Invoke(_food.GetPercent());

        if (_food.IsEmpty)
            GameOver?.Invoke();
    }
    private void OnEating(float countFood)
    {
        _food.AddValue(countFood);
        _stress.LoseValue(25);

        UpdateFood?.Invoke(_food.GetPercent());
        UpdateStress?.Invoke(_stress.GetPercent());
    }
    private void OnStressing(float countStress)
    {
        _stress.AddValue(countStress);

        UpdateStress?.Invoke(_stress.GetPercent());

        if (_stress.IsFull)
            GameOver?.Invoke();
    }

}

[System.Serializable]
public class Bar
{
    public bool IsFull => _currentValue >= 100;
    public bool IsEmpty => _currentValue <= 0;

    [Range(0, 100)] [SerializeField] private int _startValue;
    [Range(0,3)][SerializeField] private float _speedDrop;
    private float _currentValue;

    public void CastomStart()
    {
        _currentValue = _startValue;
    }
    public void LoseValueInUpdate()
    {
        _currentValue -= Time.deltaTime * _speedDrop;
    }
    public void AddValue(float value)
    {
        _currentValue += value;
        if (_currentValue > 105f)
            _currentValue = 105;
    }
    public void LoseValue(float valus)
    {
        _currentValue -= valus;
        if (_currentValue < 0)
            _currentValue = 0;
    }
    public float GetPercent()
    {
        if (_currentValue < 0)
            _currentValue = 0;
        return _currentValue / 100f;
    }
}
