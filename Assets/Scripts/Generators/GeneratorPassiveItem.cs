using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorPassiveItem : MonoBehaviour
{
    [SerializeField] private SpawnPointPassiveItem[] _spawnPointPassiveItem;
    [SerializeField] private PassiveItem[] prefabPassiveItems;

    private void Start()
    {
        Generate();
    }

    [ContextMenu("Тест генератора")]
    private void Generate()
    {
        foreach (var spawnPoint in _spawnPointPassiveItem)
        {
            Transform item = Instantiate(prefabPassiveItems[Random.Range(0, prefabPassiveItems.Length)], spawnPoint.transform.position, Quaternion.identity, spawnPoint.transform).transform;
            item.transform.localEulerAngles = new Vector3(item.transform.localEulerAngles.x, Random.Range(0, 360), item.transform.localEulerAngles.z);
        }
    }
}
