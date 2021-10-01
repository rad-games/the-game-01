namespace TheGame.AssetManagement
{
    public static class AssetUtils
    {
        public static bool IsThirdPartyAsset(string assetPath)
        {
            return assetPath.Contains("ThirdParty") || assetPath.Contains("Packages");
        }
    }
}