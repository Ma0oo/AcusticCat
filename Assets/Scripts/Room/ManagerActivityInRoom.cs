using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerActivityInRoom : MonoBehaviour
{
    private int _indexCamera = 0;
    private CameraPoint[] _cameras;
    private StressItem[] _stressItem;

    public int CountCamerasInRoom => _cameras.Length;
    public int IndexActiveCamera => _indexCamera + 1;

    private void Awake()
    {
        _cameras = GetComponentsInChildren<CameraPoint>();
        _stressItem = GetComponentsInChildren<StressItem>();
        foreach (var item in _stressItem)
        {
            item.gameObject.SetActive(false);
        }
    }
    public void TurnOnRandomStressItem()
    {
        _stressItem[Random.Range(0, _stressItem.Length)].gameObject.SetActive(true);
    }
    public void NextCamera(Camera mainCamera)
    {
        _cameras[_indexCamera].DeactiveCamera();
        ChangeIndex(Opeation.add);
        _cameras[_indexCamera].ActiveCamera(mainCamera);
    }
    public void PrevCamera(Camera mainCamera)
    {
        _cameras[_indexCamera].DeactiveCamera();
        ChangeIndex(Opeation.minus);
        _cameras[_indexCamera].ActiveCamera(mainCamera);
    }

    private void ChangeIndex(Opeation opeation)
    {
        if (opeation == Opeation.add)
            _indexCamera++;
        else if(opeation == Opeation.minus)
            _indexCamera--;
        if (_indexCamera < 0)
            _indexCamera = _cameras.Length - 1;
        if (_indexCamera >= _cameras.Length)
            _indexCamera = 0;
    }
    private enum Opeation
    {
        add, minus
    }
}
