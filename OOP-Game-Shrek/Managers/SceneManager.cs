using OOP_Game_Shrek.Scenes;
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
        private static Type _requestedScene;   // 전환이 요청된 Scene


        //Scene을 담아야하는데, 검색도 빨라야해서 key를 Type으로.
        static Dictionary<Type, BaseScene> _sceneList = new Dictionary<Type, BaseScene>();

        static SceneManager()
        {
            // default Scene 설정
            _requestedScene = typeof(SFirstScene);
        }


        /// <summary>
        /// SceneManager 가 Scene을 실행합니다.<br/>
        /// 유저의 Input 처리, 객체들의 Update 와 Render 가 포함됩니다.
        /// </summary>
        public static bool Run()
        {
            if (_quitRequested) return false;

            ProcessSceneConversion();

            InputManager.Poll();

            while(TimeManager.IsUpdateTime())
                ObjectManager.Update();

            ObjectManager.Render();


            return true;
        }

        // Scene전환요청이 있으면 처리해주는 함수
        static void ProcessSceneConversion()
        {
            // Scene 전환해야하면 Scene 전환
            if (_requestedScene != null)
            {
                // null로다시 바꿔주고
                Type nextScene = _requestedScene;
                _requestedScene = null;

                _previousScene = _currentScene;

                //있으면 꺼내쓰고
                if (!_sceneList.TryGetValue(nextScene, out _currentScene))
                {
                    //없으면 새로 만들기
                    _sceneList[nextScene] = (BaseScene)Activator.CreateInstance(nextScene);
                    _currentScene = _sceneList[nextScene];
                }

                //TimeManager Reset
                TimeManager.Reset();
            }
        }

        /// <summary>
        /// SceneManager 에게 게임종료를 요청합니다.
        /// </summary>
        public static void QuitGame()
        {
            _quitRequested = true;
        }


        public static void ChangeScene<T>() where T : BaseScene
        {
            _requestedScene = typeof(T);
        }

        public static void ChangePreviousScene()
        {
            _requestedScene = _previousScene?.GetType();
        }

    }
}
