using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int _LockSkillLevel;
    public TextMeshProUGUI _UISkillLevel;
    public int _numberOfPicks;
    public TextMeshProUGUI _UINumberOfPicks;
    public int _HackingSkillLevel;
    public TextMeshProUGUI _HackingLevelUI;

    void Start()
    {
        _UISkillLevel.text = "Lockpicking Skill Level: " + _LockSkillLevel.ToString();
        _UINumberOfPicks.text = "Number of Picks: " + _numberOfPicks;
        _HackingLevelUI.text = "Hacking Skill Level: " + _HackingSkillLevel.ToString();

    }
    public void changeSkillLevel()
    {
        _LockSkillLevel++;
        if(_LockSkillLevel > 10)
        {
            _LockSkillLevel = 0;
        }
        _UISkillLevel.text = "Lockpicking Skill Level: " + _LockSkillLevel.ToString();
    }

    public void changeHackingSkillLevel()
    {
        _HackingSkillLevel++;
        if (_HackingSkillLevel > 10)
        {
            _HackingSkillLevel = 0;
        }
        _HackingLevelUI.text = "Hacking Skill Level: " + _HackingSkillLevel.ToString();
    }
}
