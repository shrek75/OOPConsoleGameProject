using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Game_Shrek.Utils;

namespace OOP_Game_Shrek
{
    // 모든 오브젝트들을 관리하는 ObjectManager 클래스
    internal static class ObjectManager
    {
        static List<BaseObject> _allObjList = new List<BaseObject>();        // 관리하는 전체 오브젝트 리스트
        static List<ICollision> _collisionObjList = new List<ICollision>();  // 전체 오브젝트중 ICollision 오브젝트만
        static Queue<BaseObject> _objAddRequestList = new Queue<BaseObject>(); // 오브젝트 생성 요청리스트 
        static Queue<BaseObject> _objDelRequestList = new Queue<BaseObject>(); // 오브젝트 삭제 요청리스트 

        // 생성한 오브젝트를 ObjectManager에게 등록 요청
        public static void AddObject(BaseObject obj)
        {
            _objAddRequestList.Enqueue(obj);
        }

        // 등록요청된 오브젝트들을 등록해준다
        private static void ProcessObjAddRequest()
        {
            while (_objAddRequestList.Count != 0)
            {
                BaseObject obj = _objAddRequestList.Dequeue();

                _allObjList.Add(obj);

                // 오브젝트의 인터페이스에 따라 추가 등록
                if (obj is ICollision i)
                    _collisionObjList.Add(i);
            }            
        }

        // 오브젝트를 ObjectManager에게 삭제 요청
        public static void DeleteObject(BaseObject obj)
        {
            _objDelRequestList.Enqueue(obj);
        }

        // 등록요청된 오브젝트들을 삭제해준다
        private static void ProcessObjDelRequest()
        {
            while (_objDelRequestList.Count != 0)
            {
                BaseObject obj = _objDelRequestList.Dequeue();

                _allObjList.Remove(obj);

                // 오브젝트의 인터페이스에 따라 다른리스트도 삭제해주기
                if (obj is ICollision i)
                    _collisionObjList.Remove(i);
            }
        }

        //오브젝트들 update랑 충돌처리 돌려주고, add요청 delete요청 처리해주기.
        public static void Update()
        {
            // 이미 충돌처리한 collisionObject의 인덱스를 세기위해
            int target = 0;
            for(int i = 0; i < _allObjList.Count; i++)
            {
                // 오브젝트 Update
                _allObjList[i].Update();

                // Update한 오브젝트가 충돌처리해야할 Object라면
                if (_allObjList[i] is ICollision coll)
                {
                    // 순회하면서 충돌이 있는지 확인
                    for(int j = target + 1; j< _collisionObjList.Count; j++)
                    {
                        BaseObject Bj = (BaseObject)_collisionObjList[j];
                        BaseObject Bt = (BaseObject)_collisionObjList[target];
                        if (CollisionCheck(Bj,Bt))
                        {
                            //충돌했으면 양쪽에 알려주기
                            _collisionObjList[target].OnCollision(Bj);
                            _collisionObjList[j].OnCollision(Bt);
                        }
                    }
                    target++;
                }
            }
            ProcessObjAddRequest();
            ProcessObjDelRequest();
        }

        public static void Render()
        {
            // Object들 Rendering
            foreach(BaseObject obj in _allObjList)
                obj.Render();

            //버퍼에있는거 Console.Write()해주기
            ConsoleManager.Flip();
        }

        private static bool CollisionCheck(BaseObject obj1, BaseObject obj2)
        {
            double obj1X = obj1.Pos._x;
            double obj1Y = obj1.Pos._y;
            double obj2X = obj2.Pos._x;
            double obj2Y = obj2.Pos._y;

            //두 도형의 중심 사이의 거리
            double distanceX = Math.Abs(obj2X - obj1X); 
            double distanceY = Math.Abs(obj2Y - obj1Y);

            //두 도형이 접할 때 기준 중심 사이의 거리  
            double lengthX = obj1._sprite._sizeX / 2.0 + obj2._sprite._sizeX / 2.0;
            double lengthY = obj1._sprite._sizeY / 2.0 + obj2._sprite._sizeY / 2.0;

            //거리가 접할때길이보다 크면 충돌X
            if(distanceX > lengthX || distanceY > lengthY)
                return false;
            return true;
        }
    }
}
