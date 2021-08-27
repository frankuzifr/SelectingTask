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
            var nextTaskButton = resultChecker.NextTaskButton;
            var button = GetComponent<Button>();
            var transformEffects = new TransformEffects();
            var transformEffectsSettings = cellMaker.TransformEffectsSettings;
            var screenLoadingFadeInMaxValue = transformEffectsSettings.ScreenLoadingFadeInMaxValue;
            var screenLoadingFadeInEffectDuration = transformEffectsSettings.ScreenLoadingFadeInEffectDuration;
            button.onClick.AddListener(() =>
            {
                transformEffects.FadeInEffect(cellMaker.ScreenLoading, screenLoadingFadeInMaxValue, screenLoadingFadeInEffectDuration);
                cellMaker.FillTaskQueue();
                taskEndPanel.gameObject.SetActive(false);
                nextTaskButton.gameObject.SetActive(true);
            });
        }
    }
}