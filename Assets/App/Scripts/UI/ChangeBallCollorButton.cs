using Game.Enums;
using Game.Inputs;
using Game.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class ChangeBallCollorButton : MonoBehaviour
    {
        private static BallType BallType { get; set; }

        [field: SerializeField] private TMP_Text _colorText { get; set; }
        [field: SerializeField] private bool _isNextColorButton { get; set; }

        private InputHandler _inputHandler;

        private void Awake()
        {
            _inputHandler = FindObjectOfType<InputHandler>();
            _colorText.text = BallType.ToString();
            GetComponent<Button>().onClick.AddListener(ChangeClickColor);
        }

        private void ChangeClickColor()
        {
            if (_isNextColorButton && (int)BallType < (int)BallType.Red) BallType++;
            if (!_isNextColorButton && (int)BallType > 0) BallType--;
            _colorText.text = BallType.ToString();
            _inputHandler.OnClick = null;
            _inputHandler.OnClick += ChangeBallColor;
        }

        private void ChangeBallColor(Vector3 input)
        {
            Ray ray = Camera.main.ScreenPointToRay(input);
            Physics.Raycast(ray, out var hit, 1000f);
            if (hit.collider == null || hit.collider != null && hit.collider.GetComponent<Ball>() == null) return;

            hit.collider.GetComponent<Ball>().ChangeType(BallType);
        }
    }
}