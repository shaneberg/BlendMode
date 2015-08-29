sampler2D LowerTexture;
sampler2D UpperTexture;

float4 main(float2 uv : TEXCOORD) : COLOR{
    float4 lowerColor = tex2D(LowerTexture, uv);
    float4 upperColor = tex2D(UpperTexture, uv);
    float4 final = float4(0, 0, 0, 0);

    if (lowerColor.r < 0.5)
    {
        final.r = 2 * lowerColor.r * upperColor.r;
    }
    else
    {
        final.r = 1 - 2 * (1 - lowerColor.r) * (1 - upperColor.r);
    }

    if (lowerColor.g < 0.5)
    {
        final.g = 2 * lowerColor.g * upperColor.g;
    }
    else
    {
        final.g = 1 - 2 * (1 - lowerColor.g) * (1 - upperColor.g);
    }

    if (lowerColor.b < 0.5)
    {
        final.b = 2 * lowerColor.b * upperColor.b;
    }
    else
    {
        final.b = 1 - 2 * (1 - lowerColor.b) * (1 - upperColor.b);
    }

    if (lowerColor.a < 0.5)
    {
        final.a = 2 * lowerColor.a * upperColor.a;
    }
    else
    {
        final.a = 1 - 2 * (1 - lowerColor.a) * (1 - upperColor.a);
    }

    return final;
}