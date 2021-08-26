using UnityEngine;
using UnityEngine.UI;

namespace SelectingTask
{
    public class NextTaskButton : MonoBehaviour
    {
        private void Awake()
        {
            var cellMaker = FindObjectOfType<CellMaker>();
            var button = GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                cellMaker.InstantiateLevel();
                button.interactable = false;
            });
        }
    }
}