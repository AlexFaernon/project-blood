using System.Collections.Generic;

public static class TabletCircles
{
    public static CircleContent[] Circles { get; private set; } = new CircleContent[CirclesCount];
    //todo очистка при заливке
    public static bool ZeroUsed;
    public static bool AUsed;
    public static bool BUsed;
    public static bool AntiAUsed;
    public static bool AntiBUsed;
    public static bool AntiDUsed;
    private const int CirclesCount = 12;

    public static bool IsTabletDone => ZeroUsed && AUsed && BUsed && AntiAUsed && AntiBUsed && AntiDUsed;

    public static void ClearTablet()
    {
        Circles = new CircleContent[CirclesCount];
    }
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