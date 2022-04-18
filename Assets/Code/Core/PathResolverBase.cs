public class PathResolverBase : IPathResolverBase
{
	private readonly string _levelBaseBundle = "Prefabs/Levels";
	private readonly string _blockBundle = "Prefabs/Levels/Blocks/Forest";

	public string GetLevelBasePath()
	{
		return $"{_levelBaseBundle}/LevelBaseForGame";
	}

	public string GetForestBridleLitlePath()
	{
		return $"{_blockBundle}/bridge";
	}

	public string GetForestGrasEmptyPath()
	{
		return $"{_blockBundle}/gras";
	}

	public string GetForestGroundEmptyPath()
	{
		return $"{_blockBundle}/groung";
	}
}
