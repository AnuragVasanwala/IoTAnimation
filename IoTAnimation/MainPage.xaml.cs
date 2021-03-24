using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IoTAnimation
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        
        // Executes when Fade button is clicked
        private void Btn_FadeImage_Click(object sender, RoutedEventArgs e)
        {
            /*
            // Step 1:  Create DoubleAnimation object and change its properties
            //          DoubleAnimation deals with the doubl datatype so its called
            DoubleAnimation _OpacityAnimation = new DoubleAnimation();
            _OpacityAnimation.From = 1;     // Opacity varies from 0.0 -> 1.0 | etc 0.5 is half opacity
            _OpacityAnimation.To = 0;       // 0 is full opac
            _OpacityAnimation.AutoReverse = true;       // ebables auto reverse animation
            
            // Extra Properties : Uncomment following three lines to see difference
            // TimeSpan _TimeSpan = TimeSpan.FromSeconds(5);
            // _OpacityAnimation.Duration = _TimeSpan;
            // _OpacityAnimation.RepeatBehavior = RepeatBehavior.Forever;
            
            // Step 2: Create storyboard object and add DoubleAnimation object as its chield
            Storyboard _Storyboard = new Storyboard();
            _Storyboard.Children.Add(_OpacityAnimation);

            // Step 3: Spesify on which property animation is going to be done by DoubleAnimatin obj
            Storyboard.SetTargetProperty(_OpacityAnimation, "Opacity");

            // Step 4: Spesify on which control story board is to be attached
            Storyboard.SetTarget(_Storyboard, Img_RaspberryPi);

            // Step 5: Start storyboard and see magic!
            _Storyboard.Begin();
            */

            StartDoubleAnimation(Img_RaspberryPi, "Opacity",1,0);

            // Or even can be written as
            // StartDoubleAnimation(Img_RaspberryPi, "Image.Opacity",1,0);
        }

        // Executes when Rotate button is clicked
        private void Btn_RotateImage_Click(object sender, RoutedEventArgs e)
        {
            /*
            // Step 1:  Create DoubleAnimation object and change its properties
            //          DoubleAnimation deals with the doubl datatype so its called
            DoubleAnimation _OpacityAnimation = new DoubleAnimation();
            _OpacityAnimation.From = 0;     // Opacity varies from 0.0 -> 1.0 | etc 0.5 is half opacity
            _OpacityAnimation.To = 360;       // 0 is full opac
            _OpacityAnimation.AutoReverse = true;       // ebables auto reverse animation

            // Extra Properties : Uncomment following three lines to see difference
            TimeSpan _TimeSpan = TimeSpan.FromSeconds(5);
            _OpacityAnimation.Duration = _TimeSpan;
            // _OpacityAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Step 2: Create storyboard object and add DoubleAnimation object as its chield
            Storyboard _Storyboard = new Storyboard();
            _Storyboard.Children.Add(_OpacityAnimation);

            // Step 3: Spesify on which property animation is going to be done by DoubleAnimatin obj
            Storyboard.SetTargetProperty(_OpacityAnimation, "Rotation");

            // Step 4: Spesify on which control story board is to be attached
            Storyboard.SetTarget(_Storyboard, Img_RaspberryPi_CompositeTransform);

            // Step 5: Start storyboard and see magic!
            _Storyboard.Begin();
            */

            StartDoubleAnimation(Img_RaspberryPi_CompositeTransform, "Rotation",0,359,4);

            // Or even can be written as
            // StartDoubleAnimation(Img_RaspberryPi_CompositeTransform, "CompositeTransform.Rotation",0,359,4);
        }

        // Executes when ProjectionX button is clicked
        private void Btn_ProjectionX_Click(object sender, RoutedEventArgs e)
        {
            /*
                We are going to animate property RotationX of PlaneProjection
                so complete DependencyProperty string will be: PlaneProjection.RotationX
            */

            string _DependencyProperty = "PlaneProjection." + nameof(PlaneProjection.RotationX); // PlaneProjection.RotationX
            StartDoubleAnimation(Img_RaspberryPi_PlaneProjection, _DependencyProperty, 0, 359, 5);
        }

        // Executes when ProjectionY button is clicked
        private void Btn_ProjectionY_Click(object sender, RoutedEventArgs e)
        {
            /*
                We are going to animate property RotationY of PlaneProjection
                so complete DependencyProperty string will be: PlaneProjection.RotationY
            */

            string _DependencyProperty = "PlaneProjection." + nameof(PlaneProjection.RotationY);  // PlaneProjection.RotationY
            StartDoubleAnimation(Img_RaspberryPi_PlaneProjection, _DependencyProperty, 0, 359, 6);
        }

        // Executes when ProjectionZ button is clicked
        private void Btn_ProjectionZ_Click(object sender, RoutedEventArgs e)
        {
            /*
                We are going to animate property RotationZ of PlaneProjection
                so complete DependencyProperty string will be: PlaneProjection.RotationZ
            */

            string _DependencyProperty = "PlaneProjection." + nameof(PlaneProjection.RotationZ);  // PlaneProjection.RotationZ
            StartDoubleAnimation(Img_RaspberryPi_PlaneProjection, _DependencyProperty, 0, 359, 2);
        }

        // Executes when Colorize button is clicked
        private void Btn_ColorizeImage_Click(object sender, RoutedEventArgs e)
        {
            /*
                Here the string "(Grid.Background).(SolidColorBrush.Color)" means
                
                Datatype of '(Grid.Background)' is SolidColorBrush
                Now again 'SolidColorBrush' is a class contains 'Color' structure
                so complete string will be "(Grid.Background).(SolidColorBrush.Color)"
            */
            
            StartColorAnimation(Grd_Main, "(Grid.Background).(SolidColorBrush.Color)", Color.FromArgb(255, 255, 192, 203), Color.FromArgb(255, 69, 97, 228));
        }

        /// <summary>
        /// Provides animation capability for Double property
        /// </summary>
        /// <param name="_Control">Control to be animate</param>
        /// <param name="_Property">Dependency property to be animate</param>
        /// <param name="_From">Start animation from</param>
        /// <param name="_To">Stop animation at</param>
        /// <param name="_TimeSpanInSecond">Time span in second</param>
        private void StartDoubleAnimation(DependencyObject _Control, string _Property, double _From, double _To, double _TimeSpanInSecond = 1)
        {
            // Step 1:  Create DoubleAnimation object and change its properties
            //          DoubleAnimation deals with the doubl datatype so its called
            DoubleAnimation _OpacityAnimation = new DoubleAnimation();
            _OpacityAnimation.From = _From;
            _OpacityAnimation.To = _To;
            _OpacityAnimation.AutoReverse = true;       // ebables auto reverse animation

            // Extra Properties : Uncomment following three lines to see difference
            TimeSpan _TimeSpan = TimeSpan.FromSeconds(_TimeSpanInSecond);
            _OpacityAnimation.Duration = _TimeSpan;
            // _OpacityAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Step 2: Create storyboard object and add DoubleAnimation object as its chield
            Storyboard _Storyboard = new Storyboard();
            _Storyboard.Children.Add(_OpacityAnimation);

            // Step 3: Spesify on which property animation is going to be done by DoubleAnimatin obj
            Storyboard.SetTargetProperty(_OpacityAnimation, _Property);

            // Step 4: Spesify on which control story board is to be attached
            Storyboard.SetTarget(_Storyboard, _Control);

            // Step 5: Start storyboard and see magic!
            _Storyboard.Begin();
        }

        /// <summary>
        /// Provides animation capability for Color property
        /// </summary>
        /// <param name="_Control">Control to be animate</param>
        /// <param name="_Property">Dependency property to be animate</param>
        /// <param name="_From">Start animation from color</param>
        /// <param name="_To">Stop animation at color</param>
        /// <param name="_TimeSpanInSecond">Time span in second</param>
        private void StartColorAnimation(DependencyObject _Control, string _Property, Windows.UI.Color _From, Windows.UI.Color _To, double _TimeSpanInSecond = 1)
        {
            // Step 1:  Create ColorAnimation object and change its properties
            //          ColorAnimation deals with the Windows.UI.Color type so its called
            ColorAnimation _OpacityAnimation = new ColorAnimation();
            _OpacityAnimation.From = _From;
            _OpacityAnimation.To = _To;
            _OpacityAnimation.AutoReverse = true;       // ebables auto reverse animation

            // Extra Properties : Uncomment following three lines to see difference
            TimeSpan _TimeSpan = TimeSpan.FromSeconds(_TimeSpanInSecond);
            _OpacityAnimation.Duration = _TimeSpan;
            // _OpacityAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Step 2: Create storyboard object and add DoubleAnimation object as its chield
            Storyboard _Storyboard = new Storyboard();
            _Storyboard.Children.Add(_OpacityAnimation);

            // Step 3: Spesify on which property animation is going to be done by DoubleAnimatin obj
            Storyboard.SetTargetProperty(_OpacityAnimation, _Property);

            // Step 4: Spesify on which control story board is to be attached
            Storyboard.SetTarget(_Storyboard, _Control);

            // Step 5: Start storyboard and see magic!
            _Storyboard.Begin();
        }

    }
}
