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

            this.UpdateShaderValue(UpperLayerInputProperty);
            this.UpdateShaderValue(LowerLayerInputProperty);
        }

        public static readonly DependencyProperty UpperLayerInputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("UpperLayerInput", typeof(PixelShaderEffect), 0);
        public static readonly DependencyProperty LowerLayerInputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("LowerLayerInput", typeof(PixelShaderEffect), 1);

        public Brush UpperLayerInput
        {
            get
            {
                return ((Brush)this.GetValue(UpperLayerInputProperty));
            }
            set
            {
                this.SetValue(UpperLayerInputProperty, value);
            }
        }

        public Brush LowerLayerInput
        {
            get
            {
                return ((Brush)this.GetValue(LowerLayerInputProperty));
            }
            set
            {
                this.SetValue(LowerLayerInputProperty, value);
            }
        }


    }
}
