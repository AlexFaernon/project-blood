using UnityEngine.VFX;

public static class GlobalStatistics
{
    public static int[,] allAttempts { get; private set; } = new int[4,2];
    public static int[,] successfulAttempts { get; private set; } = new int[4,2];

    public static void AddAttempt(BloodSample bloodSample, bool isSuccessful)
    {
        var bloodGroup = (int)bloodSample.BloodGroup;
        var rh = (int)bloodSample.Rh;

        allAttempts[bloodGroup, rh]++;
        SaveDataScript.SaveAllAttempts();

        if (isSuccessful)
        {
            successfulAttempts[bloodGroup, rh]++;
            SaveDataScript.SaveSuccessfulAttempts();
        }
    }

    public static void LoadAllAttempts(int[,] data)
    {
        allAttempts = data;
    }
    
    public static void LoadSuccessfulAttempts(int[,] data)
    {
        successfulAttempts = data;
    }
}
