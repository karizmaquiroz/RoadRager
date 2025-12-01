using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq.Expressions;

public class SkillManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<SkillClass> currentPlayerSkills;
    void Start()
    {
        currentPlayerSkills = new List<SkillClass>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
