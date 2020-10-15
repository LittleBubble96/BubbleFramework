using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : DataModelBase
{
    public string Name;
    public int Hp;
    public float Attack;

    public MonsterData()
    {
        
    }

    public MonsterData(string name,int hp,float attack)
    {
        this.Name = name;
        this.Hp = hp;
        this.Attack = attack;
    }

    public override string ToString()
    {
        return $"this monster is {Name},hp is {Hp},attack is {Attack}";
    }
}
