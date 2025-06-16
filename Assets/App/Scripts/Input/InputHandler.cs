using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Inputs
{
    public class InputHandler : MonoBehaviour
    {
        public Action<Vector3> OnClick;
        public Action<Vector3> OnMove;
        public Action<Vector3> OnPointerUp;

        private bool _isClickedOnUI;

        private void Start()
        {
            OnClick += Click;
            OnPointerUp += PointerUp;
        }

        private void OnDestroy()
        {
            OnClick -= Click;
            OnPointerUp -= PointerUp;
        }

        private void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
#if UNITY_EDITOR
            EditorInput();
#else
            MobileInput();
#endif
        }

        private void EditorInput()
        {
            if (Input.GetMouseButtonDown(0) && IsPointerOverUIObject(Input.mousePosition))
            {
                _isClickedOnUI = true;
                return;
            }

            if (Input.GetMouseButtonDown(0) && !_isClickedOnUI)
            {
                OnClick?.Invoke(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0) && !_isClickedOnUI)
            {
                OnMove?.Invoke(Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(0)) OnPointerUp?.Invoke(Input.mousePosition);

            if (Input.GetMouseButtonUp(0)) _isClickedOnUI = false;
        }

        private void MobileInput()
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);
                    if (IsPointerOverUIObject(touch.position)) continue;
                    if (touch.phase == TouchPhase.Began)
                    {
                        OnClick?.Invoke(touch.position);
                    }
                    if (Input.touchCount == 1 && touch.phase == TouchPhase.Moved)
                    {
                        OnMove?.Invoke(Input.mousePosition);
                    }
                    if (Input.touchCount == 1 && touch.phase == TouchPhase.Ended
                        || Input.touchCount == 1 && touch.phase == TouchPhase.Canceled)
                    {
                        OnPointerUp?.Invoke(Input.mousePosition);
                    }
                }
            }
        }

        private void Click(Vector3 inputPosition)
        {
            
        }

        private void PointerUp(Vector3 inputPosition)
        {

        }

        public static bool IsPointerOverUIObject(Vector3 inputPosition)
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(inputPosition.x, inputPosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.layer == 5) //5 = UI layer
                {
                    return true;
                }
            }
            return false;
        }
    }
}