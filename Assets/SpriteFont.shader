Shader "Hidden/SpriteFont"
{
    Properties
    {
        _MainTex ("Size", 2D) = "white" {}
        _SpriteFont ("Sprite Font", 2D) = "white" {}
        _Letter ("Letter", Int) = 0
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _SpriteFont;
        	int _Letter;

            fixed4 frag (v2f i) : SV_Target
            {
                i.uv.x /= 26;
                i.uv.x += (1.0 / 26.0) * _Letter;
                fixed4 col = tex2D(_SpriteFont, i.uv);
                
                return col;
            }
            ENDCG
        }
    }
}
