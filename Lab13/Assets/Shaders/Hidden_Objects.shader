Shader "Custom/Hidden_Objects"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _PlayerPos("Player Pos", Vector) = (0,0,0,0)
        _Radius("Radius", Float) = 5
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float4 _Color;
            float4 _PlayerPos;
            float _Radius;

            struct appdata
            {
                float4 vertex : POSITION;
            };
            
            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float d = distance(i.worldPos, _PlayerPos.xyz);

                float fade = smoothstep(_Radius - 1.0, _Radius, d);
                return float4(_Color.rgb, 1.0 - fade);

                return _Color;
            }

            ENDCG
        }
    }
}
