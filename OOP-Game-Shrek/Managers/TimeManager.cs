using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek
{
    // 게임에서 필요한 타이밍을 관리하는 클래스
    internal static class TimeManager
    {
        private const int GAME_TPS = 30; // 게임의 초당 Update 호출 주기
        private static readonly long AVERAGE_TICKS = Stopwatch.Frequency / GAME_TPS; //게임 로직 고정 틱
        private static readonly double _logicTime = 1.0 / GAME_TPS; //Update마다 넣어주는 고정시간
        public static double LogicTime { get { return _logicTime; } }

        private static long _gameLogicCount = 0; // 현재 Update 횟수
        private static long _lastGameLogicCount = 0; // 1초전 전체 Update 횟수
        private static int _nowTps;                  //지난 1초간 tps
        public static int nowTPS {  get { return _nowTps; } } 

        private static long _FrameCount = 0; // 렌더링된 전체 프레임 수
        private static long _lastFrameCount = 0; // 1초전 전체 프레임 수
        private static int _nowFps;              //지난 1초간 fps
        public static int nowFPS { get { return _nowFps; } }


        static int _updateTimes = 0; //한 루프에서 Update를 너무 많이 호출하는 걸 방지하기 위한 변수

        static long _lastUpdateTick = 0; // 마지막 Update 시점의 tick
        static long _deltaTick = 0;     // 마지막 Update 이후 남은 tick
        static double _deltaTime = 0;   // _deltaTick을 시간으로 변경한 값.
        public static double DeltaTime { get { return _deltaTime; } }

        static DateTime _nextSecond;
        private static Action _funcBySec;
        public static Action FuncBySec
        {
            private get { return _funcBySec; }
            set { _funcBySec = value; }
        }

        static Stopwatch _timePerFrame; //tick측정을 위한 Stopwatch

        static TimeManager()
        {
            _nextSecond = DateTime.Now;
            _timePerFrame = Stopwatch.StartNew();
        }

        public static void Reset()
        {
            _updateTimes = 0;
            _lastUpdateTick = 0;
            _deltaTick = 0;
            _deltaTime = 0;
            _nextSecond = DateTime.Now;
            _timePerFrame = Stopwatch.StartNew();
        }

        /// <summary>
        /// Update를 할 타이밍인지 반환합니다. 내부적으로 deltaTick을 계산합니다.
        /// </summary>
        public static bool IsUpdateTime()
        {
            ProcBySecond();

            Report();

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
            _deltaTime = (double)_deltaTick / Stopwatch.Frequency;

            
            return true;
        }

        // 지금까지 lastUpdate 이후 얼마나 지났는지 _deltaTick 계산
        private static void Report()
        {
            // deltaTick 계산
            _deltaTick = _timePerFrame.ElapsedTicks - _lastUpdateTick;
            _deltaTime = (double)_deltaTick / Stopwatch.Frequency;
        }   
        
        //1초마다 돌릴 로직 (평균적으로는 1초지만 동기라서 개별시간은 부정확)
        private static void ProcBySecond()
        {
            DateTime now = DateTime.Now;
            if (now >= _nextSecond)
            {
                //지난 1초간 로직횟수 기록
                _nowTps = (int)(_gameLogicCount - _lastGameLogicCount);
                _lastGameLogicCount = _gameLogicCount;
                //지난 1초간 렌더횟수 기록
                _nowFps = (int)(_FrameCount - _lastFrameCount);
                _lastFrameCount = _FrameCount;

                _nextSecond = _nextSecond.AddSeconds(1);
                
                //다른 클래스를 위한 Delegate돌려주기
                FuncBySec?.Invoke();
            }
        }

        public static void AddLogicCount() => _gameLogicCount++;
        public static void AddFrameCount() => _FrameCount++;

        
    }
}
