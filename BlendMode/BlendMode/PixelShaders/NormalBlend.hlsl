sampler2D LowerTexture;
sampler2D UpperTexture;

float4 main(float2 uv : TEXCOORD) : COLOR{
    float4 lowerColor = tex2D(LowerTexture, uv);
    float4 upperColor = tex2D(UpperTexture, uv);
    return upperColor;
}