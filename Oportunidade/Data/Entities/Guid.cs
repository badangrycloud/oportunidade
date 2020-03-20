using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Data.Entities
{
	[XmlRoot(ElementName = "guid")]
	public class Guid
	{
		[XmlAttribute(AttributeName = "isPermaLink")]
		public string IsPermaLink { get; set; }
		[XmlText]
		public string Text { get; set; }
	}
}
