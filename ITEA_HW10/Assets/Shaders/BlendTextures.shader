Shader "Custom/BlendTextures"
{
         Properties
         {
             _Color ("Color", Color) = (1,1,1,1)
             _Blend ("Blend", Range(0,1)) = 0.0
             _MainTex ("Texture 1", 2D) = "white" {}
             _MainTex2 ("Texture 2", 2D) = "white" {}
         }
         SubShader
         {
             Tags { "RenderType"="Opaque" }
             LOD 200
            
             CGPROGRAM
             // Physically based Standard lighting model, and enable shadows on all light types
             #pragma surface surf Standard fullforwardshadows
      
             // Use shader model 3.0 target, to get nicer looking lighting
             #pragma target 3.0
      
             sampler2D _MainTex;
             sampler2D _MainTex2;
      
             struct Input
             {
                 float2 uv_MainTex;
                 float2 uv_MainTex2;
             };
      
             half _Blend;
             fixed4 _Color;
      
             void surf (Input IN, inout SurfaceOutputStandard o)
             {
                 // Albedo comes from a texture tinted by color
                 fixed4 c = lerp (tex2D (_MainTex, IN.uv_MainTex), tex2D (_MainTex2, IN.uv_MainTex2), _Blend) * _Color;
                 o.Albedo = c.rgb;
                 o.Alpha = c.a;
             }
             ENDCG
         }
         FallBack "Diffuse"
}
