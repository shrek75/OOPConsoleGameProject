using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Game_Shrek.Utils;

namespace OOP_Game_Shrek
{
    internal static class ObjectManager
    {
        static List<BaseObject> _allObjList = new List<BaseObject>();        // 관리하는 전체 오브젝트 리스트
        static List<ICollision> _collisionObjList = new List<ICollision>();  // 전체 오브젝트중 ICollision 오브젝트만
        static Queue<BaseObject> _objAddRequestList = new Queue<BaseObject>(); // 오브젝트 생성 요청리스트 

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

        // 삭제랑


        // Update랑
        // 충돌처리등등...


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
                        //이거 2개 충돌했는지 확인후
                        //_collisionObjList[target];
                        //_collisionObjList[j];
                        //이런식으로 양쪽에 충돌했다고 알려주기.
                        _collisionObjList[target].OnCollision((BaseObject)_collisionObjList[j]);
                        _collisionObjList[j].OnCollision((BaseObject)_collisionObjList[target]);

                        //근데 이게 충돌했는지 확인하는 과정에 객체의 크기 개념이 있어야 하는구나..
                        // 좌표는 점이니까..
                    }
                    target++;
                }
            }
        }
    }
}
