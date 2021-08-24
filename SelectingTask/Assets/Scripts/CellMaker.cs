using System.Collections.Generic;
using UnityEngine;

namespace SelectingTask
{
    public class CellMaker : MonoBehaviour
    {
        [SerializeField] private List<LevelComplexity> levelsComplexity;
        [SerializeField] private Cell cell;

        private Queue<TaskSettings> _tasksQueue;
        private CellCleaner _cellCleaner;
        private ResultChecker _resultChecker;

        private int _currentLevel;
        
        private void Awake()
        {
            _tasksQueue = new Queue<TaskSettings>();
            _cellCleaner = GetComponent<CellCleaner>();
            _resultChecker = GetComponent<ResultChecker>();
            FillTaskQueue();
            InstantiateLevel();
        }

        public void FillTaskQueue()
        {
            foreach (var levelComplexity in levelsComplexity)
            {
                var taskSettings = levelComplexity.TasksSettings;
                var random = Random.Range(0, taskSettings.Count);
                _tasksQueue.Enqueue(taskSettings[random]);
            }
        }

        public void InstantiateLevel()
        {
            if (_currentLevel == levelsComplexity.Count)
            {
                Debug.Log("Vse!!!");
                return;
            }
            
            _cellCleaner.RemoveAllCells();
            var taskQueue = _tasksQueue;
            var taskSettings = taskQueue.Dequeue();
            var cellOptions = taskSettings.CellsOptions;
            
            foreach (var cellOption in cellOptions)
            {
                var instantiatedCell = Instantiate(cell, transform);
                var instantiatedCellTransform = instantiatedCell.transform;
                var instantiatedOption = Instantiate(cellOption, instantiatedCellTransform);
                
                if (cellOption == taskSettings.RightOption)
                    _resultChecker.SetRightCell(instantiatedOption);
            }

            _currentLevel++;
        }
    }
}