using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementLibrary : MonoBehaviour {

    public Achievement[] achievement_array;

    public Dictionary<string, Achievement> achievDictionary = new Dictionary<string, Achievement>();

    private void Start()
    {
        foreach (Achievement item in achievement_array)
        {
            achievDictionary.Add(item.name,item);
        }
    }

    public Achievement GetAchievementFromName(string name)
    {
        if (achievDictionary.ContainsKey(name))
        {
            return achievDictionary[name];
        }

        return null;
    }

    [System.Serializable]
    public class Achievement
    {
        //public int id;
        public string name;
        public int currentProgress;
        public int targetProgress;
        public string description;
        public bool isComplete;
    }
}
