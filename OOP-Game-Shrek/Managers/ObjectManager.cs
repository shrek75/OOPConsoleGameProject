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
    }
}
