using UnityEngine;
using UnityEngine.EventSystems;

namespace SelectingTask
{
    public class Option : MonoBehaviour, IPointerClickHandler
    {
        private ResultChecker _resultChecker;
        
        private void Awake()
        {
            _resultChecker = GetComponentInParent<ResultChecker>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _resultChecker.CheckResult(this);
        }
    }
}