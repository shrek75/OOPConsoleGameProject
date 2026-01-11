using OOP_Game_Shrek.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Objects
{
    //일단 상위클래스 만들어야할것같아서 만든 몬스터클래스
    internal abstract class Monster : BaseObject, ICollision
    {
        //몸박뎀
        int _bodyDamage = 5;


        //Monster클래스 기본 Update. 
        public override void Update()
        {
            Move();
        }

        public override void Render()
        {
            base.Render();
        }
        

        public void OnCollision(BaseObject otherObj)
        {
            

        }

    }
}
