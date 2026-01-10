using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Game_Shrek.Objects
{
    internal class OTestObj : BaseObject
    {
        public OTestObj()
        {
            _pos = new Pos { X = 3, Y = 0};
            _sprite = new Utils.Sprite(
                new char[,] {
                    { '#', '#', '#', '#' },
                    { '#', ' ', ' ', '#' },
                    { '#', ' ', ' ', '#' },
                    { '#', '#', '#', '#' }});
        }

        public override void Update()
        {
            
        }
        public override void Render()
        {
            _sprite.Render(_pos);
        }

    }
}
