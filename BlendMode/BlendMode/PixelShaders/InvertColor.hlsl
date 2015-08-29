sampler2D InputTexture;

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(InputTexture, uv);
    float4 invertedColor = float4(color.a - color.rgb, color.a);
    return invertedColor;
}