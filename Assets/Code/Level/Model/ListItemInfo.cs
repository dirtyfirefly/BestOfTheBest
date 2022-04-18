using System.Collections.Generic;
using System.Xml.Serialization;

public class ListItemInfo
{
	[XmlArray("Collection"), XmlArrayItem("Item")]
	public List<ItemInfo> lvlInfo;

	public ListItemInfo()
	{
		lvlInfo = new List<ItemInfo>();
	}
}