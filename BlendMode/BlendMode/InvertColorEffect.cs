using System;
using System.Windows;
using System.Windows.Media;

using System.Windows.Media.Effects;
namespace BlendMode
{
    public class InvertColorEffect : ShaderEffect
    {
        private PixelShader pixelShader = new PixelShader();

        public InvertColorEffect()
        {
            this.pixelShader.UriSource = new Uri("/BlendMode;component/CompiledShaders/InvertColor.ps", UriKind.Relative);
            this.PixelShader = this.pixelShader;

            this.UpdateShaderValue(InputProperty);
        }

        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(InvertColorEffect), 0);

        public Brush Input
        {
            get
            {
                return ((Brush)this.GetValue(InputProperty));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }

    }
}
