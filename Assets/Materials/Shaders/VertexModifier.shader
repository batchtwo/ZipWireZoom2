﻿ Shader "Custom/Vertex Modifier" {
     Properties {
       _MainTex ("Texture", 2D) = "white" {}
       _Amount ("Height Adjustment", Float) = 1.0
     }
     SubShader {
       Tags { "RenderType" = "Opaque" }
       CGPROGRAM
       #pragma surface surf Lambert vertex:vert
       struct Input {
           float2 uv_MainTex;
       };
 
       float _Amount;
       sampler2D _MainTex;
 
       // Vertex modifier
       void vert (inout appdata_full v) 
       {
           v.vertex.y += _Amount;
       }
 
       // Surface shader function
       void surf (Input IN, inout SurfaceOutput o) 
       {
           o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
       }
       ENDCG
     }
   }