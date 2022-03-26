using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public event Action OnPlayerHitObstacle;

    [SerializeField] private float _startSpeed;
    [SerializeField] private float _addSpeedPerSecond;
    [SerializeField] private float _strafeForce;
    [SerializeField] private Timer _timer;

    private float _speed;

    private void Awake()
    {
        _speed = _startSpeed;
        _timer.OnTime += AddSpeed;
        OnPlayerHitObstacle += StopPlayer;
    }

    void Start()
    {
        _timer.Initialise(1);
    }

    private void FixedUpdate()
    {
        MoveStraight();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Vector3 toTarget = (other.gameObject.transform.position - transform.position).normalized;

            if (Vector3.Dot(toTarget, gameObject.transform.forward) > 0)
            {
                OnPlayerHitObstacle?.Invoke();
            }
        }
    }

    public void MoveStraight()
    {
        transform.Translate(transform.forward * _speed, Space.World);
    }

    public void Strafe(float force)
    {
        transform.Translate(transform.right * force, Space.World);
    }

    private void AddSpeed()
    {
        _speed += _addSpeedPerSecond;
    }

    private void StopPlayer()
    {
        _timer.StopTimer();
        _speed = 0;
    }
}
