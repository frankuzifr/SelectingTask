using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SelectingTask
{
    public class CellMaker : MonoBehaviour
    {
        [SerializeField] private List<LevelComplexity> levelsComplexity;
        
        [Header("Environment")]
        [SerializeField] private Cell cellPrefab;
        [SerializeField] private TMP_Text taskLabel;
        [SerializeField] private Image screenLoading;

        [Header("Effects settings")] 
        [SerializeField] private TransformEffectsSettings transformEffectsSettings;
        
        [Header("Other settings")]
        [SerializeField] private bool canInstantiateRepeatedRightOption;
        
        public TMP_Text TaskLabel => taskLabel;
        public Image ScreenLoading => screenLoading;
        public TransformEffectsSettings TransformEffectsSettings => transformEffectsSettings;

        private Queue<TaskSettings> _tasksQueue;
        private List<Option> _addedRightOptions;
        private CellCleaner _cellCleaner;
        private ResultChecker _resultChecker;

        private int _currentLevel;
        
        private void Awake()
        {
            _tasksQueue = new Queue<TaskSettings>();
            _addedRightOptions = new List<Option>();
            _cellCleaner = GetComponent<CellCleaner>();
            _resultChecker = GetComponent<ResultChecker>();
            _cellCleaner.SetCellMaker(this);
            screenLoading.gameObject.SetActive(false);
            FillTaskQueue();
        }

        public void FillTaskQueue()
        {
            foreach (var levelComplexity in levelsComplexity)
            {
                var taskSettings = levelComplexity.TasksSettings;
                var random = 0;

                if (canInstantiateRepeatedRightOption)
                {
                    random = Random.Range(0, taskSettings.Count);
                    _tasksQueue.Enqueue(taskSettings[random]);
                    continue;
                }
                
                do
                {
                    random = Random.Range(0, taskSettings.Count);
                } while (_addedRightOptions.Contains(taskSettings[random].RightOption));
                
                _tasksQueue.Enqueue(taskSettings[random]);
                _addedRightOptions.Add(taskSettings[random].RightOption);
            }
            
            _addedRightOptions.Clear();
            _currentLevel = 0;
            InstantiateLevel(true);
        }

        public void InstantiateLevel(bool isStart = false)
        {
            _cellCleaner.RemoveAllCells();
            var taskQueue = _tasksQueue;
            var taskSettings = taskQueue.Dequeue();
            var taskText = taskSettings.TaskDescription;
            taskLabel.text = taskText;
            var cellOptions = taskSettings.CellsOptions;
            var instantiatedCells = new List<Cell>();

            foreach (var cellOption in cellOptions)
            {
                var instantiatedCell = Instantiate(cellPrefab, transform);
                instantiatedCells.Add(instantiatedCell);
                var instantiatedCellTransform = instantiatedCell.transform;
                var instantiatedOption = Instantiate(cellOption, instantiatedCellTransform);
                
                if (cellOption == taskSettings.RightOption)
                    _resultChecker.SetRightCell(instantiatedOption);
            }

            _currentLevel++;
            
            if (!isStart)
                return;
            
            var transformEffects = new TransformEffects();
            var screenLoadingFadeOutEffectDuration = transformEffectsSettings.ScreenLoadingFadeOutEffectDuration;
            transformEffects.FadeOutEffect(screenLoading, screenLoadingFadeOutEffectDuration);
            
            var textLabelFadeInEffectEndValue = transformEffectsSettings.TextLabelFadeInEffectEndValue;
            var textLabelFadeInEffectDuration = transformEffectsSettings.TextLabelFadeInEffectDuration;
            transformEffects.FadeInEffect(taskLabel, textLabelFadeInEffectEndValue, textLabelFadeInEffectDuration);
            
            var maxBounceValue = transformEffectsSettings.MaxBounceValue;
            var bounceDuration = transformEffectsSettings.BounceDuration;
            transformEffects.BounceEffect(instantiatedCells.ToArray(), maxBounceValue, bounceDuration);
        }

        public bool IsLastLevel()
        {
            return _currentLevel == levelsComplexity.Count;
        }
    }
}