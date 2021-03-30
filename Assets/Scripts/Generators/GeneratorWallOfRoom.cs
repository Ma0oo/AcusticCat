using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorWallOfRoom : MonoBehaviour
{
    [SerializeField] private SO_floarAndWallOfRoom[] dataBasesWallAndFLoar;
    private Wall[] _walls;
    private Floar[] _floars;
    [SerializeField] private Transform _parentWall;
    [SerializeField] private Transform _parentFloar;

    private SO_floarAndWallOfRoom dataBaseWallAndFLoar;

    private void Start()
    {
        _floars = GetComponentsInChildren<Floar>();
        _walls = GetComponentsInChildren<Wall>();

        GenerateAll();
    }

    [ContextMenu("Протестировать генератор стен и полов")]
    private void GenerateAll()
    {
        dataBaseWallAndFLoar = dataBasesWallAndFLoar[Random.Range(0, dataBasesWallAndFLoar.Length)];

        int floarId = Random.Range(0, dataBaseWallAndFLoar.Floar.Length);
        int wallId = Random.Range(0, dataBaseWallAndFLoar.Wall.Length);

        List<Vector3> positions = new List<Vector3>();
        List<Vector3> rotate = new List<Vector3>();
        foreach (var wall in _walls)
        {
            positions.Add(wall.transform.position);
            rotate.Add(wall.transform.localEulerAngles);
            Destroy(wall.gameObject);
        }
        for (int i = 0; i < positions.Count; i++)
        {
            Transform transform = Instantiate(dataBaseWallAndFLoar.Wall[wallId], positions[i], Quaternion.identity, _parentWall).transform;
            transform.localEulerAngles = rotate[i];
        }
        rotate = new List<Vector3>();
        positions = new List<Vector3>();
        foreach (var floar in _floars)
        {
            positions.Add(floar.transform.position);
            rotate.Add(floar.transform.localEulerAngles);
            Destroy(floar.gameObject);
        }
        for (int i = 0; i < positions.Count; i++)
        {
            Transform transform = Instantiate(dataBaseWallAndFLoar.Floar[floarId], positions[i], Quaternion.identity, _parentFloar).transform;
            transform.localEulerAngles = rotate[i];
        }
    }
}
