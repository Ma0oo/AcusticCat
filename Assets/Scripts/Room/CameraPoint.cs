using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    [SerializeField] private float _fov = 75;
    [SerializeField] private AudioClip _soundSwitch;
    [SerializeField] private AudioSource _source;

    private Camera _testCamera;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        DestroyTestCamera();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ActiveCamera(Camera mainCamera)
    {
        SetMainCam(mainCamera);
    }
    public void DeactiveCamera()
    {
        _meshRenderer.enabled = true;
    }
    private void SetMainCam(Camera camera)
    {
        camera.transform.SetParent(transform);
        camera.transform.localPosition = Vector3.zero;
        camera.transform.localEulerAngles = new Vector3(0, -90, 0);
        camera.fieldOfView = _fov;
        _meshRenderer.enabled = false;
        PlaySoundSwitch();
    }
    private void PlaySoundSwitch() 
    {
        _source.clip = _soundSwitch;
        _source.Play();
    }

    private void DestroyTestCamera()
    {
        if (_testCamera != null)
            if(_testCamera.gameObject != null)
                Destroy(_testCamera.gameObject);
    }
    public void SpawnTestCamera()
    {
        if (_testCamera == null)
        {
            GameObject gm = Instantiate(new GameObject(), transform);
            gm.transform.position = transform.position;
            gm.transform.rotation = transform.rotation;
            gm.transform.localEulerAngles = new Vector3(0, -90, 0);
            gm.transform.localPosition = new Vector3(0, -0.7f, 0);
            _testCamera = gm.AddComponent<Camera>();
            ChangeFov();
            gm.name = "Testovay Camera, delete auto";
            _testCamera.farClipPlane = 45;
        }
    }
    public void ChangeFov()
    {
        if (_testCamera != null)
            _testCamera.fieldOfView = _fov;
    }

}
