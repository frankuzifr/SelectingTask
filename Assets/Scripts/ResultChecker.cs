using UnityEngine;
using UnityEngine.UI;

namespace SelectingTask
{
    public class ResultChecker : MonoBehaviour
    {
        [SerializeField] private Image taskEndPanel;
        [SerializeField] private Button nextTaskButton;
        
        public Image TaskEndPanel => taskEndPanel;
        public Button NextTaskButton => nextTaskButton;

        private Option _rightOption;
        private CellMaker _cellMaker;
        private CellCleaner _cellCleaner;
        

        private void Awake()
        {
            taskEndPanel.gameObject.SetActive(false);
            _cellMaker = GetComponent<CellMaker>();
            _cellCleaner = GetComponent<CellCleaner>();
        }

        public void CheckResult(Option selectOption)
        {
            var transformEffects = new TransformEffects();
            if (selectOption == _rightOption)
            { 
                if (_cellMaker.IsLastLevel())
                {
                    _cellCleaner.RemoveAllCells();
                    taskEndPanel.gameObject.SetActive(true);
                    transformEffects.FadeInEffect(taskEndPanel, 0.5f);
                    nextTaskButton.gameObject.SetActive(false);
                    return;
                }
                
                transformEffects.RightSelectOptionEffect(selectOption);
                var options = GetComponentsInChildren<Option>();
                foreach (var option in options)
                    option.GetComponent<Image>().raycastTarget = false;
                
                nextTaskButton.interactable = true;
            }
            else
            {
                transformEffects.WrongSelectOptionEffect(selectOption);
            }
        }

        public void SetRightCell(Option option)
        {
            _rightOption = option;
        }
    }
}