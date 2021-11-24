using UnityEngine;
using UnityEditor;

public class UI_ShapesFX_V2 : ShaderGUI
{

    MaterialEditor editor;
    MaterialProperty[] properties;
    bool TargetMode;

    //get preperties function
    MaterialProperty FindProperty(string name)
    {
        return FindProperty(name, properties);
    }
    //

    ////
    static GUIContent staticLabel = new GUIContent();
    static GUIContent MakeLabel(MaterialProperty property, string tooltip = null)
    {
        staticLabel.text = property.displayName;
        staticLabel.tooltip = tooltip;
        return staticLabel;
    }
    ////

    public override void OnGUI(MaterialEditor editor, MaterialProperty[] properties)
    {
        this.editor = editor;
        this.properties = properties;
        DoMain();

    }


    // GUI FUNCTION	
    void DoMain()
    {
        //--- Logo
        Texture2D myGUITexture = (Texture2D)Resources.Load("Gui_ShapesFX_PACK_v2");
        GUILayout.Label(myGUITexture, EditorStyles.centeredGreyMiniLabel);

        //LABELS
        GUILayout.Label("/---------------/ SHAPES FX V2 PACK /---------------/", EditorStyles.centeredGreyMiniLabel);
        GUILayout.Label("[ Surface Diffuse ]", EditorStyles.helpBox);

        // get properties
        MaterialProperty _Diffuse_map = ShaderGUI.FindProperty("_Diffuse_map", properties);

        //Add to GUI
        editor.TexturePropertySingleLine(MakeLabel(_Diffuse_map, "Diffuse_map"), _Diffuse_map);

        MaterialProperty _DiffuseColorMult = FindProperty("_DiffuseColorMult");
        editor.ShaderProperty(_DiffuseColorMult, MakeLabel(_DiffuseColorMult));

        EditorGUILayout.Space();

        


        GUILayout.Label("[ Animation Mask ]", EditorStyles.helpBox);

        // get properties
        MaterialProperty _Mask_map = ShaderGUI.FindProperty("_Mask_map", properties);

        //Add to GUI
        editor.TexturePropertySingleLine(MakeLabel(_Mask_map, "Mask_map"), _Mask_map);

        MaterialProperty _MaskTling = FindProperty("_MaskTling");
        editor.ShaderProperty(_MaskTling, MakeLabel(_MaskTling));

        MaterialProperty _Panner_X = FindProperty("_Panner_X");
        editor.ShaderProperty(_Panner_X, MakeLabel(_Panner_X));

        MaterialProperty _Panner_Y = FindProperty("_Panner_Y");
        editor.ShaderProperty(_Panner_Y, MakeLabel(_Panner_Y));

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();



        GUILayout.Label("[ Color Setting ]", EditorStyles.helpBox);


        MaterialProperty _MaskColor = FindProperty("_MaskColor");
        editor.ShaderProperty(_MaskColor, MakeLabel(_MaskColor));

        MaterialProperty _InteriorColorMult = FindProperty("_InteriorColorMult");
        editor.ShaderProperty(_InteriorColorMult, MakeLabel(_InteriorColorMult));

        

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        // Target Mode
        GUILayout.Label("[ Wires ]", EditorStyles.helpBox);
        MaterialProperty _ActivateLines = FindProperty("_ActivateLines");
        editor.ShaderProperty(_ActivateLines, MakeLabel(_ActivateLines));

        //TargetMode = EditorGUILayout.Toggle("Target Mode", TargetMode);
        
        if (_ActivateLines.floatValue == 1)
        {


            MaterialProperty _LinesColor = FindProperty("_LinesColor");
            editor.ShaderProperty(_LinesColor, MakeLabel(_LinesColor));

            MaterialProperty _LinesColorMult = FindProperty("_LinesColorMult");
            editor.ShaderProperty(_LinesColorMult, MakeLabel(_LinesColorMult));

            
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        //LABELS
        GUILayout.Label("[ Hue Variation ]", EditorStyles.helpBox);


        MaterialProperty _AberationChromMultSurface = FindProperty("_AberationChromMultSurface");
        editor.ShaderProperty(_AberationChromMultSurface, MakeLabel(_AberationChromMultSurface));

        MaterialProperty _AberationChromMult = FindProperty("_AberationChromMult");
        editor.ShaderProperty(_AberationChromMult, MakeLabel(_AberationChromMult));


        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        //LABELS
        GUILayout.Label("[ DISPLACEMENTS ]", EditorStyles.helpBox);

        MaterialProperty _Lines_Push = FindProperty("_Lines_Push");
        editor.ShaderProperty(_Lines_Push, MakeLabel(_Lines_Push));

        EditorGUILayout.Space();
        GUILayout.Label("<---------------[ Slices Displacement ]--------------->", EditorStyles.centeredGreyMiniLabel);

        MaterialProperty _SlicesDisplacement = FindProperty("_SlicesDisplacement");
        editor.ShaderProperty(_SlicesDisplacement, MakeLabel(_SlicesDisplacement));

        if (_SlicesDisplacement.floatValue == 1)
        {
            MaterialProperty _DisplacementSmoothHard = FindProperty("_DisplacementSmoothHard");
            editor.ShaderProperty(_DisplacementSmoothHard, MakeLabel(_DisplacementSmoothHard));
        }

        EditorGUILayout.Space();
        GUILayout.Label("<---------------[ Slices Rotation ]--------------->", EditorStyles.centeredGreyMiniLabel);
        MaterialProperty _SlicesRotation = FindProperty("_SlicesRotation");
        editor.ShaderProperty(_SlicesRotation, MakeLabel(_SlicesRotation));

        if (_SlicesRotation.floatValue == 1)
        {
            MaterialProperty _SlicesRotationMult = FindProperty("_SlicesRotationMult");
            editor.ShaderProperty(_SlicesRotationMult, MakeLabel(_SlicesRotationMult));
        }

        
        //LABELS
        //GUILayout.Label("DEBUG", EditorStyles.helpBox);
        



        


    }
}