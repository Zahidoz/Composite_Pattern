using System;
using System.Collections.Generic;

namespace Composite_pattern1
{

   interface IGraphic
    {
        void Move(int x, int y);
        void Draw();
    }

    class Dot : IGraphic
    {
        private int _x { get; set; }
        private int _y { get; set; }

        public Dot(int x, int y)
        {
            _x = x;
            _y = y;
        }
        
        public void Draw()
        {
            Console.WriteLine("Dot x y draw");
        }

        public void Move(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }

    class Circle :Dot
    {
        private double _radius{ get; set; }

        public Circle(int x, int y, double radius):base(x, y)
        {
            _radius = radius;
        }
        public virtual void Draw() => Console.WriteLine("Circle x,y drow");
    } 

    class CompoudGraphic :IGraphic
    {
        public List<IGraphic> children = new List<IGraphic>();

        public void Add(IGraphic child)
        {
            children.Add(child);
        }
        
        public void Remove(IGraphic child)
        {
            children.Remove(child);
        }

        public void Draw()
        {
            foreach (var child in children)
                child.Draw();
        }

        public void Move(int x, int y)
        {
            foreach (var child in children)
                child.Move(x,y);
        }

    }

    class ImageEditor
    {
        public CompoudGraphic compoundGraph { get; set; }

        public void Load()
        {
            compoundGraph = new CompoudGraphic();
            compoundGraph.Add(new Dot(1, 2));
            compoundGraph.Add(new Circle(5, 3, 10));
        }


        public void GroupSelected(List<IGraphic> graphics)
        {
            var group = new CompoudGraphic();
            for (int i = 0; i < graphics.Count; i++)
            {
                group.Add(graphics[i]);
                compoundGraph.Remove(graphics[i]);
            }
            compoundGraph.Add(group);
            compoundGraph.Draw();
        }
    }




    public class Program
    {
        static void Main()
        {
            var imageEdidor = new ImageEditor();

            imageEdidor.Load();
            imageEdidor.GroupSelected(imageEdidor.compoundGraph.children);
        }
    }
}

