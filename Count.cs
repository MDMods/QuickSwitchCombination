using System;
using MelonLoader;
using UnityEngine;

namespace QuickSwitchCombination;

[RegisterTypeInIl2Cpp]
internal class Count : MonoBehaviour
{
    public int count;

    public Count(IntPtr intPtr) : base(intPtr)
    {
    }
}