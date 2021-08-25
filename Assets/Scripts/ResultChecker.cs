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
        

        private void Awake()
        {
            taskEndPanel.gameObject.SetActive(false);
            _cellMaker = GetComponent<CellMaker>();
        }

        public void CheckResult(Option option)
        {
            if (option == _rightOption)
            {
                Debug.Log("Molodec");
                if (_cellMaker.IsLastLevel())
                {
                    taskEndPanel.gameObject.SetActive(true);
                    Debug.Log("Vse!!!");
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