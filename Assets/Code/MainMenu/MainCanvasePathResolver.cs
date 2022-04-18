public class MainCanvasePathResolver : IMainCanvasePathResolver
{
	private const string _bundle = "Prefabs/Canvase";

	public string GetMainCanvasePath()
	{
		return $"{_bundle}/Canvas";
	}

	public string GetLevelsPanelPath()
	{
		return $"{_bundle}/Levels";
	}
}
