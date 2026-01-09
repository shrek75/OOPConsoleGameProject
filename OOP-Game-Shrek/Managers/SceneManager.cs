using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek
{
    internal static class SceneManager
    {
        private static bool _quitRequested = false; // 게임종료 요청 플래그
        private static BaseScene _currentScene;     // 현재 실행중인 Scene
        private static BaseScene _previousScene;    // 이전에 실행되었던 Scene
        private static BaseScene _requestedScene;   // 전환이 요청된 Scene
        private static TimeManager _timeManager = new TimeManager();

        // baseScene을 상속받는 Scene 목록
        public enum SceneList
        {
            STitle
        }

       


        /// <summary>
        /// SceneManager 가 Scene을 실행합니다.<br/>
        /// 유저의 Input 처리, 객체들의 Update 와 Render 가 포함됩니다.
        /// </summary>
        public static bool Run()
        {
            InputManager.Poll();

            int n = _timeManager.GetUpdateTimes();
            for(int i = 0; i< n;i++)
            {
                // OM.Update();
            }

            // OM.Render();

            // Scene 전환해야하면 Scene 전환
            if(_requestedScene != null)
            {
                // 전환
            }

            if (_quitRequested) return false;
            return true;
        }

        /// <summary>
        /// SceneManager 에게 게임종료를 요청합니다.
        /// </summary>
        public static void QuitGame()
        {
            _quitRequested = true;
        }


        public static void ChangeScene(SceneList scene)
        {
            // scene 에 따라 _requestedScene 설정
        }

        public static void ChangePreviousScene()
        {
            // _previousScene 으로 전환 요청
        }

    }
}
