using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankDate
{
    public string name;
    public int score;
    public float time;
    public RankDate()
    {

    }
    public RankDate(string name, int score, float time)
    {
        this.name = name;
        this.score = score;
        this.time = time;
    }
}

public class RankList
{
    public List<RankDate> list;
}