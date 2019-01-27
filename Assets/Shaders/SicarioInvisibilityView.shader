// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:1,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:False,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:1,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:6,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:1,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32740,y:33254,varname:node_2865,prsc:2|emission-8019-OUT;n:type:ShaderForge.SFN_TexCoord,id:4219,x:30364,y:33142,cmnt:Default coordinates,varname:node_4219,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Relay,id:8397,x:30986,y:33136,cmnt:Refract here,varname:node_8397,prsc:2|IN-4219-UVOUT;n:type:ShaderForge.SFN_Relay,id:4676,x:31966,y:33360,cmnt:Modify color here,varname:node_4676,prsc:2|IN-1610-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4430,x:31116,y:33268,ptovrint:False,ptlb:MainTex,ptin:_MainTex,cmnt:MainTex contains the color of the scene,varname:node_9933,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7542,x:31349,y:33139,varname:node_1672,prsc:2,ntxv:0,isnm:False|UVIN-8397-OUT,TEX-4430-TEX;n:type:ShaderForge.SFN_Color,id:4552,x:31552,y:33606,ptovrint:False,ptlb:ColorBlend,ptin:_ColorBlend,varname:node_4552,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6102941,c2:0.1301363,c3:0.1301363,c4:1;n:type:ShaderForge.SFN_TexCoord,id:9062,x:31066,y:33963,varname:node_9062,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Length,id:9060,x:31398,y:33961,varname:node_9060,prsc:2|IN-382-OUT;n:type:ShaderForge.SFN_Multiply,id:8892,x:32027,y:33544,varname:node_8892,prsc:2|A-4552-RGB,B-2471-OUT,C-8025-OUT;n:type:ShaderForge.SFN_RemapRange,id:382,x:31244,y:33961,varname:node_382,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-9062-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:9227,x:31552,y:33944,varname:node_9227,prsc:2,frmn:0,frmx:1,tomn:2,tomx:0.5|IN-9060-OUT;n:type:ShaderForge.SFN_Tex2d,id:9736,x:31528,y:34173,ptovrint:False,ptlb:EdgeDistortion,ptin:_EdgeDistortion,varname:node_9736,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:19ea91247643bc745bb4adc813bc7306,ntxv:0,isnm:False|UVIN-4158-UVOUT;n:type:ShaderForge.SFN_Add,id:5802,x:31788,y:33930,varname:node_5802,prsc:2|A-9227-OUT,B-9736-R;n:type:ShaderForge.SFN_Panner,id:4158,x:31374,y:34173,varname:node_4158,prsc:2,spu:1,spv:1|UVIN-5250-UVOUT,DIST-7521-OUT;n:type:ShaderForge.SFN_TexCoord,id:5250,x:30993,y:34166,varname:node_5250,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Clamp01,id:2471,x:31959,y:33930,varname:node_2471,prsc:2|IN-5802-OUT;n:type:ShaderForge.SFN_Time,id:70,x:30993,y:34314,varname:node_70,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:4244,x:30993,y:34467,ptovrint:False,ptlb:EdgeDistortionSpeed,ptin:_EdgeDistortionSpeed,varname:node_4244,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:7521,x:31186,y:34314,varname:node_7521,prsc:2|A-70-T,B-4244-OUT;n:type:ShaderForge.SFN_Desaturate,id:1610,x:31748,y:33360,varname:node_1610,prsc:2|COL-7542-RGB,DES-5584-OUT;n:type:ShaderForge.SFN_Vector1,id:5584,x:31502,y:33423,varname:node_5584,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Add,id:8025,x:31552,y:33801,varname:node_8025,prsc:2|A-4552-RGB,B-9227-OUT;n:type:ShaderForge.SFN_Multiply,id:8019,x:32351,y:33341,varname:node_8019,prsc:2|A-5503-OUT,B-4676-OUT;n:type:ShaderForge.SFN_Multiply,id:9599,x:31748,y:33157,varname:node_9599,prsc:2|A-7542-R,B-4552-RGB;n:type:ShaderForge.SFN_Add,id:5503,x:32132,y:33155,varname:node_5503,prsc:2|A-9599-OUT,B-8892-OUT;proporder:4430-4552-9736-4244;pass:END;sub:END;*/

Shader "BitCutter/SicarioInvisibilityView" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _ColorBlend ("ColorBlend", Color) = (0.6102941,0.1301363,0.1301363,1)
        _EdgeDistortion ("EdgeDistortion", 2D) = "white" {}
        _EdgeDistortionSpeed ("EdgeDistortionSpeed", Float ) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="Geometry+1"
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZTest Always
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            //#pragma only_renderers d3d9 d3d11 glcore gles 
            //#pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _ColorBlend;
            uniform sampler2D _EdgeDistortion; uniform float4 _EdgeDistortion_ST;
            uniform float _EdgeDistortionSpeed;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float2 node_8397 = i.uv0; // Refract here
                float4 node_1672 = tex2D(_MainTex,TRANSFORM_TEX(node_8397, _MainTex));
                float node_9227 = (length((i.uv0*2.0+-1.0))*-1.5+2.0);
                float4 node_70 = _Time;
                float2 node_4158 = (i.uv0+(node_70.g*_EdgeDistortionSpeed)*float2(1,1));
                float4 _EdgeDistortion_var = tex2D(_EdgeDistortion,TRANSFORM_TEX(node_4158, _EdgeDistortion));
                float3 emissive = (((node_1672.r*_ColorBlend.rgb)+(_ColorBlend.rgb*saturate((node_9227+_EdgeDistortion_var.r))*(_ColorBlend.rgb+node_9227)))*lerp(node_1672.rgb,dot(node_1672.rgb,float3(0.3,0.59,0.11)),0.8));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
