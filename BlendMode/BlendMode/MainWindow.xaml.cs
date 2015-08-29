using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace BlendMode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (var kvp in ShaderManager.Instance.PixelShaders)
            {
                this.EffectGrid.Effect = kvp.Value as System.Windows.Media.Effects.ShaderEffect;
            }

            this.Image1.Opacity = this.BlendModeSlider.Value;
            this.Image2.Opacity = 1 - this.BlendModeSlider.Value;
        }

        private void BlendModeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Image1.Opacity = e.NewValue;
            this.Image2.Opacity = 1 - e.NewValue;
        }
    }
}
