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
            var transformEffectsSettings = _cellMaker.TransformEffectsSettings;
            if (selectOption == _rightOption)
            { 
                if (_cellMaker.IsLastLevel())
                {
                    _cellCleaner.RemoveAllCells();
                    taskEndPanel.gameObject.SetActive(true);

                    var taskEndPanelEndValue = transformEffectsSettings.TaskEndFadeInPanelEndValue;
                    var taskEndPanelDuration = transformEffectsSettings.TaskEndFadeInPanelDuration;
                    transformEffects.FadeInEffect(taskEndPanel, taskEndPanelEndValue, taskEndPanelDuration);
                    nextTaskButton.gameObject.SetActive(false);
                    return;
                }

                var rightSelectedOptionCountLoop = transformEffectsSettings.RightSelectedOptionCountLoop;
                var rightSelectedOptionScaleOffset = transformEffectsSettings.RightSelectedOptionScaleOffset;
                var rightSelectedOptionDuration = transformEffectsSettings.RightSelectedOptionDuration;
                transformEffects.RightSelectOptionEffect(selectOption, rightSelectedOptionCountLoop, 
                    rightSelectedOptionScaleOffset, rightSelectedOptionDuration);
                
                var options = GetComponentsInChildren<Option>();
                foreach (var option in options)
                    option.GetComponent<Image>().raycastTarget = false;
                
                nextTaskButton.interactable = true;
            }
            else
            {
                var wrongSelectedOptionCountLoop = transformEffectsSettings.RightSelectedOptionCountLoop;
                var wrongSelectedOptionScaleOffset = transformEffectsSettings.RightSelectedOptionScaleOffset;
                var wrongSelectedOptionDuration = transformEffectsSettings.RightSelectedOptionDuration;
                transformEffects.WrongSelectOptionEffect(selectOption, wrongSelectedOptionCountLoop, 
                    wrongSelectedOptionScaleOffset, wrongSelectedOptionDuration);
            }
        }

        public void SetRightCell(Option option)
        {
            _rightOption = option;
        }
    }
}