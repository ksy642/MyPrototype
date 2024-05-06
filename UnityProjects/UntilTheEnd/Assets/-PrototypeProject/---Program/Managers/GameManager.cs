using UnityEngine;

namespace UntilTheEnd
{
    public class GameManager : DontDestroySingleton<GameManager>
    {
        // �߰�

        [Header("FPS")]
        [SerializeField] private Color color = Color.red;
        private int size = 25;
        private float deltaTime = 0f;

        void Update()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        }

        private void OnGUI()
        {
            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(1700, 20, Screen.width, Screen.height);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = size;
            style.normal.textColor = color;

            float ms = deltaTime * 1000f;
            float fps = 1.0f / deltaTime;
            string text = string.Format("{0:0.} FPS ({1:0.0} ms)", fps, ms);

            GUI.Label(rect, text, style);
        }
    }
}