using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTwoAgent : MonoBehaviour
{
    [SerializeField] private Agent _agent1;
    [SerializeField] private Agent _agent2;
    private void Awake()
    {
        _agent1.gameObject.SetActive(false);
        _agent2.gameObject.SetActive(false);
    }
    public void Spawn()
    {
        if (Random.Range(0, 2) == 0)
            SpawnOneAgent();
        else
            SpawnTwoAgent();
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
