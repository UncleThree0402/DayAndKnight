using System;
using Interfaces.Observer;
using Stats;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class Bar : MonoBehaviour , IObserver
    {
        [SerializeField] private BasicStats _basicStats;
        

        private Color _color;
            
        private RectTransform _rectTransform;
        
        protected float _target;
        
        private float _current;

        protected float _maxValue;

        protected float _genRate = 10f;
        
        
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _color = transform.GetChild(0).GetChild(1).GetComponent<Image>().color;
        }

        private void Start()
        {
            _basicStats.Attach(this);
        }

        private void Update()
        {
            UpdateBoarder(_maxValue);
            UpdateValue(ref _current, _target);
        }

        private void UpdateBoarder(float max)
        {
            if (_maxValue > 100f)
                _rectTransform.localScale = new Vector3(_maxValue / 100f,1f,1f);
            else
                _rectTransform.localScale = new Vector3(1f,1f,1f);
        }

        private void UpdateValue(ref float current, float target)
        {
            if (current < target)
            {
                transform.GetChild(0).GetChild(1).GetComponent<Image>().fillAmount = Mathf.Clamp(transform.GetChild(0).GetChild(1).GetComponent<Image>().fillAmount + _genRate * Time.deltaTime, 0 , target);
                UpdateColor(current);
            }else if (current > target)
            {
                transform.GetChild(0).GetChild(1).GetComponent<Image>().fillAmount = Mathf.Clamp(transform.GetChild(0).GetChild(1).GetComponent<Image>().fillAmount - _genRate * Time.deltaTime, target , 1);
            }
            current = transform.GetChild(0).GetChild(1).GetComponent<Image>().fillAmount;
        }

        private void UpdateColor(float current)
        {
            if (current < 0.3f)
            {
                if ((int)(current * 100f) % 2 == 0)
                {
                    transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.white;
                }
                else
                {
                    transform.GetChild(0).GetChild(1).GetComponent<Image>().color = _color;
                }
            }
            else
            {
                transform.GetChild(0).GetChild(1).GetComponent<Image>().color = _color;
            }
        }

        public abstract void UpdateData(IObservable observable);
    }
}