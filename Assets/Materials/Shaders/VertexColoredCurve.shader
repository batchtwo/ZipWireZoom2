Shader "Custom/Vertex Colored Curve" 
{
     Properties 
     {
     	_Curvature ("Curvature", Float) = 0.001
     }

     SubShader 
     {
     	Tags { "RenderType"="Opaque" }
     	LOD 200

     	CGPROGRAM
        #pragma surface surf Lambert vertex:vert addshadow

        uniform float _Curvature;

        struct Input 
        {
            float4 color: Color; // vertex color
        };

        // Apply curvature
        void vert( inout appdata_full v)
        {
            // Transform vert coordinates from model to world space
            float4 vCoord = mul( _Object2World, v.vertex );
            
            // Coordinates relative to camera position
            vCoord.xyz -= _WorldSpaceCameraPos.xyz;
 
            // Reduce y co-ordinates of each vertex based on z distance from camera
            vCoord = float4( 0.0f, (vCoord.z * vCoord.z) * - _Curvature, 0.0f, 0.0f );
 
            // Change back to model space
            v.vertex += mul(_World2Object, vCoord);
        }

        void surf (Input IN, inout SurfaceOutput o) 
        {
            o.Albedo = IN.color.rgb;
            o.Alpha = IN.color.a;
        }
        ENDCG

     } 
 }