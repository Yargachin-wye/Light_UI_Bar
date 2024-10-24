Shader "Unlit/BarBGShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1, 1, 1, 1)
        _Margin ("Square Size Y (pixels)", Range(0,0.5)) = 0.2
        _TiltAngle ("Tilt Angle (degrees)", Range(-30, 30)) = 0
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float _Margin;
            float _TiltAngle;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col;

                float radTiltAngle = radians(_TiltAngle);
                float tiltedUV = (i.uv.x) * cos(radTiltAngle) - (i.uv.y - 0.5f) * sin(radTiltAngle);

                if (!(abs(tiltedUV) > _Margin && abs(1 - tiltedUV) > _Margin))
                {
                    col = fixed4(0, 0, 0, 0);
                }
                else
                {
                    col = _Color;
                }

                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}