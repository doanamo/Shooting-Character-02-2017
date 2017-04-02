using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CharacterHashes
{
    public static readonly int Moving = Animator.StringToHash("Moving");
    public static readonly int Running = Animator.StringToHash("Running");
    public static readonly int MovementX = Animator.StringToHash("Movement X");
    public static readonly int MovementZ = Animator.StringToHash("Movement Z");
    public static readonly int StrafingX = Animator.StringToHash("Strafing X");
    public static readonly int StrafingZ = Animator.StringToHash("Strafing Z");

    public static readonly int Aiming = Animator.StringToHash("Aiming");
    public static readonly int AimingX = Animator.StringToHash("Aiming X");
    public static readonly int AimingZ = Animator.StringToHash("Aiming Z");
    public static readonly int AimingWeight = Animator.StringToHash("Aiming Weight");

    public static readonly int LeftHandWeight = Animator.StringToHash("Left Hand Weight");
}
