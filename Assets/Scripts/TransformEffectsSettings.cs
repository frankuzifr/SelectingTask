using UnityEngine;

namespace SelectingTask
{
    [CreateAssetMenu]
    public class TransformEffectsSettings : ScriptableObject
    {
        [Header("Cell effects")]
        [SerializeField] private float maxBounceValue = 1.5f;
        [SerializeField] private float bounceDuration = 0.1f;
        
        [Header("Text label effects")]
        [SerializeField] private float textLabelFadeInEffectEndValue = 1f;
        [SerializeField] private float textLabelFadeInEffectDuration = 0.1f;
        
        [Header("Screen loading effects")]
        [SerializeField] private float screenLoadingFadeOutEffectDuration = 0.1f;
        [SerializeField] private float screenLoadingFadeInMaxValue = 1f;
        [SerializeField] private float screenLoadingFadeInEffectDuration = 0.1f;

        [Header("Task end panel effects")] 
        [SerializeField] private float taskEndFadeInPanelEndValue = 0.5f;
        [SerializeField] private float taskEndFadeInPanelDuration = 0.1f;
        
        [Header("Right selected option effects")]
        [SerializeField] private int rightSelectedOptionCountLoop = 2; 
        [SerializeField] private float rightSelectedOptionScaleOffset = 0.1f; 
        [SerializeField] private float rightSelectedOptionDuration = 0.1f;
        
        [Header("Wrong selected option effects")]
        [SerializeField] private int wrongSelectedOptionCountLoop = 2; 
        [SerializeField] private float wrongSelectedOptionMoveXOffset = 0.1f; 
        [SerializeField] private float wrongSelectedOptionDuration = 0.1f; 
        
        public float MaxBounceValue => maxBounceValue;
        public float BounceDuration => bounceDuration;
        public float TextLabelFadeInEffectEndValue => textLabelFadeInEffectEndValue;
        public float TextLabelFadeInEffectDuration => textLabelFadeInEffectDuration;
        public float ScreenLoadingFadeOutEffectDuration => screenLoadingFadeOutEffectDuration;
        public float ScreenLoadingFadeInMaxValue => screenLoadingFadeInMaxValue;
        public float ScreenLoadingFadeInEffectDuration => screenLoadingFadeInEffectDuration;
        public float TaskEndFadeInPanelEndValue => taskEndFadeInPanelEndValue;
        public float TaskEndFadeInPanelDuration => taskEndFadeInPanelDuration;
        public int RightSelectedOptionCountLoop => rightSelectedOptionCountLoop;
        public float RightSelectedOptionScaleOffset => rightSelectedOptionScaleOffset;
        public float RightSelectedOptionDuration => rightSelectedOptionDuration;
        public int WrongSelectedOptionCountLoop => wrongSelectedOptionCountLoop;
        public float WrongSelectedOptionMoveXOffset => wrongSelectedOptionMoveXOffset;
        public float WrongSelectedOptionDuration => wrongSelectedOptionDuration;
    }
}