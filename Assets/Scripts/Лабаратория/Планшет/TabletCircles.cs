using System.Collections.Generic;

public static class TabletCircles
{
    public static readonly CircleContent[] Circles = new CircleContent[12];
    //todo очистка при заливке
    public static bool ZeroUsed;
    public static bool AUsed;
    public static bool BUsed;
    public static bool AntiAUsed;
    public static bool AntiBUsed;
    public static bool AntiDUsed;

    public static bool IsTabletDone => ZeroUsed && AUsed && BUsed && AntiAUsed && AntiBUsed && AntiDUsed;
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