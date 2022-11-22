using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TestTriangle.StaticProperty;

namespace TestTriangle.Extensions
{
    /// <summary>
    /// Logika interakcji dla klasy AnimMove.xaml
    /// </summary>
    public partial class AnimMove : Page
    {
        private ChosenAnim layout;
        public Animations animation_set;
        public AnimMove()
        {
            InitializeComponent();
            AnimationThreading._tokenSource = null;
            this.animation_set = new Animations();
        }
        private void ChooseAnim1(object sender, MouseEventArgs e)
        {
            if(layout==null)
            {
                this.layout = new ChosenAnim(this.anim1bord, this.anim1img,this.animation_set.Anim1);
                return;
            }
            if (this.layout.Equals(new ChosenAnim(this.anim1bord, this.anim1img, this.animation_set.Anim1)))
                return;
            this.layout.SetNewAnimation(this.anim1bord, this.anim1img, this.animation_set.Anim1);
        }
        private void ChooseAnim2(object sender, MouseEventArgs e)
        {
            if (layout == null)
            {
                this.layout = new ChosenAnim(this.anim2bord, this.anim2img, this.animation_set.Anim2);
                return;
            }
            if (this.layout.Equals(new ChosenAnim(this.anim2bord, this.anim2img, this.animation_set.Anim2)))
                return;
            this.layout.SetNewAnimation(this.anim2bord, this.anim2img, this.animation_set.Anim2);
        }
        private void ChooseAnim3(object sender, MouseEventArgs e)
        {
            if (layout == null)
            {
                this.layout = new ChosenAnim(this.anim3bord, this.anim3img, this.animation_set.Anim3);
                return;
            }
            if (this.layout.Equals(new ChosenAnim(this.anim3bord, this.anim3img, this.animation_set.Anim3)))
                return;
            this.layout.SetNewAnimation(this.anim3bord, this.anim3img, this.animation_set.Anim3);
        }
        private void ChooseAnim4(object sender, MouseEventArgs e)
        {
            if (layout == null)
            {
                this.layout = new ChosenAnim(this.anim4bord, this.anim4img, this.animation_set.Anim4);
                return;
            }
            if (this.layout.Equals(new ChosenAnim(this.anim4bord, this.anim4img, this.animation_set.Anim4)))
                return;
            this.layout.SetNewAnimation(this.anim4bord, this.anim4img, this.animation_set.Anim4);
        }
        private void ChooseAnim5(object sender, MouseEventArgs e)
        {
            if (layout == null)
            {
                this.layout = new ChosenAnim(this.anim5bord, this.anim5img, this.animation_set.Anim5);
                return;
            }
            if (this.layout.Equals(new ChosenAnim(this.anim5bord, this.anim5img, this.animation_set.Anim5)))
                return;
            this.layout.SetNewAnimation(this.anim5bord, this.anim5img, this.animation_set.Anim5);
        }
        private void ChooseAnim6(object sender, MouseEventArgs e)
        {
            if (layout == null)
            {
                this.layout = new ChosenAnim(this.anim6bord, this.anim6img, this.animation_set.Anim1);
                return;
            }
            if (this.layout.Equals(new ChosenAnim(this.anim6bord, this.anim6img, this.animation_set.Anim1)))
                return;
            this.layout.SetNewAnimation(this.anim6bord, this.anim6img, this.animation_set.Anim1);
        }
        private void AnimationZoom_Click(object sender, RoutedEventArgs e)
        {
            OBJProperty.zoom = 0.65;
            DrawTool.ClearImage();
            DrawTool.readedItem.Paint();
        }

        private bool play = false;
        private void PlayAnimation(object sender, MouseEventArgs e)
        {
            if(this.play == false)
            {
                if (this.layout == null)
                {
                    MessageBox.Show("Choose animation to play", "Animation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                    
                this.play = true;
                BitmapImage image = new BitmapImage(new Uri("/TestTriangle;component/Pictures/Worksheet/ENV/PAUSE.png", UriKind.Relative));
                this.PlayButton.Source = image;
                AnimationThreading.RunAnimation(this.layout.animation);
            }
            else
            {
                BitmapImage image = new BitmapImage(new Uri("/TestTriangle;component/Pictures/Worksheet/ENV/PLAY.png", UriKind.Relative));
                this.PlayButton.Source = image;
                this.play = false;
                AnimationThreading.CancelAnimation();
            }
        }
    }
    public class ChosenAnim : ChosenLayout
    {
        public Action<CancellationToken> animation;
        SolidColorBrush select;
        SolidColorBrush unselect;
        public ChosenAnim(Border b, Image i, Action<CancellationToken> anim) : base(b, i)
        {
            this.select = new SolidColorBrush(Color.FromRgb(254, 164, 6));
            this.unselect = Brushes.White;
            this.animation = anim;
            this.border.BorderBrush = this.select;
        }
        public void SetNewAnimation(Border b, Image i, Action<CancellationToken> anim)
        {
            this.OFFPrevious();
            this.image = i;
            this.animation = anim;
            this.border = b;
            this.ONCurrent();
        }
        protected new void OFFPrevious()
        {
            this.border.BorderBrush = unselect;
        }
        protected new void ONCurrent()
        {
            this.border.BorderBrush = select;
        }
    }
    public class Animations
    {
        public async void Anim1(CancellationToken token) // rotate by x axis [-90, 90] degree!
        {
            for (int move = 10 ; ;move+=4 )
            {
                var watch = Stopwatch.StartNew();
                await DrawTool.page.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var t = new Thread(() => DrawTool.readedItem.AroundYaxis(Trigonometry.ForAnim(move)));
                    t.Start();
                    DrawTool.ClearImage();
                    t.Join();
                    DrawTool.readedItem.Paint();
                }));
                watch.Stop();
                var time = watch.ElapsedMilliseconds;
                await DrawTool.page.Dispatcher.BeginInvoke(new Action(()=>DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}"));
                if (token.IsCancellationRequested)
                {
                    DrawTool.readedItem.SetVertsxyz();
                    return;
                }
                Thread.Sleep(2);
            }
        }
        public async void Anim2(CancellationToken token)
        {
            for (int move = 10; ; move += 4)
            {
                var watch = Stopwatch.StartNew();
                await DrawTool.page.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var t = new Thread(() => DrawTool.readedItem.AroundXaxis(Trigonometry.ForAnim(move)));
                    t.Start();
                    DrawTool.ClearImage();
                    t.Join();
                    DrawTool.readedItem.Paint();
                }));
                watch.Stop();
                var time = watch.ElapsedMilliseconds;
                await DrawTool.page.Dispatcher.BeginInvoke(new Action(() => DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}"));
                if (token.IsCancellationRequested)
                {
                    DrawTool.readedItem.SetVertsxyz();
                    return;
                }
                Thread.Sleep(2);
            }
        }
        public async void Anim3(CancellationToken token)
        {
            await DrawTool.page.Dispatcher.BeginInvoke(new Action(() => Light.Rchange(1)));
            for (int move = 10; ; move += 3)
            {
                var watch = Stopwatch.StartNew();
                await DrawTool.page.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var t = new Thread(() => Light.Rotate(Trigonometry.ForMove(move)));
                    t.Start();
                    DrawTool.ClearImage();
                    t.Join();
                    DrawTool.readedItem.Paint();
                }));
                watch.Stop();
                var time = watch.ElapsedMilliseconds;
                await DrawTool.page.Dispatcher.BeginInvoke(new Action(() => DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}"));
                if (token.IsCancellationRequested)
                {
                    Light.possition.setxyz();
                    return;
                }
                Thread.Sleep(2);
            }
        }
        public async void Anim4(CancellationToken token)
        {
            float R = (float)0.2;
            float Rchange = (float)0.01;
            float z =(float) 1.2;
            float zchange = (float)-0.005;
            await DrawTool.page.Dispatcher.BeginInvoke(new Action(() => Light.Rchange((float)R)));
            Light.possition.z = z;
            double move = 3;
            for (; ; )
            {
                var watch = Stopwatch.StartNew();
                await DrawTool.page.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var t = new Thread(() => Light.Rotate(Trigonometry.ForMove(move)));
                    t.Start();
                    DrawTool.ClearImage();
                    t.Join();
                    R += Rchange;
                    z += zchange;
                    Light.Rchange(R);
                    Light.possition.z = z;
                    if (z < 0.5 || z>1.2)
                        zchange *= -1;
                    if (R < 0.2 || R > 1.5)
                        Rchange *= -1;
                    DrawTool.readedItem.Paint();
                }));
                watch.Stop();
                var time = watch.ElapsedMilliseconds;
                await DrawTool.page.Dispatcher.BeginInvoke(new Action(() => DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}"));
                if (token.IsCancellationRequested)
                {
                    Light.possition.setxyz();
                    return;
                }
                Thread.Sleep(2);
            }
        }
        public async void Anim5(CancellationToken token)
        {
            await DrawTool.page.Dispatcher.BeginInvoke(new Action(() => Light.Rchange(1)));
            for (int move = 10; ; move += 3)
            {
                var watch = Stopwatch.StartNew();
                await DrawTool.page.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var t = new Thread(() => Light.Rotate(Trigonometry.ForMove(move)));
                    var t1 = new Thread(() => DrawTool.readedItem.AroundYaxis(Trigonometry.ForAnim(move)));
                    t.Start();
                    t1.Start();
                    DrawTool.ClearImage();
                    t.Join();
                    t1.Join();
                    DrawTool.readedItem.Paint();
                }));
                watch.Stop();
                var time = watch.ElapsedMilliseconds;
                await DrawTool.page.Dispatcher.BeginInvoke(new Action(() => DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}"));
                if (token.IsCancellationRequested)
                {
                    Light.possition.setxyz();
                    return;
                }
                Thread.Sleep(4);
            }
        }
    }
    static class AnimationThreading
    {
        public static Task work;
        public static CancellationTokenSource _tokenSource;
        public static void RunAnimation(Action<CancellationToken> animation)
        {
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;
            work = new Task(() => animation(token));
            AnimationThreading.work.Start();
        }
        public static void CancelAnimation()
        {
            if(_tokenSource!=null)
                _tokenSource.Cancel();
            _tokenSource = null;
            work = null;
        }
    }
}
