using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Objects
{
    internal class OTestObj : BaseObject
    {
        public OTestObj(Pos pos)
        {
            _pos = pos;
            _sprite = new Utils.Sprite(
                new char[,] {
                    { '#', '#', '#', '#' },
                    { '#', ' ', ' ', '#' },
                    { '#', ' ', ' ', '#' },
                    { '#', '#', '#', '#' }});
        }

        public override void Update()
        {
            _pos._x += 0.1;

        }
        public override void Render()
        {
            _sprite.Render(_pos);
        }

    }
}
