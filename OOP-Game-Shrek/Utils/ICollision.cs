using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Utils
{
    // 충돌처리가 필요한 객체는 이 인터페이스를 구현해야한다.
    internal interface ICollision
    {
        // 충돌이 발생했을때 역호출되는 메서드이고, 인수 otherObj는 나와 충돌한 객체이다.
        void OnCollision(BaseObject otherObj);
    }
}
