using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using DG.Tweening;

public class Cargo : MonoBehaviour
{
    private SplineComputer _splineComputer;
    private SplineFollower _splineFollower;

    private void Start()
    {
        _splineFollower = GetComponent<SplineFollower>();
        _splineComputer = GetComponent<SplineFollower>().spline;
    }

    public void MoveToFinalPoint()
    {
        _splineFollower.follow = false;
        _splineFollower.followSpeed = 5f;
        _splineFollower.follow = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cargo"))
        {
            _splineFollower.follow = false;
            StartCoroutine(TurnBack(other.gameObject));
        }
    }

    private IEnumerator TurnBack(GameObject other)
    {
        transform.DOShakeRotation(.3f, 100, 1, 1);
        other.transform.DOShakeRotation(.3f, 100, 1, 1);
        
        yield return new WaitForSeconds(.5f);
        
        _splineFollower.followSpeed = -5f;
        _splineFollower.follow = true;

    }
}
