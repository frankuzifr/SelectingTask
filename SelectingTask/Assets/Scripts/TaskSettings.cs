using System.Collections.Generic;
using UnityEngine;

namespace SelectingTask
{
    [CreateAssetMenu]
    public class TaskSettings : ScriptableObject
    {
        [SerializeField] private string taskDescription;
        [SerializeField] private List<Option> cellsOptions;
        [SerializeField] private Option rightOption;

        public string TaskDescription => taskDescription;
        public List<Option> CellsOptions => cellsOptions;
        public Option RightOption => rightOption;
    }
}