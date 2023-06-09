using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Telemetry;
using Telemetry.Events;
using System;

namespace Unity.FPS.Game
{
    public class TrackerManager : MonoBehaviour
    {

        public static TrackerManager Instance = null;
        Tracker tracker;


        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
                setUpTracker();
            }

            else
            {
                Destroy(this.gameObject);
            }
        }

    public Telemetry.Tracker getTracker()
    {
        return tracker;
    }

    private void setUpTracker()
    {
        string dataPath = Application.persistentDataPath;
        tracker = Telemetry.Tracker.Instance("AudiometryTest", Telemetry.Persistance.PersistanceType.File, Telemetry.Serialization.SerializeType.JSON, dataPath + "AudiometryTelemetry");
        tracker.init();

    }

    private void OnApplicationQuit()
    {
        tracker.end();
    }

    private void Update()
    {
        if (tracker != null)
            tracker.update(Time.deltaTime);
    }

    }
}