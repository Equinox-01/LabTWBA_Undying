using System;

namespace Undying
{
    public class Triangle
    {
        const
            double EPS = 0.001d;

        private int a_side;
        private int b_side;
        private int c_side;

        public Triangle(string a_side, string b_side, string c_side)
        {
            SetSides(a_side, b_side, c_side);
        }

        private void SetSides(string a_side, string b_side, string c_side)
        {
            this.a_side = int.Parse(a_side);
            this.b_side = int.Parse(b_side);
            this.c_side = int.Parse(c_side);
            if ((this.a_side <= 0) || (this.b_side <= 0) || (this.c_side <= 0))
                throw new ArgumentException("Введённое число меньше либо равно нулю. \nДопустимый промежуток от 1 до 2^16 - 1.");
            if (!((this.a_side < this.b_side + this.c_side) && (this.b_side < this.a_side + this.c_side) && (this.c_side < this.a_side + this.b_side)))
                throw new ArgumentException("Описанный треугольник является вырожденным. В треугольнике сумма двух сторон должна быть больше третьей стороны");
        }

        public string GetTriangleType()
        {
            string result = "";
            if ((a_side == b_side) && (c_side == b_side))
                result = "Треугольник равносторонний.";
            else
            {
                result = "Треугольник неравносторонний.";
                if ((a_side == b_side) || (a_side == c_side) || (b_side == c_side))
                    result = "Треугольник равнобедренный.";
            }
            return result;
        }
    }
}
