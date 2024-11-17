Shader "Unlit/ToonShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Brightness( "Brightness",Range(0,1)) = 0.3
        _Strength("Strength", Range(0,1))=0.5
        _Color ("Color", COLOR) = (1,1,1,1)
        _Detail ("Detail",Range(0,1))=0.3
     }

     SubShader
     {
        Tags {"RenderType"="Opaque"}
        LOD 100

        Pass
        {
            CGPROGRAM
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members uv)
#pragma exclude_renderers d3d11
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float uv ; TEXCOORD0;
                float4 vertex : 
            };

            float4      _Color;
            sampler2D   _MainTex;

            float4 frag(v2f_customrendertexture IN) : SV_Target
            {
                float2 uv = IN.localTexcoord.xy;
                float4 color = tex2D(_MainTex, uv) * _Color;

                // TODO: Replace this by actual code!
                uint2 p = uv.xy * 256;
                return countbits(~(p.x & p.y) + 1) % 2 * float4(uv, 1, 1) * color;
            }
            ENDCG
        }
    }
}
