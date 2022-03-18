using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _addSpeedPerSecond;
    [SerializeField] private float _strafeForce;

    private float _speed;

    void Start()
    {
        _speed = _startSpeed;
    }

    void FixedUpdate()
    {
        MoveStraight();
    }

    public void MoveStraight()
    {
        transform.Translate(transform.forward * _speed, Space.World);
    }

    public void Strafe(float force)
    {
        transform.Translate(transform.right * force, Space.World);
    }

    public void StrafeRight()
    {
        transform.Translate(transform.right * _strafeForce, Space.World);
    }

    public void StrafeLeft()
    {
        transform.Translate(-transform.right * _strafeForce, Space.World);
    }

}
