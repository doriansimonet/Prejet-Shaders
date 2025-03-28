using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    private GameObject _ballPrefab;
    private GameObject _ball;
    [SerializeField]
    private Transform _ballParent;
    [SerializeField]
    private Transform _TransformDummy;
    private float _appear;
    bool _stop = true;
    bool _move = false;
    // Start is called before the first frame update
    void Start()
    {
        //_renderer = GetComponent<MeshRenderer>();
        _appear = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        if(_ball != null) {
            if (!_stop)
            {
                _appear += 0.1f;
                _ball.GetComponent<MeshRenderer>().material.SetFloat("_appear", _appear);
            }
            if (_appear >= 15f)
            {
                _stop = false;
                _move = true;
            }
            if (_move)
            {
                _ball.transform.LookAt(_TransformDummy.localPosition);
                _ball.GetComponent<Rigidbody>().velocity += _ball.transform.forward;
            }
        }
        
    }

    public void Begin()
    {
        _ball = Instantiate(_ballPrefab,_ballParent);
        _appear = 12f;
        _stop = false;
        _move = false;
    }
}
