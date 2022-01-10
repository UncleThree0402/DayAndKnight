using System;
using System.Collections.Generic;
using Interfaces.Observer;
using Interfaces.Stage;
using UI;
using UnityEngine;

namespace Controller
{
    public class StageRegionController : MonoBehaviour, IStage
    {
        private List<IRegion> _regions;
        private List<IStageListener> _stageListeners;
        public int regionNumber = 0;
        public int clearedNumber = 0;

        private void Awake()
        {
            _regions = new List<IRegion>();
            _stageListeners = new List<IStageListener>();
        }
        
        

        public void AddRegion(IRegion region)
        {
            _regions.Add(region);
            regionNumber++;
            Notify();
        }

        public void FinishRegion(IRegion region)
        {
            _regions.Remove(region);
            clearedNumber++;
            Notify();
            if (regionNumber == clearedNumber)
            {
                FindObjectOfType<UIController>().Win();
            }
        }

        public void Attach(IStageListener stageListener)
        { 
            _stageListeners.Add(stageListener);
            stageListener.UpdateStageInfo(this);
        }

        public void Detach(IStageListener stageListener)
        {
            _stageListeners.Remove(stageListener);
        }

        public void Notify()
        {
            foreach (var VARIABLE in _stageListeners)
            {
                VARIABLE.UpdateStageInfo(this);
            }
        }
    }
}