using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Objects
{
    //디버그모드 ON/OFF 키보드로 변경위해 L키 받는 오브젝트 추가
    internal class DummyObject : BaseObject
    {
        public override void Update()
        {
            // GetAsyncKeyState & 0x0001이랑하면 너무씹히는데;;
            // 눌렀을때마다 토글할려면 이런식으로 flag하나 더 만들래
            bool Linput = InputManager.Keys.Contains(ConsoleKey.L);
            if (Linput && !Log.modeFlag)
                Log.DebugMode = !Log.DebugMode;
            Log.modeFlag = Linput;
        }
    }
}
