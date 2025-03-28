using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _shake;
    [SerializeField] bool _isShaking = false;
    private Vector3 pos;
    void Awake()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isShaking)
        {
            transform.position = pos + Random.insideUnitSphere * _shake;
        }

    }

    public void Shake()
    {
        if (!_isShaking)
        {
            _isShaking = true;
            StartCoroutine(StopShake());
        }

    }


    IEnumerator StopShake()
    {
        yield return new WaitForSeconds(3);

        _isShaking = false;
    }


}
