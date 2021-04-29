Shader "Unlit/CircleDissolve"
{
    Properties
    {
        [NoScaleOffset] _MainTex("Texture", 2D) = "white" {}
        _Center("Center", Vector) = (0, 0, 0, 0)
        _Radius("Radisu", float) = 1
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque"}
            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                float _Radius;
                float4 _Center;

                sampler2D _MainTex;

                struct appdata
                {
                    half4 vertex : POSITION;
                    fixed2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    half4 pos : SV_POSITION;
                    half4 wpos : TEXCOORD1;
                    fixed2 uv : TEXCOORD0;
                };

                v2f vert(appdata v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.wpos = mul(unity_ObjectToWorld, v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 color = tex2D(_MainTex, i.uv);
                    float v = pow(i.wpos.x - _Center.x, 2) + pow(i.wpos.y - _Center.y, 2) + pow(i.wpos.z - _Center.z, 2) <= pow(_Radius, 2) ? 1 : -1;
                    clip(v);
                    return color;
                }
                ENDCG
            }
        }
}