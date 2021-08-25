using UnityEngine;
using UnityEngine.UI;

namespace SelectingTask
{
    public class ResultChecker : MonoBehaviour
    {
        [SerializeField] private Image taskEndPanel;
        
        public Image TaskEndPanel => taskEndPanel;

        private Option _rightOption;
        private CellMaker _cellMaker;
        private CellCleaner _cellCleaner;
        

        private void Awake()
        {
            taskEndPanel.gameObject.SetActive(false);
            _cellMaker = GetComponent<CellMaker>();
            _cellCleaner = GetComponent<CellCleaner>();
        }

        public void CheckResult(Option option)
        {
            if (option == _rightOption)
            {
                if (_cellMaker.IsLastLevel())
                {
                    _cellCleaner.RemoveAllCells();
                    taskEndPanel.gameObject.SetActive(true);
                    return;
                }
                _cellMaker.InstantiateLevel();
            }
            else
                Debug.Log("Loh");
        }

        public void SetRightCell(Option option)
        {
            _rightOption = option;
        }
    }
}