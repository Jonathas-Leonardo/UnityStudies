using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour {

    public static AchievementManager instance;

    public AchievementLibrary achievementLibrary;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);

        achievementLibrary = GetComponent<AchievementLibrary>();
    }

    public void CheckAchievement(string name, int value)
    {
        AchievementLibrary.Achievement achieve = achievementLibrary.GetAchievementFromName(name);

        achieve.currentProgress = value;

        if (achieve.currentProgress >= achieve.targetProgress)
        {
            achieve.isComplete = true;
        }
    }
}
