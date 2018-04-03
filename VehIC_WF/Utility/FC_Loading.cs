using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;

namespace VehIC_WF.Utility
{
    public partial class FC_Loading : UserControl
    {         
        //private Bitmap animatedGif = global::Properties.Resources.loading; //new Bitmap("");
        //private int x;
        //private int y;
        //private FrameDimension frameDimension;
        //private int frameDimensionCount;
        //private int[] delays;

        public FC_Loading()
        {
            InitializeComponent();

            //x = (this.Width - animatedGif.Width) / 2;
            //y = (this.Height - animatedGif.Height) / 2;

            //int PropertyTagFrameDelay = 0x5100;
            //PropertyItem propItem = animatedGif.GetPropertyItem(PropertyTagFrameDelay);
            //byte[] bytes = propItem.Value;
            //// Get the frame count for the Gif...
            //frameDimension = new FrameDimension(animatedGif.FrameDimensionsList[0]); 
            //frameDimensionCount= animatedGif.GetFrameCount(frameDimension);
           
            //int frameCount = animatedGif.GetFrameCount(FrameDimension.Time);
          
            //delays = new int[frameCount + 1];
            //int i = 0;
            //for (i = 0; i <= frameCount - 1; i++)
            //{
            //    delays[i] = BitConverter.ToInt32(bytes, i * 4);
            //}

        }

        //private bool isplay = false;
        //private int i = 0;
  
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    animatedGif.SelectActiveFrame(frameDimension, i);
        //    if (i < frameDimensionCount - 1) i++;
        //    else i = 0;
        //    e.Graphics.DrawImage(animatedGif, new Point(x, y));
        //}


        //public void Play()
        //{
        //    //new Thread(new ThreadStart(() =>
        //    //{
        //    //    try
        //    //    {
        //    //        isplay = true;
        //    //        while (isplay)
        //    //        {
   
        //    //            Application.DoEvents();
        //    //            if (!isplay) break;
        //    //            Thread.Sleep(delays[i] * 10);
        //    //        }
        //    //    }catch{}
        //    //})).Start();
        //}

        //public void Stop()
        //{
        //    isplay = false;
        //}

        ////首先定义私有变量 
        //private Image m_img=null;
        //private EventHandler evtHandler=null;
        ////重载的当前winform的OnPaint方法，当界面被重绘时去显示当前gif显示某一帧
        //protected override void OnPaint(PaintEventArgs e){   
        //    base.OnPaint(e);    
        //    if (m_img != null)    {    
        //        //获得当前gif动画下一步要渲染的帧。        
        //        UpdateImage();        
        //        //将获得的当前gif动画需要渲染的帧显示在界面上的某个位置。     
        //        e.Graphics.DrawImage(m_img, new Rectangle(145, 140, m_img.Width, m_img.Height));
        //    }}
        ////实现Load方法
        //private void FC_Loading_Load(object sender, EventArgs e)
        //{ 
        //    //为委托关联一个处理方法    
        //    evtHandler=new EventHandler(OnImageAnimate); 
        //    //获取要加载的gif动画文件   
        //    m_img = global::Properties.Resources.loading;//Image.FromFile(Application.StartupPath+"\\loading.gif"); 
        //    //调用开始动画方法   
        //    BeginAnimate();
        //}//开始动画方法
        //private void BeginAnimate(){    
        //    if(m_img!=null)   
        //    {      
        //        //当gif动画每隔一定时间后，都会变换一帧，那么就会触发一事件，该方法就是将当前image每变换一帧时，都会调用当前这个委托所关联的方法。       
        //        ImageAnimator.Animate(m_img,evtHandler);    
        //    }}
        ////委托所关联的方法
        //private void OnImageAnimate(Object sender, EventArgs e){   
        //    //该方法中，只是使得当前这个winfor重绘，然后去调用该winform的 OnPaint（）方法进行重绘)    
        //    this.Invalidate();
        //}
        ////获得当前gif动画的下一步需要渲染的帧，当下一步任何对当前gif动画的操作都是对该帧进行操作)
        //private void UpdateImage(){
        //    ImageAnimator.UpdateFrames(m_img);
        //}
        ////关闭显示动画，该方法可以在winform关闭时，或者某个按钮的触发事件中进行调用，以停止渲染当前gif动画。
        //private void StopAnimate(){
        //    m_img = null;
        //    ImageAnimator.StopAnimate(m_img, evtHandler);
        //}

        
    }
}
