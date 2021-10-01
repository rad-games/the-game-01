using System;
using UnityEditor;

namespace TheGame.AssetManagement
{
    public class TextureAssetImporter : AssetPostprocessor
    {
        void OnPreprocessTexture()
        {
            if (AssetUtils.IsThirdPartyAsset(assetPath))
            {
                return;
            }

            var guid = AssetDatabase.GUIDFromAssetPath(assetPath);
            var labels = AssetDatabase.GetLabels(guid);
            int index = Array.FindIndex(labels, x => x == AssetLabels.Texture);
            if (index == -1)
            {
                // apply import settings only first time
                TextureImporter textureImporter = (TextureImporter)assetImporter;
                if (textureImporter.maxTextureSize > 1024)
                {
                    textureImporter.maxTextureSize = 1024;
                }
            }
        }
    }
}