using System.Collections.Generic;
using UnityEngine;

namespace SelectingTask
{
    [CreateAssetMenu]
    public class LevelComplexity : ScriptableObject
    {
        [SerializeField] private List<TaskSettings> tasksSettings;

        public List<TaskSettings> TasksSettings => tasksSettings;
    }
}