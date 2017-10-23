using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour {

    private static AnalyticsManager _instance;
    public static AnalyticsManager Instance
    {
        get { return _instance ?? (_instance = new GameObject("AnalyticsManager").AddComponent<AnalyticsManager>()); }
    }

    public void SendCustomEvent(string p_event, Dictionary<string,object> p_dictionary)
    {
        Analytics.CustomEvent(p_event, p_dictionary);
    }
}
