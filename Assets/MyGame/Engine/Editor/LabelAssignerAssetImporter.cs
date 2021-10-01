using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

namespace TheGame.AssetManagement
{
    public class LabelAssignerAssetImporter : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            foreach (var assetPath in importedAssets)
            {
                var type = AssetDatabase.GetMainAssetTypeAtPath(assetPath);
                if (type == typeof(Texture2D))
                {
                    ApplyModifications<Texture2D>(assetPath, AssetLabels.Texture, "t-");
                }
                else if (type == typeof(Material))
                {
                    ApplyModifications<Material>(assetPath, AssetLabels.Material, "mat-");
                }
                else if (type == typeof(AudioClip))
                {
                    ApplyModifications<AudioClip>(assetPath, AssetLabels.Audio, "au-");
                }
                else if (type == typeof(Cubemap))
                {
                    ApplyModifications<Cubemap>(assetPath, AssetLabels.Cubemap, "cube-");
                }
                else if (assetPath.EndsWith(".obj") || assetPath.EndsWith(".fbx"))
                {
                    ApplyModifications<UnityEngine.Object>(assetPath, AssetLabels.Model, "mo-");
                }
                else if (assetPath.EndsWith(".prefab"))
                {
                    ApplyModifications<GameObject>(assetPath, AssetLabels.Prefab, "pr-");
                }
                else if (assetPath.EndsWith(".dll"))
                {
                    var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
                    AddLabelIfNotExist(asset, AssetLabels.Library);
                }
            }
        }

        static void ApplyModifications<TType>(string assetPath, string labelName, string prefix)
            where TType : UnityEngine.Object
        {
            var obj = AssetDatabase.LoadAssetAtPath<TType>(assetPath);
            AddLabelIfNotExist(obj, labelName);
            ModifyAssetName(assetPath, prefix);
        }

        void OnPostprocessAnimation(GameObject gameObject, AnimationClip animationClip)
        {
            AddLabelIfNotExist(gameObject, AssetLabels.AnimationClip);
        }

        static void AddLabelIfNotExist(UnityEngine.Object obj, string labelName)
        {
            var labels = AssetDatabase.GetLabels(obj);
            int index = labels != null ? Array.FindIndex(labels, x => x == labelName) : -1;
            if (index == -1)
            {
                int newSize = labels == null ? 1 : labels.Length + 1;
                Array.Resize(ref labels, newSize);
                labels[labels.Length - 1] = labelName;
                AssetDatabase.SetLabels(obj, labels);
                EditorUtility.SetDirty(obj);
            }
        }

        static void ModifyAssetName(string assetPath, string prefix)
        {
            if (AssetUtils.IsThirdPartyAsset(assetPath))
            {
                return;
            }

            var assetName = Path.GetFileName(assetPath);
            if (assetName.StartsWith(prefix))
            {
                return;
            }
            var newAssetPath = assetPath.Replace(assetName, prefix + assetName).Replace('_', '-').ToLower();
            var uniqueNewAssetPath = AssetDatabase.GenerateUniqueAssetPath(newAssetPath);
            AssetDatabase.MoveAsset(assetPath, uniqueNewAssetPath);
        }
    }
}