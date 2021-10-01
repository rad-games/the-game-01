using UnityEditor;

namespace TheGame.AssetManagement
{
    public class TextureAssetImporter : AssetPostprocessor
    {
        void OnPreprocessTexture()
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.maxTextureSize = 1024;
        }
    }
}