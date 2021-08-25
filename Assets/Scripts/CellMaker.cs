using System.Collections.Generic;
using UnityEngine;

namespace SelectingTask
{
    public class CellMaker : MonoBehaviour
    {
        [SerializeField] private List<LevelComplexity> levelsComplexity;
        [SerializeField] private Cell cellPrefab;
        [SerializeField] private bool canInstantiateRepeatedRightOption;

        private Queue<TaskSettings> _tasksQueue;
        private List<Option> _instantiateOptions;
        private CellCleaner _cellCleaner;
        private ResultChecker _resultChecker;

        private int _currentLevel;
        
        private void Awake()
        {
            _tasksQueue = new Queue<TaskSettings>();
            _instantiateOptions = new List<Option>();
            _cellCleaner = GetComponent<CellCleaner>();
            _resultChecker = GetComponent<ResultChecker>();
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
                } while (_instantiateOptions.Contains(taskSettings[random].RightOption));
                
                _tasksQueue.Enqueue(taskSettings[random]);
                _instantiateOptions.Add(taskSettings[random].RightOption);
            }
            
            _instantiateOptions.Clear();
            _currentLevel = 0;
            InstantiateLevel();
        }

        public void InstantiateLevel()
        {
            _cellCleaner.RemoveAllCells();
            var taskQueue = _tasksQueue;
            var taskSettings = taskQueue.Dequeue();
            var cellOptions = taskSettings.CellsOptions;
            
            foreach (var cellOption in cellOptions)
            {
                var instantiatedCell = Instantiate(cellPrefab, transform);
                var instantiatedCellTransform = instantiatedCell.transform;
                var instantiatedOption = Instantiate(cellOption, instantiatedCellTransform);
                
                if (cellOption == taskSettings.RightOption)
                    _resultChecker.SetRightCell(instantiatedOption);
            }

            _currentLevel++;
        }

        public bool IsLastLevel()
        {
            return _currentLevel == levelsComplexity.Count;
        }
    }
}