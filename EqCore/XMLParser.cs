using System;
using System.Collections.Generic;
using System.Text;

namespace EqCore
{
	class XMLParser
	{
		private string xmlString = "";
		private StringBuilder xmlBuilder = null;
		private List<string> elementTags = null;
		private int tabCount = 0;



		public XMLParser()
		{
			xmlString = "";
			xmlBuilder = new StringBuilder();
			elementTags = new List<string>();
			tabCount = 0;
		}
		public XMLParser(string xml)
		{
			xmlString = xml;
			xmlBuilder = new StringBuilder(xml);
			elementTags = new List<string>();
			tabCount = 0;
		}



		public void SetXmlString(string xml)
		{
			xmlString = xml;
			xmlBuilder = new StringBuilder(xml);
			elementTags = new List<string>();
			tabCount = 0;
		}
		public override string ToString()
		{
			return xmlBuilder.ToString();
		}



		public string GetText(string tag)
		{
			int start = xmlString.IndexOf("<" + tag + ">");
			start = xmlString.IndexOf(">", start + 1);

			int end = xmlString.IndexOf("</" + tag + ">", start + 1);

			if (start == -1 || end == -1)
				return "";
			else
				return xmlString.Substring(start + 1, end - start - 1);
		}
        public string GetText(string tag, string InitValue)
        {
            int start = xmlString.IndexOf("<" + tag + ">");
            start = xmlString.IndexOf(">", start + 1);

            int end = xmlString.IndexOf("</" + tag + ">", start + 1);

            if (start == -1 || end == -1)
                return InitValue;
            else
                return xmlString.Substring(start + 1, end - start - 1) == "" ? InitValue : xmlString.Substring(start + 1, end - start - 1);
        }
		public int GetInt(string tag)
		{
			int result = 0;

			try
			{
				result = int.Parse(GetText(tag));
			}
			catch { }

			return result;
		}
        public int GetShort(string tag)
        {
            int result = 0;

            try
            {
                result = short.Parse(GetText(tag));
            }
            catch { }

            return result;
        }
		public void SetText(string tag, string text)
		{
			for (int i = 0; i < tabCount; i++) xmlBuilder.Append("  ");
			xmlBuilder.Append("<" + tag + ">" + text + "</" + tag + ">\r\n");
		}
		public void SetInt(string tag, int value)
		{
			SetText(tag, value.ToString());
		}
		public void SetShort(string tag, short value)
		{
			SetText(tag, value.ToString());
		}



		public XMLParser GetElement(string tag)
		{
			int start = xmlString.IndexOf("<" + tag + ">");
			int end = xmlString.IndexOf("</" + tag + ">", start + 1);

			if (start == -1 || end == -1) return new XMLParser();

			return new XMLParser(xmlString.Substring(start, end + tag.Length + 3 - start));
		}
		public List<XMLParser> GetElements(string tag)
		{
			int start = 0;
			int end = 0;
			List<XMLParser> elements = new List<XMLParser>();

			do
			{
				start = xmlString.IndexOf("<" + tag + ">", start);
				end = xmlString.IndexOf("</" + tag + ">", start + 1);

				if (start == -1 || end == -1) break;

				string temp = xmlString.Substring(start, end + tag.Length + 3 - start);
				elements.Add(new XMLParser(temp));

				start = end + 1;
			} while (start != -1 || end != -1);

			return elements;
		}



		public void SetStartElement(string tag)
		{
			for (int i = 0; i < tabCount; i++) xmlBuilder.Append("  ");
			xmlBuilder.Append("<" + tag + ">\r\n");
			elementTags.Add(tag);
			tabCount++;
		}
		public void SetEndElement()
		{
			int index = tabCount - 1;
			for (int i = 0; i < index; i++) xmlBuilder.Append("  ");
			xmlBuilder.Append("</" + elementTags[index] + ">\r\n");
			elementTags.RemoveAt(index);
			tabCount--;
		}


	}


}