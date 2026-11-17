using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace HR_MS
{
  
    public partial class Adjest : Form
    {
        
     List<Size>   InitialSize = new List<Size>();
     List<Point> Locations = new List<Point>();
         List<int>   Fonts = new List<int>();
          List<Size>  ChildInitialSize = new List<Size>();
          List<Point>  ChildLocation = new List<Point>();
        List<int>    ChildFont = new List<int>();
        List<Size> TapPageControlSize = new List<Size>();
        List<Point> TapPageControlLocation = new List<Point>();
        List<int> TapPageControlFont = new List<int>();
        List<MyCotainers> MyContainer = new List<MyCotainers>();


        int width;
        int height;

        public Adjest()
        {
            InitializeComponent();
           
          
        }

        void Auto_Resize(object sender, EventArgs e)
        {
            for (int index = 0; index < MyContainer.Count; index++)
            {
                if (((Control)sender).Name == MyContainer[index].ContainerName)
                {
                    for (int cindex = 0; cindex < ((Control)sender).Controls.Count; cindex++)
                    {
                        ((Control)sender).Controls[cindex].Size = new Size(Convert.ToInt32(MyContainer[index].ChildSize[cindex].Width * this.Size.Width / this.width), Convert.ToInt32(MyContainer[index].ChildSize[cindex].Height * this.Size.Height / this.height));
                        ((Control)sender).Controls[cindex].Location = new Point(Convert.ToInt32(MyContainer[index].ChildLocation[cindex].X * this.Size.Width / this.width), Convert.ToInt32(MyContainer[index].ChildLocation[cindex].Y * this.Size.Height / this.height));
                    }
                }
            }
            //for (int index = 0; index < ((Control)sender).Controls.Count; index++)
            //{
                //if (((Control)sender).GetType().Name == "TabControl")
                //{
                //    for (int TapPageIndex = 0; TapPageIndex < ((TabControl)sender).Controls[index].Controls.Count; TapPageIndex++)
                //    {
                //        ((TabControl)sender).Controls[index].Controls[TapPageIndex].Size = new Size(Convert.ToInt32(TapPageControlSize[index].Width * ((TabControl)sender).Controls[index].Controls[TapPageIndex].Size.Width / ((TabControl)sender).Controls[index].Width), Convert.ToInt32(TapPageControlSize[index].Height * ((TabControl)sender).Controls[index].Controls[TapPageIndex].Size.Height / ((TabControl)sender).Controls[index].Height));
                //        ((TabControl)sender).Controls[index].Controls[TapPageIndex].Location = new Point(Convert.ToInt32(TapPageControlLocation[index].X * ((TabControl)sender).Controls[index].Controls[TapPageIndex].Size.Width / ((TabControl)sender).Controls[index].Width), Convert.ToInt32(TapPageControlLocation[index].Y * ((TabControl)sender).Controls[index].Controls[TapPageIndex].Size.Height / ((TabControl)sender).Controls[index].Height));
                //        ((TabControl)sender).Controls[index].Controls[TapPageIndex].Font = new Font(((Control)sender).Controls[index].Font.Name, Convert.ToInt32(TapPageControlFont[index] * this.Size.Width / ((TabControl)sender).Size.Width), ((Control)sender).Controls[index].Font.Style);
                //    }
                //}
                //else
                
                    //((Control)sender).Controls[index].Size = new Size(Convert.ToInt32(ChildInitialSize[index].Width * this.Size.Width / this.width), Convert.ToInt32(ChildInitialSize[index].Height * this.Size.Height / this.height));
                    //((Control)sender).Controls[index].Location = new Point(Convert.ToInt32(ChildLocation[index].X * this.Size.Width / this.width), Convert.ToInt32(ChildLocation[index].Y * this.Size.Height / this.height));
                    //((Control)sender).Controls[index].Font = new Font(((Control)sender).Controls[index].Font.Name, Convert.ToInt32(ChildFont[index]), ((Control)sender).Controls[index].Font.Style);
                    //}* this.Size.Width / this.width
                    //this.ChildInitialSize.RemoveAt(index);
                    //this.ChildLocation.RemoveAt(index);
                //}

            }

        void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {

            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            for (int index = 0; index < this.Controls.Count; index++)
            {
                this.Controls[index].Size = new Size(Convert.ToInt32(InitialSize[index].Width * this.Size.Width / this.width), Convert.ToInt32(InitialSize[index].Height * this.Size.Height / this.height));
                this.Controls[index].Location = new Point(Convert.ToInt32(Locations[index].X * this.Size.Width / this.width), Convert.ToInt32(Locations[index].Y * this.Size.Height / this.height));
                this.Controls[index].Font = new Font(this.Controls[index].Font.Name, Convert.ToInt32(Fonts[index]), this.Controls[index].Font.Style);
            }

        }

        private void Adjest_Load(object sender, EventArgs e)
        {
            //if (this.IsMdiChild)
            //{
            //    width = this.MdiParent.Width;
            //    height = this.MdiParent.Height;
            //}
            //else
            //{
                width = this.Size.Width;
                height = this.Size.Height;
            //}

            foreach (Control Ctrl in this.Controls)
            {
                MyCotainers myContainer = new MyCotainers();
                //Form frm = ((frmMain)Application.OpenForms["frmMain"]);
                //var Chiledrn = this.MdiParent.MdiChildren;
                //Size CotrolSize = new Size(Ctrl.Size.Width * this.Size.Width / this.width, Ctrl.Size.Height * this.Size.Height / this.height);
                //Point ControlLocation = new Point((frm.MdiChildren[Array.IndexOf(Chiledrn, this)].Controls[Ctrl.Name].Location.X), (frm.MdiChildren[Array.IndexOf(Chiledrn, this)].Controls[Ctrl.Name].Location.Y));
                
                 InitialSize.Add(Ctrl.Size);
                 Locations.Add(Ctrl.Location);
                 myContainer.ContainerName = Ctrl.Name;
                Fonts.Add(Convert.ToInt32(Ctrl.Font.Size));
                //if (Ctrl.GetType().Name.ToString() == "TabControl")
                //{
                //    ((TabControl)Ctrl).SizeChanged += new EventHandler(Auto_Resize);
                //    foreach (TabPage ChildCtrl in Ctrl.Controls)
                //        {
                //            for (int j = 0; j < ((TabPage)ChildCtrl).Controls.Count; j++)
                //            {
                //                TapPageControlSize.Add(ChildCtrl.Controls[j].Size);
                //                TapPageControlLocation.Add(ChildCtrl.Controls[j].Location);
                //                TapPageControlFont.Add(Convert.ToInt32(ChildCtrl.Controls[j].Font.Size));
                //            }
                //    }
                //}
                if (Ctrl.GetType().Name.ToString() == "Panel" || Ctrl.GetType().Name.ToString() == "GroupBox")
                {
                    Ctrl.Resize += new EventHandler(Auto_Resize);
                    for (int j = 0; j < ((Control)Ctrl).Controls.Count; j++)
                    {
                        myContainer.ChildSize.Add(Ctrl.Controls[j].Size);
                        myContainer.ChildLocation.Add(Ctrl.Controls[j].Location);
                        //ChildInitialSize.Add(Ctrl.Controls[j].Size);
                        //ChildLocation.Add(Ctrl.Controls[j].Location);
                        //ChildFont.Add(Convert.ToInt32(Ctrl.Controls[j].Font.Size));
                    }
                    MyContainer.Add(myContainer);
                }

            }
         
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += new
            EventHandler(SystemEvents_DisplaySettingsChanged);
        }

        private void Adjest_Resize(object sender, EventArgs e)
        {
            //if (this.IsMdiChild)
            //{
            //    for (int index = 0; index < InitialSize.Count; index++)
            //    {
            //        this.Controls[index].Size = new Size(Convert.ToInt32(InitialSize[index].Width * this.Size.Width / this.width), Convert.ToInt32(InitialSize[index].Height * this.Size.Height / this.height));
            //        this.Controls[index].Location = new Point(Convert.ToInt32(Location[index].X * this.Size.Width / this.width), Convert.ToInt32(Location[index].Y * this.Size.Height / this.height));
            //        this.Controls[index].Font = new Font(this.Controls[index].Font.Name, Convert.ToInt32(Font[index]), this.Controls[index].Font.Style);
            //    }
            //}
            //else
            //{
                for (int index = 0; index < InitialSize.Count; index++)
                {
                    this.Controls[index].Size = new Size(Convert.ToInt32(InitialSize[index].Width * this.Size.Width / this.width), Convert.ToInt32(InitialSize[index].Height * this.Size.Height / this.height));
                    this.Controls[index].Location = new Point(Convert.ToInt32(Locations[index].X * this.Size.Width / this.width), Convert.ToInt32(Locations[index].Y * this.Size.Height / this.height));
                    this.Controls[index].Font = new Font(this.Controls[index].Font.Name, Convert.ToInt32(Fonts[index]), this.Controls[index].Font.Style);
                }
            //}
        }
        
    }
 }
