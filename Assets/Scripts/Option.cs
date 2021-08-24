using UnityEngine;
using UnityEngine.EventSystems;

namespace SelectingTask
{
    public class Option : MonoBehaviour, IPointerClickHandler
    {
        private CellMaker _cellMaker;
        private ResultChecker _resultChecker;
        
        private void Awake()
        {
            _cellMaker = GetComponentInParent<CellMaker>();
            _resultChecker = GetComponentInParent<ResultChecker>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //_cellMaker.InstantiateTask();
            _resultChecker.CheckResult(this);
        }
    }
}