using UnityEngine;

namespace Menu
{
    public class PauseUI : OverlayUI
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                TogglePanel();
        }
    }
}
