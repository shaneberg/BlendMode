using System;
using System.Windows;
using System.Windows.Media;

using System.Windows.Media.Effects;

namespace BlendMode
{
    public class PixelShaderEffect : ShaderEffect
    {
        private PixelShader pixelShader = new PixelShader();

        public PixelShaderEffect(string relativePath)
        {
            this.pixelShader.UriSource = new Uri("/BlendMode;component/CompiledShaders/" + relativePath, UriKind.Relative);
            this.PixelShader = this.pixelShader;

            this.UpdateShaderValue(InputProperty);
        }

        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(PixelShaderEffect), 0);

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
