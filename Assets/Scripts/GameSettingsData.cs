using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameSettingsData", menuName = "Game Settings Data", order = 1)]
public class GameSettingsData : ScriptableObject
{
    [SerializeField]
    private int[] levels;

    public int[] Levels => levels;
}
