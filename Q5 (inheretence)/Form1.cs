using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q5__inheretence_
{
    public partial class calculator_display : Form
    {
        //בניית אובייקטים

        private Line p1 = new Line();
        private Line p2 = new Line();
        private Circle c1 = new Circle();
        private Circle c2 = new Circle();
        private Polygon poly1 = new Polygon();
        private Polygon poly2 = new Polygon();

        Circle[] arr = new Circle[5];
        Polygon[] arrP = new Polygon[5];

        Random rnd = new Random();

        Polygon pp = new Polygon();
        

        
   
        public calculator_display()
        {
            
            InitializeComponent();

            for(int i=0;i<5;i++)//לולאה למילוי ערכים אקראיים למעגל ומצולע
            {
                arr[i] = new Circle(rnd.Next(1, 20),rnd.Next(1,20),rnd.Next(1,20),rnd.Next(1,20));
                arrP[i] = new Polygon();

                for (int j = 0; j < 5; j++)
                {
                    int num = rnd.Next(1, 10);
                    
                    arrP[i].set_polygonX(rnd.Next(num));
                    arrP[i].set_polygonY(2);
                    arrP[i].set_numOfPoints(arrP[i].get_numOfPoints() + 1);

                }
 
            }

            for (int i = 0; i < 5; i++)//הדפסת ראדיוס של מערך מעגלים
            {
                sort_display_circle.Text +="Ciecle "+(i+1)+" : "+ arr[i].get_radius()+"\n";
            }


            for (int i = 0; i < 5; i++)//הדפסת היקף של מערך של מצולעים
            {
                sort_display_polygon.Text += "Polygon " + (i + 1) + " : " + arrP[i].scope_polygon() + "\n";
            }

            for (int j = 0; j < 5; j++)
            {

                pp.set_polygonX(rnd.Next(1, 10));
                pp.set_polygonY(rnd.Next(2,10));
                pp.set_numOfPoints(pp.get_numOfPoints() + 1);

            }

            Polygon ppClone = (Polygon)pp.Clone();//יצירת עותק של מצולע
            
            for(int i=0;i<5;i++)//הדפסת מצולע 
            {
                orginal_display_polygon.Text += "Point " + (i + 1) + " : (" + pp.get_polygonX(i)+","+pp.get_polygonY(i)+")\n";

            }

            for (int i = 0; i < 5; i++)//הדפסת מצולע העתק
            {
                clone_display_polygon.Text += "Point " + (i + 1) + " : (" + ppClone.get_polygonX(i) + "," + ppClone.get_polygonY(i) + ")\n";

            }

            ppClone.set_numOfPoints(0);
            for (int j = 0; j < 5; j++)//הדפסת ערכים חדשים למצולע העותק
            {

                ppClone.set_polygonX(rnd.Next(1, 10));
                ppClone.set_polygonY(rnd.Next(2, 10));
                ppClone.set_numOfPoints(pp.get_numOfPoints() + 1);

            }

            for (int i = 0; i < 5; i++)//הדפסת מצולע העותק אחרי ההוספה
            {
                after_edit.Text += "Point " + (i + 1) + " : (" + ppClone.get_polygonX(i) + "," + ppClone.get_polygonY(i) + ")\n";
            }





        }

        

        private void accept_line_Click(object sender, EventArgs e)//כפתור לקבלת קו
        {
           
            //בדיקה אם הערכים לא שליליים
            if (sx.Value > 0 && sy.Value > 0 && ex.Value > 0 && ey.Value > 0 && thick.Value > 0)
            {
                panel1.Show();
                panel2.Show();
                panel3.Show();

                int Sx = Convert.ToInt32(sx.Value);
                int Sy = Convert.ToInt32(sy.Value);
                int Ex = Convert.ToInt32(ex.Value);
                int Ey = Convert.ToInt32(ey.Value);
                int Thick = Convert.ToInt32(thick.Value);

                p1.set_startX(Sx);
                p1.set_startY(Sy);
                p1.set_endX(Ex);
                p1.set_endY(Ey);
                p1.set_thick(Thick);
                p1.set_color(color_box.Text);
                

            }
            else
                MessageBox.Show(" ערכים שלילים או 0");


        }

        private void button1_Click(object sender, EventArgs e)//כפתור להצגת אורך קו
        {
            line_length.Text = "Length :\n"+ p1.line_length();

        }

        private void move_Click(object sender, EventArgs e)//כפתור להזזת קו
        {
            //בדיקה אם הערכים לא שליליים
            if (moveX.Value >= 0 && moveY.Value >= 0)
            {
                int mx = Convert.ToInt32(moveX.Value);
                int my = Convert.ToInt32(moveY.Value);

                p1.set_startX(mx + p1.get_startX());
                p1.set_startY(my + p1.get_startY());
                p1.set_endX(mx + p1.get_endX());
                p1.set_endY(my + p1.get_endY());
            }
            else
                MessageBox.Show("ערך שלילי");
        }

        private void display_Click(object sender, EventArgs e)//to string of line
        {
            toString_display.Text = "Start (" + p1.get_startX() + "," + p1.get_startY() + ")\n End (" + p1.get_endX() + "," + p1.get_endY() + ")";
        }

       

        private void button6_Click(object sender, EventArgs e)//כפתור לקבלת מעגל
        {
            
            //בדיקה אם הערכים לא שליליים
            if (centerX.Value > 0 && centerY.Value > 0 && thick_line.Value > 0 && raduis.Value > 0)
            {
                panel4.Show();
                panel5.Show();
                panel6.Show();

                int x = Convert.ToInt32(centerX.Value);
                int y = Convert.ToInt32(centerY.Value);
                int thick = Convert.ToInt32(thick_line.Value);
                int Raduis = Convert.ToInt32(raduis.Value);

                c1.set_centerX(x);
                c1.set_centerY(y);
                c1.set_radius(Raduis);
                c1.set_thick(thick);
                c1.set_color(color.Text);

                scope_display.Text = "Result :\n" + c1.scope_calculator();
                area_display.Text = "Result :\n" + c1.area_calculator();

            }
            else
                MessageBox.Show("ערכים שליליים או 0");
        }

        private void move_center_Click(object sender, EventArgs e)//כפתור להזזת מעגל
        {
            //בדיקה אם הערכים לא שליליים
            if (move_centerX.Value >= 0 && move_centerY.Value >= 0)
            {
                int mx = Convert.ToInt32(move_centerX.Value);
                int my = Convert.ToInt32(move_centerY.Value);

                c1.set_centerX(mx + c1.get_centerX());
                c1.set_centerY(my + c1.get_centerY());
            }
            else
                MessageBox.Show("ערכים שליליים");
        }

        private void check_point_Click(object sender, EventArgs e)//בדיקה אם הנקודה שהתקבלה נמצאת במעגל
        {
            //בדיקה אם הערכים לא שליליים
            if (checkX.Value > 0 && checkY.Value > 0)
            {
                int cx = Convert.ToInt32(checkX.Value);
                int cy = Convert.ToInt32(checkY.Value);

                check_display.Text= ""+c1.check_point_on_line(cx, cy);
            }
            else
                MessageBox.Show("ערכים שליליים");
        }

        private void toString_Click(object sender, EventArgs e)//to string circle
        {
            toString_dispaly.Text = "Center (" + c1.get_centerX() + "," + c1.get_centerY() + ")\nRadius : " + c1.get_radius();
        }

       

        private void insert_point_Click(object sender, EventArgs e)//כפתור לקבלת נקודות למצולע
        {
            //בדיקה אם הערכים לא שליליים
            if (polygon_thick.Value > 0 && polygon_pointX.Value > 0 && polygon_pointY.Value > 0)
            {
                int px = Convert.ToInt32(polygon_pointX.Value);
                int py = Convert.ToInt32(polygon_pointY.Value);

                //אם מספר הנקודות הגיע למספר הנקבע
                if(poly1.get_numOfPoints()==5)
                {
                    panel7.Show();
                    panel8.Show();
                    panel9.Show();
                    MessageBox.Show("מצולע הושלם ");
                    scope_polygon_display.Text = "Result :\n" + poly1.scope_polygon();
                }

                //אם לא ממשיכים להוסיף נקודות
                else
                {
                    poly1.set_polygonX(px);
                    poly1.set_polygonY(py);
                    poly1.set_numOfPoints(poly1.get_numOfPoints()+1);
                    points_amount_display.Text = "Point :" + poly1.get_numOfPoints();
                }

            }
            else
                MessageBox.Show("ערכים שליליים או 0");
        }

        private void button3_Click(object sender, EventArgs e)//TO STRING POLYGON
        {
            toString_polygon_dispaly.Text = ""+poly1.ToString_polygon();
        }

        private void polygon_move_points_Click(object sender, EventArgs e)//כפתור להזזת מצולע
        {

            //בדיקה אם הערכים לא שליליים
            if (polygon_moveX.Value >= 0 && polygon_moveY.Value >= 0)
            {
                int x = Convert.ToInt32(polygon_moveX.Value);
                int y = Convert.ToInt32(polygon_moveY.Value);

                poly1.move_points_polygon(x, y);
            }
            else
                MessageBox.Show("ערכים שליליים");
        }

        private void accept_line2_Click(object sender, EventArgs e)
        {
            //בדיקה אם הערכים לא שליליים
            if (sx.Value > 0 && sy.Value > 0 && ex.Value > 0 && ey.Value > 0 && thick.Value > 0)
            {
                panel1.Show();
                panel2.Show();
                panel3.Show();

                int Sx = Convert.ToInt32(sx.Value);
                int Sy = Convert.ToInt32(sy.Value);
                int Ex = Convert.ToInt32(ex.Value);
                int Ey = Convert.ToInt32(ey.Value);
                int Thick = Convert.ToInt32(thick.Value);

                p2.set_startX(Sx);
                p2.set_startY(Sy);
                p2.set_endX(Ex);
                p2.set_endY(Ey);
                p2.set_thick(Thick);
                p2.set_color(color_box.Text);


            }
            else
                MessageBox.Show(" ערכים שלילים או 0");
        }

        private void check_eqauls_Click(object sender, EventArgs e)
        {
            equals_display_line.Text = "Equals : " + p1.Equals(p2);
        }

        private void accept_circle2_Click(object sender, EventArgs e)
        {
            
            //בדיקה אם הערכים לא שליליים
            if (centerX.Value > 0 && centerY.Value > 0 && thick_line.Value > 0 && raduis.Value > 0)
            {
                panel4.Show();
                panel5.Show();
                panel6.Show();

                int x = Convert.ToInt32(centerX.Value);
                int y = Convert.ToInt32(centerY.Value);
                int thick = Convert.ToInt32(thick_line.Value);
                int Raduis = Convert.ToInt32(raduis.Value);

                c2.set_centerX(x);
                c2.set_centerY(y);
                c2.set_radius(Raduis);
                c2.set_thick(thick);
                c2.set_color(color.Text);

                

            }
            else
                MessageBox.Show("ערכים שליליים או 0");
        }

        private void equals_Click(object sender, EventArgs e)
        {
            equals_dispaly.Text = "Equals : " + c1.Equals(c2);
        }

        private void accept_polygon2_Click(object sender, EventArgs e)
        {
            //בדיקה אם הערכים לא שליליים
            if (polygon_thick.Value > 0 && polygon_pointX.Value > 0 && polygon_pointY.Value > 0)
            {
                int px = Convert.ToInt32(polygon_pointX.Value);
                int py = Convert.ToInt32(polygon_pointY.Value);

                //אם מספר הנקודות הגיע למספר הנקבע
                if (poly2.get_numOfPoints() == 5)
                {
                    panel7.Show();
                    panel8.Show();
                    panel9.Show();
                    MessageBox.Show("מצולע הושלם ");
                    scope_polygon_display.Text = "Result :\n" + poly2.scope_polygon();
                }

                //אם לא ממשיכים להוסיף נקודות
                else
                {
                    poly2.set_polygonX(px);
                    poly2.set_polygonY(py);
                    poly2.set_numOfPoints(poly2.get_numOfPoints() + 1);
                    poibts_amount2.Text = "Point :" + poly2.get_numOfPoints();
                }

            }
            else
                MessageBox.Show("ערכים שליליים או 0");
        }

        private void equals_polygon_Click(object sender, EventArgs e)
        {
            equals_display_polygon.Text = "Equals : " + poly1.Equals(poly2);
        }

        private void sort_circle_Click(object sender, EventArgs e)
        {
            Array.Sort(arr);

            sort_display_circle.Text = "";

            for (int i = 0; i < 5; i++)
            {
                sort_display_circle.Text += "Ciecle " + (i + 1) + " : " + arr[i].get_radius() + "\n";
            }
        }

        private void sort_polygon_Click(object sender, EventArgs e)
        {
            Array.Sort(arrP);
            sort_display_polygon.Text = "";

            for (int i = 0; i < 5; i++)
            {
                sort_display_polygon.Text += "Polygon " + (i + 1) + " : " + arrP[i].scope_polygon() + "\n";
            }
        }

    }  
    
}
