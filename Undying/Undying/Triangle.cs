using System;

namespace Undying
{
    public class Triangle
    {
        const
            double EPS = 0.001d;

        private double a_side;
        private double b_side;
        private double c_side;

        public Triangle(string a_side, string b_side, string c_side)
        {
            SetSides(a_side, b_side, c_side);
        }

        private void SetSides(string a_side, string b_side, string c_side)
        {
            this.a_side = double.Parse(a_side);
            this.b_side = double.Parse(b_side);
            this.c_side = double.Parse(c_side);
            if ((this.a_side <= 0) || (this.b_side <= 0) || (this.c_side <= 0))
                throw new ArgumentException("Введённое число меньше либо равно нулю. \nДопустимый промежуток (0; 1,7 × 10^308].");
            double p = (this.a_side + this.b_side + this.c_side) / 2;
            if (!(Math.Sqrt(p * (p - this.a_side) * (p - this.b_side) * (p - this.c_side)) < EPS) && 
                !((this.a_side < this.b_side + this.c_side) && (this.b_side < this.a_side + this.c_side) && (this.c_side < this.a_side + this.b_side)))
                throw new ArgumentException("Описанный треугольник является вырожденным");

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
