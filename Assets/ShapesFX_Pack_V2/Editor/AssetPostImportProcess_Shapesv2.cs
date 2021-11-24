
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Orangedkeys.ShapesFX_V2;
using System.IO;



public class AssetPostImportProcess_Shapesv2 : AssetPostprocessor
{
    static private bool WelcomeWin = false;
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        WelcomeWin = false;
        foreach (string item in importedAssets)
        {
            if (Path.GetFileName(item) == "AssetPostImportProcess_Shapesv2.cs") WelcomeWin = true;

        }

        foreach (string itemdel in deletedAssets)
        {
            if (Path.GetFileName(itemdel) == "AssetPostImportProcess_Shapesv2.cs") WelcomeWin = false;

        }

        if (WelcomeWin)
        {
            Debug.Log("SHAPES FX PACK VOL2 IMPORTED !!");
            Welcome_ShapesV2.ShowWindow();
        }





    }

}