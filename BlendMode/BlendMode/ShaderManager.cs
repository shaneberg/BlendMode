using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;

namespace BlendMode
{
    class ShaderManager
    {
        public Dictionary<string, PixelShaderEffect> PixelShaders = new Dictionary<string, PixelShaderEffect>();
        private readonly string compiledShadersDir = System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\CompiledShaders\\";

        private static ShaderManager instance;

        public static ShaderManager Instance
        {
            get
            {
                if (ShaderManager.instance == null)
                {
                    ShaderManager.instance = new ShaderManager();
                }

                return ShaderManager.instance;
            }
        }

        public ShaderManager()
        {
            InitializeShaders();
        }

        public void InitializeShaders()
        {
            string[] shaderList = System.IO.Directory.GetFiles(compiledShadersDir, "*.ps");
            
            foreach (string curString in shaderList)
            {
                string name = System.IO.Path.GetFileName(curString);
                PixelShaderEffect newShaderEffect = new PixelShaderEffect(name);

                this.PixelShaders.Add(name, newShaderEffect);
            }
        }
    }
}