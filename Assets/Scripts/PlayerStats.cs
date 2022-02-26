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

    void Start()
    {
        _UISkillLevel.text = "Lockpicking Skill Level: " + _LockSkillLevel.ToString();
        _UINumberOfPicks.text = "Number of Picks: " + _numberOfPicks;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
