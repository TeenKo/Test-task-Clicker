using Core.Extension;
using Entitas;
using UnityEngine;

namespace Core.Input
{
    public enum AxisOptions
    {
        Both,
        Horizontal,
        Vertical
    }

    public sealed class Joystick : MonoBehAdvGame,
        IJoystickHandleAnchoredPositionListener, IJoystickBackgroundAnchoredPositionListener,
        IJoystickHandleSetActiveListener, IJoystickBackgroundSetActiveListener, IJoystickOffsetAngleListener
    {
        [SerializeField] [Min(float.Epsilon)] private float handleRange = 1;
        [SerializeField] [Range(0, 1)] private float deadZone = 0;
        [SerializeField] [Min(0f)] private float moveThreshold = 1;
        [SerializeField] private AxisOptions axisOptions = AxisOptions.Both;
        [SerializeField] private bool snapX = false;
        [SerializeField] private bool snapY = false;
        [SerializeField] [Range(-180f, 180f)] private float offsetAngle = 0f;

        [Space(10)] [SerializeField] private RectTransform background = null;
        [SerializeField] private RectTransform handle = null;

        [Space(20)] [SerializeField] private bool isDynamic = false;
        [Space(20)] [SerializeField] private bool hideImages = false;

        public float HandleRange => handleRange;
        public float DeadZone => deadZone;

        public float MoveThreshold
        {
            get => moveThreshold;
            set => moveThreshold = Mathf.Abs(value);
        }

        public AxisOptions AxisOptions => axisOptions;
        public bool SnapX => snapX;
        public bool SnapY => snapY;
        public float OffsetAngle => offsetAngle;

        public RectTransform Background => background;
        public RectTransform Handle => handle;

        public bool IsDynamic => isDynamic;

        public override void Init(IEntity iEntity)
        {
            base.Init(iEntity);

            var center = new Vector2(0.5f, 0.5f);
            background.pivot = center;
            handle.anchorMin = center;
            handle.anchorMax = center;
            handle.pivot = center;
        }

        public void OnJoystickHandleAnchoredPosition(GameEntity entity, Vector2 value)
        {
            Handle.anchoredPosition = value;
        }

        public void OnJoystickBackgroundAnchoredPosition(GameEntity entity, Vector2 value)
        {
            Background.anchoredPosition = value;
        }

        public void OnJoystickHandleSetActive(GameEntity entity, bool value)
        {
            Handle.gameObject.SetActive(value);
        }

        public void OnJoystickBackgroundSetActive(GameEntity entity, bool value)
        {
            Background.gameObject.SetActive(value);
        }
        
        public void OnJoystickOffsetAngle(GameEntity entity, float value)
        {
            offsetAngle = value;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            var images = new UnityEngine.UI.Image[]
            {
                background.GetComponent<UnityEngine.UI.Image>(),
                handle.GetComponent<UnityEngine.UI.Image>()
            };
            var colors = new Color[images.Length];
            for (var i = 0; i < colors.Length; i++)
            {
                colors[i] = images[i].color;
                colors[i].a = hideImages ? 0 : 1;
                images[i].color = colors[i];
            }
        }
#endif
    }
}