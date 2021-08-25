using UnityEngine;
using UnityEngine.UI;

namespace SelectingTask
{
    public class RestartButton : MonoBehaviour
    {
        private void Awake()
        {
            var cellMaker = FindObjectOfType<CellMaker>();
            var resultChecker = cellMaker.gameObject.GetComponent<ResultChecker>();
            var taskEndPanel = resultChecker.TaskEndPanel;
            var button = GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                cellMaker.FillTaskQueue();
                taskEndPanel.gameObject.SetActive(false);
            });
        }
    }
}