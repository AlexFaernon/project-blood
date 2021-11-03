using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TabletCircles
{
    public static readonly CircleContent[] Circles = new CircleContent[12];
    
}

public class CircleContent
{
    public bool ContainsPlasma;
    public bool ContainsBloodCells;
    public HashSet<Erythrocyte> Erythrocytes = new HashSet<Erythrocyte>();
    public HashSet<Antigen> Antigens = new HashSet<Antigen>();
}

public enum Erythrocyte
{
    Zero,
    A,
    B
}

public enum Antigen
{
    AntiA,
    AntiB,
    AntiD
}