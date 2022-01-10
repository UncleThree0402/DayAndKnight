using System;
using Controller;
using Interfaces.Observer;
using Interfaces.Stage;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StageProgressUI : MonoBehaviour, IStageListener
    {
        private int _clearedRegion = 0;
        private int _regionNumber = 0;
        
        private void Start()
        {
            FindObjectOfType<StageRegionController>().Attach(this);
        }

        private void SetText()
        {
            transform.GetChild(1).GetComponent<Text>().text =
                "Cleared Region " + _clearedRegion + " / " + _regionNumber;
        }

        public void UpdateStageInfo(IStage stage)
        {
            if (stage is StageRegionController stageRegionController)
            {
                _clearedRegion = stageRegionController.clearedNumber;
                _regionNumber = stageRegionController.regionNumber;
                SetText();
            }
        }
    }
}