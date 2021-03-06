using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HW3EX3
{
    [TestClass]
    public class CalculateAreaShouldReturn
    {
        [TestMethod]
        public void SixFor2X3Rectangle()
        {
            var myRectangle = new Rectangle { Height = 2, Width = 3 };
            Assert.AreEqual(6, AreaCalculator.CalculateArea(myRectangle));
        }

        [TestMethod]
        public void NineFor3X3Square()
        {
            var mySquare = new Square() { Height = 3 };
            Assert.AreEqual(9, AreaCalculator.CalculateArea(mySquare));
        }

        [TestMethod]
        public void TwentyFor4X5RectangleFromSquare()
        {
            Rectangle newRectangle = new Square();
            newRectangle.Width = 4;
            newRectangle.Height = 5;
            Assert.AreEqual(20, AreaCalculator.CalculateArea(newRectangle));
        }

        [TestMethod]
        public void TwentyFor4X5ShapeFromRectangle()
        {
            Shape myShape = new Rectangle() { Height = 4, Width = 5 };
            Assert.AreEqual(20, myShape.Area());
        }

        [TestMethod]
        public void TwentyFor4X5ShapeFromRectangleAnd9For3X3Square()
        {
            var shapes = new List<Shape>
                             {
                                 new Rectangle {Height = 4, Width = 5},
                                 new Square {SideLength = 3}
                             };
            var areas = new List<int>();
            foreach (Shape shape in shapes)
            {
                areas.Add(shape.Area());
            }
            Assert.AreEqual(20, areas[0]);
            Assert.AreEqual(9, areas[1]);
        }

    }

    public class AreaCalculator
    {
        public static int CalculateArea(Rectangle r)
        {
            return r.Height * r.Width;
        }

        public static int CalculateArea(Square s)
        {
            return s.Height * s.Height;
        }
    }

    public interface Shape
    {

        public int Area();
    }

    public class Rectangle : Shape
    {
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }

        public virtual int Area()
        {
            return AreaCalculator.CalculateArea(this);
        }
    }

    public class Square : Rectangle, Shape
    {
        public int SideLength { get; set; }

        public override int Height
        {
            get { return SideLength; }
            set
            {
                SideLength = value;
            }
        }

        public override int Area()
        {
            return AreaCalculator.CalculateArea(this);
        }
    }
}