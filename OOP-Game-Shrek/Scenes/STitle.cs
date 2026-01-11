using OOP_Game_Shrek.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Scenes
{
    internal class STitle : BaseScene
    {
        //오브젝트를 어떻게 생성하고 어떻게 삭제할거냐인데..
        // 오브젝트가 오브젝트를 생성할수도있잖아. 예를들어 총을쏘면 총알생성, 적이죽으면 아이템생성 등 

        //씬의 생성자에서 오브젝트매니저 통해서 오브젝트를 생성한다고치자
        //오브젝트의 업데이트에서도 오브젝트를 생성하고 삭제하겟지, 삭제되는건 충돌처리,상호작용,자기스스로, 나 씬이바뀔때 등이잖아. 앞에거는 오브젝트매니저에서 할수있고, 씬이바뀔때 삭제될여부를 객체가 들고있어야하고,
        // 씬매니저에서 씬이바뀔때(혹은 필요할때) 오브젝트매니저한테 삭제요청을 해야할거같은데

        // 1스테이지를 깻다고치자. 2스테이지로넘어갈때 1스테이지에 있는 잡몹이나 남은아이템등은 삭제해야하고, 플레이어같은건 그대로있어야하잖아.

        //BaseObject를 상속받는거중에 유지되어야할게있고 삭제되어야할게있어.
        // 이걸 매번 검사하지않고 유지되어야하는거와 삭제되어야하는걸 구분해서 관리하면 되잖아
        //
        // BaseObject에 인터페이스 넣는데 , 충돌가능, 상호작용가능, 삭제가능 이런거 넣고
        // 속도도 빨라야하니깐 baseobject list도 두고 인터페이스별로 list도 전부 둬.
        // 생성 삭제할때만 잘해주면 훨씬 빠르겟네.

        public STitle()
        {
            ObjectManager.AddObject((new MPoop(new Pos(4, 4))));

        }



    }
}
