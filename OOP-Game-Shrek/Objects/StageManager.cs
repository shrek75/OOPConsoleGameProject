using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Objects
{
    internal class StageManager : BaseObject
    {
        // 현재스테이지
        int _currentStage = 0;


        // 스테이지별  몹수 + 초기화할 함수
        List<(int mobCount, Action initFunc)> _stageList;

        public StageManager()
        {

            _stageList = new List<(int mobCount, Action)>();
            //스테이지 정보 등록
            _stageList.Add((4, S0));
            _stageList.Add((8, S1));

            //비워주고
            ObjectManager._deadObjectList.Clear();

            //첫스테이지 로딩
            _stageList[_currentStage].initFunc.Invoke();
        }

        public override void Update()
        {
            if (_currentStage > _stageList.Count - 1) return;
            //Log.Push(Log.LogType._INFO, $"deadObjectCOunt [{ObjectManager._deadObjectList.Count}]");

            //스테이지 깼으면
            if(ObjectManager._deadObjectList.Count == _stageList[_currentStage].mobCount)
            {
                //비워주고
                ObjectManager._deadObjectList.Clear();

                _currentStage++;
                //전부 다 깼으면
                if (_currentStage > _stageList.Count - 1)
                {
                    ObjectManager.DeletePlayer(ObjectManager.Player);
                    SceneManager.ChangePreviousScene();
                    return;
                }

                //다음스테이지 로딩
                _isDeletable = false;
                ObjectManager.DeleteObjectsIfChangeScene();
                _isDeletable = true;
                ObjectManager.Player.MovePos(new Pos(3, 20));
                _stageList[_currentStage].initFunc.Invoke();


            }
        }


        void S0()
        {
            ObjectManager.AddObject(new MPoop(new Pos(11, 4)));
            ObjectManager.AddObject(new MPoop(new Pos(25, 4)));
            ObjectManager.AddObject(new MRamen(new Pos(3, 5)));
            ObjectManager.AddObject(new MRamen(new Pos(34, 18)));



            //Wall
            // 그냥 하나짜리 벽을만들면되지만 이렇게 해보고싶음
            ObjectManager.AddObject(new Wall(new Pos(0, 0)));
            ObjectManager.AddObject(new Wall(new Pos(1, 0)));
            ObjectManager.AddObject(new Wall(new Pos(2, 0)));
            ObjectManager.AddObject(new Wall(new Pos(3, 0)));
            ObjectManager.AddObject(new Wall(new Pos(4, 0)));
            ObjectManager.AddObject(new Wall(new Pos(5, 0)));
            ObjectManager.AddObject(new Wall(new Pos(6, 0)));
            ObjectManager.AddObject(new Wall(new Pos(0, 1)));
            ObjectManager.AddObject(new Wall(new Pos(1, 1)));
            ObjectManager.AddObject(new Wall(new Pos(2, 1)));
            ObjectManager.AddObject(new Wall(new Pos(3, 1)));
            ObjectManager.AddObject(new Wall(new Pos(4, 1)));
            ObjectManager.AddObject(new Wall(new Pos(5, 1)));
            ObjectManager.AddObject(new Wall(new Pos(6, 1)));

            ObjectManager.AddObject(new Wall(new Pos(33, 23)));
            ObjectManager.AddObject(new Wall(new Pos(34, 23)));
            ObjectManager.AddObject(new Wall(new Pos(35, 23)));
            ObjectManager.AddObject(new Wall(new Pos(36, 23)));
            ObjectManager.AddObject(new Wall(new Pos(37, 23)));
            ObjectManager.AddObject(new Wall(new Pos(38, 23)));
            ObjectManager.AddObject(new Wall(new Pos(39, 23)));
            ObjectManager.AddObject(new Wall(new Pos(33, 22)));
            ObjectManager.AddObject(new Wall(new Pos(34, 22)));
            ObjectManager.AddObject(new Wall(new Pos(35, 22)));
            ObjectManager.AddObject(new Wall(new Pos(36, 22)));
            ObjectManager.AddObject(new Wall(new Pos(37, 22)));
            ObjectManager.AddObject(new Wall(new Pos(38, 22)));
            ObjectManager.AddObject(new Wall(new Pos(39, 22)));
            ObjectManager.AddObject(new Wall(new Pos(33, 21)));
            ObjectManager.AddObject(new Wall(new Pos(34, 21)));
            ObjectManager.AddObject(new Wall(new Pos(35, 21)));
            ObjectManager.AddObject(new Wall(new Pos(36, 21)));
            ObjectManager.AddObject(new Wall(new Pos(37, 21)));
            ObjectManager.AddObject(new Wall(new Pos(38, 21)));
            ObjectManager.AddObject(new Wall(new Pos(39, 21)));
        }
        void S1()
        {
            ObjectManager.AddObject(new MPoop(new Pos(11, 4)));
            ObjectManager.AddObject(new MPoop(new Pos(25, 4)));
            ObjectManager.AddObject(new MPoop(new Pos(27, 6)));
            ObjectManager.AddObject(new MPoop(new Pos(29, 8)));
            ObjectManager.AddObject(new MPoop(new Pos(31, 10)));
            ObjectManager.AddObject(new MPoop(new Pos(33, 12)));

            ObjectManager.AddObject(new MRamen(new Pos(3, 5)));
            ObjectManager.AddObject(new MRamen(new Pos(34, 18)));


        }

    }
}
