using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek
{
    internal struct Pos
    {
        public double _x;
        public double _y;


        public Pos(double x, double y)
        {
            _x = x;
            _y = y;
        }


        // from에서 to까지 거리 반환
        public static double GetDistance(Pos from, Pos to)
        {
            double dx = to._x - from._x;
            double dy = to._y - from._y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // 크기 1짜리 방향벡터 반환.  인텔리센스 왤캐 좋아;;
        public static Pos GetDirVector(Pos from, Pos to)
        {
            double dx = to._x - from._x;
            double dy = to._y - from._y;
            double length = Math.Sqrt(dx * dx + dy * dy);
            if (length == 0)
            {
                return new Pos { _x = 0, _y = 0 };
            }
            return new Pos { _x = dx / length, _y = dy / length };
        }



        // 더하기 연산자 오버로딩
        public static Pos operator +(Pos a, Pos b)
        {
            return new Pos { _x = a._x + b._x, _y = a._y + b._y };
        }

        // 곱하기 연산자 오버로딩
        public static Pos operator *(Pos pos, double d)
        {
            return new Pos { _x = pos._x * d, _y = pos._y * d };
        }
        public static Pos operator *(double d, Pos pos)
        {
            return new Pos { _x = pos._x * d, _y = pos._y * d };
        }
        public static Pos operator *(Pos pos, int i)
        {
            return new Pos { _x = pos._x * i, _y = pos._y * i };
        }
        public static Pos operator *(int i, Pos pos)
        {
            return new Pos { _x = pos._x * i, _y = pos._y * i };
        }
    }
}
