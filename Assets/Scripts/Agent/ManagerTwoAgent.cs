using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTwoAgent : MonoBehaviour
{
    [SerializeField] private Agent _agent1;
    [SerializeField] private Agent _agent2;

    private int _chanceToSpawnOneAgent = 78;

    private void Awake()
    {
        _agent1.gameObject.SetActive(false);
        _agent2.gameObject.SetActive(false);
    }
    public int Spawn()
    {
        int cout = Random.Range(0,101);
        if (cout < _chanceToSpawnOneAgent)
        {
            SpawnOneAgent();
            Debug.Log("Один агент установлен");
            return 1;
        }
        else
        {
            SpawnTwoAgent();
            Debug.Log("Два агента установлены");
            return 2;
        }
    }
    private void SpawnTwoAgent()
    {
        _agent1.gameObject.SetActive(true);
        _agent2.gameObject.SetActive(true);
        _agent1.StartRealTalkAnimation();
        _agent2.StartRealTalkAnimation();
    }
    private void SpawnOneAgent()
    {
        if (Random.Range(0, 2) == 0)
        {
            _agent1.gameObject.SetActive(true);
            _agent1.StartTelephoneTalkAnimatioo();
        }
        else
        {
            _agent2.gameObject.SetActive(true);
            _agent2.StartTelephoneTalkAnimatioo();
        }
            
    }
    
}
