using HelixToolkit.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace _30
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            load3dModel();            
        }
        public void load3dModel()
        {
            ObjReader CurrentHelixObjReader = new ObjReader();
            Model3DGroup MyModel = CurrentHelixObjReader.Read(@"C:\Практика\30\30\bin\Debug\rose.obj");
            model.Content = MyModel;

            viewport.Children.Add(new DefaultLights());

            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 40,
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
                Duration = TimeSpan.FromSeconds(2)
            };

            AxisAngleRotation3D rotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            RotateTransform3D rotateTransform = new RotateTransform3D(rotation);
            model.Transform = rotateTransform;
            rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, animation);

        }
    }
}