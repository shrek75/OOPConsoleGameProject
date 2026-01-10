using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek
{
    internal static class TimeManager
    {
        private const int GAME_TPS = 30; // 게임의 초당 Update 호출 주기
        private const long AVERAGE_TICKS = 10000000 / GAME_TPS; //게임 로직 고정 틱
        
        //private long _gameLogicCount = 0; // 현재 Update 횟수
        //private long _lastGameLogicCount = 0; // 1초전 Update 횟수

        //private long _FrameCount = 0; // 렌더링된 전체 프레임 수
        //private long _lastFrameCount = 0; // 1초전 프레임 수

        static int _updateTimes = 0; //한 루프에서 Update를 너무 많이 호출하는 걸 방지하기 위한 변수

        static long _lastUpdateTick = 0; // 마지막 Update 시점의 tick
        static long _deltaTick = 0;     // 마지막 Update 이후 남은 tick
        public static long DeltaTick { get { return _deltaTick; } }

        static Stopwatch _timePerFrame; //tick측정을 위한 Stopwatch
        static TimeManager()
        {
            _timePerFrame = Stopwatch.StartNew();
        }

        public static void Reset()
        {
            _updateTimes = 0;
            _lastUpdateTick = 0;
            _deltaTick = 0;
            _timePerFrame = Stopwatch.StartNew();
        }

        /// <summary>
        /// Update를 할 타이밍인지 반환합니다. 내부적으로 deltaTick을 계산합니다.
        /// </summary>
        public static bool IsUpdateTime()
        {
            ReportDeltaTick();

            // Update 해야할 타이밍인지 확인
            if (_deltaTick < AVERAGE_TICKS)
            {
                _updateTimes = 0;
                return false;
            }

            // 한 루프에서 업데이트를 너무 많이 호출하는 걸 방지
            if (_updateTimes++ > 10)
            {
                _updateTimes = 0;
                return false;
            }

            // LastUpdateTick 갱신
            _lastUpdateTick += AVERAGE_TICKS;
            _deltaTick -= AVERAGE_TICKS;

            return true;
        }

        public static long ReportDeltaTick()
        {
            // deltaTick 계산
            _deltaTick = _timePerFrame.ElapsedTicks - _lastUpdateTick;
            return _deltaTick;
        }
       
        
    }
}
