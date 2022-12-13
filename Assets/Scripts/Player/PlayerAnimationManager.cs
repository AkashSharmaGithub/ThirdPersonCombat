using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(PlayerStateManager))]
public class PlayerAnimationManager : MonoBehaviour
{
    [field: SerializeField]
    public Animator PlayerAnimator;
    [SerializeField]
    private float _animationSmoothness=0.1f;

    public PlayerStateManager PlayerStateManager { get; private set; }
    public readonly string ForwardBackWardString = "ForwardAndBackwardMovement";
    public readonly string LeftRightString = "LeftRightMovement";

    private void Awake()
    {
        PlayerStateManager=GetComponent<PlayerStateManager>();
    }



    public void setFloatValue(string nameInAnimator,float value)
    {
      
      DOVirtual.Float(PlayerAnimator.GetFloat(nameInAnimator),value, _animationSmoothness, v =>PlayerAnimator.SetFloat(nameInAnimator, v));
    }


}
