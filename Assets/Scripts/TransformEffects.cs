using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace SelectingTask
{
    public class TransformEffects
    {
        public void FadeInEffect(Graphic graphic, float endValue = 1f, float duration = 0.1f)
        {
            var color = graphic.color;
            graphic.color = new Color(color.r, color.g, color.b, 0);
            graphic.DOFade(endValue, duration);
        }

        public void FadeOutEffect(Graphic graphic, float duration = 0.1f)
        {
            graphic.DOFade(0, duration);
        }

        public void BounceEffect(Cell[] cells, float maxBounceValue = 1.5f, float duration = 0.1f)
        {
            foreach (var cell in cells)
            {
                cell.transform.localScale = Vector3.zero;
                DOTween.Sequence()
                    .Append(cell.transform.DOScale(maxBounceValue, duration))
                    .Append(cell.transform.DOScale(1.0f, duration));
            }
        }

        public void WrongSelectOptionEffect(Option option)
        {
            var optionPosition = option.transform.position;

            DOTween.Sequence().SetLoops(2)
                .AppendCallback(() => option.GetComponent<Image>().raycastTarget = false)
                .Append(option.transform.DOMoveX(optionPosition.x - 1f, 0.1f))
                .Append(option.transform.DOMoveX(optionPosition.x + 1f, 0.1f))
                .Append(option.transform.DOMoveX(optionPosition.x, 0.1f))
                .AppendCallback(() => option.GetComponent<Image>().raycastTarget = true);
        }
        
        public void RightSelectOptionEffect(Option option)
        {
            var optionScale = option.transform.localScale;

            DOTween.Sequence().SetLoops(2)
                .Append(option.transform.DOScale(optionScale.x + 0.1f, 0.1f))
                .Append(option.transform.DOScale(optionScale.x - 0.1f, 0.1f))
                .Append(option.transform.DOScale(optionScale.x, 0.1f));

            var cellParticleSystem = option.GetComponentInParent<ParticleSystem>();
            cellParticleSystem.Play();
        }
    }
}