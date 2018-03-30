Shader "Custom/CRT"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Dir("direction", Range(-3,3)) = 1
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
			#pragma target 3.0

			#include "UnityCG.cginc"

			fixed _Dir;

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

			float rand(float3 co)
			{
				return frac(sin(dot(co.xyz, float3(12.9898, 78.233, 45.5432))) * 43758.5453);
			}

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv+float2(0.0005f*_Dir*sin(200*i.uv.y+10*_Time[1]*_Dir),0.0005f*sin(200 * i.uv.y + 10 * _Time[1] * _Dir)));

				// just invert the colors
				if (step(0.9, abs(sin(10*i.uv.y+_Time[1]*5*_Dir))) && (step(0.9, rand(float3(i.uv.y, i.uv.x, _Time[1])))|| step(rand(float3(i.uv.y, i.uv.x, _Time[1])),0.1))) {
					col.r = rand(float3(i.uv.y, i.uv.x, _Time[1]));
					col.b = rand(float3(i.uv.y, i.uv.x, _Time[1]));
					col.g = rand(float3(i.uv.y, i.uv.x, _Time[1]));
				}
				else 
				{
					col.r -= 0.15f*sin(rand(float3(i.uv.y, i.uv.x, _Time[1])));
					col.b -= 0.15f*sin(rand(float3(i.uv.y, i.uv.x, _Time[1])));
					col.g -= 0.15f*sin(rand(float3(i.uv.y, i.uv.x, _Time[1])));
				}
				return col;
			}
			ENDCG
		}
	}
}
