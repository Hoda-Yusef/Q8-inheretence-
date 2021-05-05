//Hoda Khier + Yusef Aborokn 44/5
using System;
using System.Collections.Generic;
using System.Text;

namespace Q5__inheretence_
{
    class Circle : IComparable
    {
        private string color;
        private int thick;
        private Point center_point;
        private int radius;

        //הגדרת בנאי
        public Circle(int radius,int thick,int centerX,int centerY,string color)
        {
            this.radius = radius;
            this.thick = thick;
            this.center_point = new Point(centerX, centerY);
            this.color = color;
        }

        public Circle(int radius, int thick, int centerX, int centerY)
        {
            this.radius = radius;
            this.thick = thick;
            this.center_point = new Point(centerX, centerY);
            this.color = "black";
        }

        //הגדרת בנאי
        public Circle()
        {
            this.radius = 0;
            this.thick = 0;
            this.center_point = new Point(0, 0);
            this.color = "black";
        }

        public override bool Equals(object obj)//שיטה שמשווה ראדיוס בין שני אובייקטים
        {
            if (obj is Circle)
            {
                Circle C;
                C = (Circle)obj;

                if (this.radius == C.radius)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }


        public float scope_calculator()//חישוב היקף של מעגל
        {
            return (float)(2 * 3.14 * this.radius);
        }

        public float area_calculator()//חישוב שטח של מעגל
        {
            return (float)(3.14 * this.radius * this.radius);
        }

        public Boolean check_point_on_line(int x,int y)//בדיקה אם נקודה נמצאת במעגל
        {
            if ((float)Math.Sqrt((center_point.getX() - x) * (center_point.getX() - x) + (center_point.getY() - y) * (center_point.getY() - y)) == this.radius)
            {
                return true;
            }
            else
                return false;
        }


        //SETTERS AND GETTERS
        public void set_radius(int radius)
        {
            this.radius = radius;
        }

        public int get_radius()
        {
            return this.radius;
        }

        public void set_centerX(int x)
        {
            this.center_point.setX(x);
        }

        public int get_centerX()
        {
            return this.center_point.getX();
        }

        public void set_centerY(int y)
        {
            this.center_point.setY(y);
        }

        public int get_centerY()
        {
            return this.center_point.getY();
        }

        public void set_thick(int thick)
        {
            this.thick = thick;
        }

        public int get_thick()
        {
            return this.thick;
        }

        public void set_color(string color)
        {
            this.color = color;
        }

        public string get_color()
        {
            return this.color;
        }

        public int CompareTo(object obj)//שיטה שממיינת מערך של מעגלים לפי ראדיוס
        {
            Circle c = null;
            if (obj is Circle)
            {
                c = (Circle)obj;
            }
            else
                return 1;

            return this.radius - c.radius;
        }
    }
}
