public class CameraPathResolver : ICameraPathResolver
{
    private const string CameraPath = "Prefabs/Core";

    private static ICameraPathResolver _pathResolver;

    public string GetCameraPath()
    {
        return $"{CameraPath}/Camera";
    }
}
