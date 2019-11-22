using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rainbow {

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private bool _isCompleted = false;

        private void Button_MouseEnter(object sender, MouseEventArgs e) {

            if (!_isCompleted) {

                _isCompleted = true;

                DoubleAnimation animation = new DoubleAnimation {

                    Duration = new Duration(TimeSpan.FromSeconds(5)),
                    From = 0,
                    To = 360,
                    RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(30))
                };

                animation.Completed += Animation_Completed;

                RotateTransform rotate = new RotateTransform();
                btn.RenderTransformOrigin = new Point(0.5, 0.5);
                btn.RenderTransform = rotate;

                rotate.BeginAnimation(RotateTransform.AngleProperty, animation);

            }
        }

        private void Animation_Completed(object sender, EventArgs e) {
            _isCompleted = false;
        }
    }
}