Shader "Custom/Vertex Colored No Fog" {
     Properties {
     }
     SubShader {
     	Cull Off
     	Fog { Mode Off }
         Pass {
             ColorMaterial AmbientAndDiffuse
         }

     } 
 }