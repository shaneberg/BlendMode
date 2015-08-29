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
                PixelShaderEffect effect = kvp.Value;

                effect.UpperLayerInput = new ImageBrush(this.UpperLayer.Source);
                effect.LowerLayerInput = new ImageBrush(this.LowerLayer.Source);

                this.EffectGrid.Effect = kvp.Value as System.Windows.Media.Effects.ShaderEffect;
                this.ComboBox.SelectedItem = kvp.Key;
                ComboBoxItem item = new ComboBoxItem();
                item.Content = kvp.Key;
                item.Selected += Item_Selected;
                this.ComboBox.Items.Add(item);
            }

            this.UpperLayer.Opacity = this.BlendModeSlider.Value;
            this.LowerLayer.Opacity = 1 - this.BlendModeSlider.Value;
        }

        private void Item_Selected(object sender, RoutedEventArgs e)
        {
            ComboBoxItem box = sender as ComboBoxItem;
            this.EffectGrid.Effect = ShaderManager.Instance.PixelShaders[box.Content.ToString()] as System.Windows.Media.Effects.ShaderEffect;
        }

        private void BlendModeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.UpperLayer.Opacity = e.NewValue;
            this.LowerLayer.Opacity = 1 - e.NewValue;
        }
    }
}
