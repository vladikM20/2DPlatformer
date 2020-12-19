using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Player _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _player.Speed);
        _animator.SetFloat("JumpDirection", _player.JumpDirection);
        _animator.SetBool("IsGrounded", _player.IsGrounded);
    }
}
