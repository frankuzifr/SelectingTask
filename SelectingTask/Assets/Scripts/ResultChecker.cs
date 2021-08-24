using UnityEngine;

namespace SelectingTask
{
    public class ResultChecker : MonoBehaviour
    {
        private Option _rightOption;
        private CellMaker _cellMaker;

        private void Awake()
        {
            _cellMaker = GetComponent<CellMaker>();
        }

        public void CheckResult(Option option)
        {
            if (option == _rightOption)
            {
                Debug.Log("Molodec");
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