using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace DNIC.Erechtheion.Core.Sql
{
	public class SqlMap : ISqlMap
	{
		private static readonly Lazy<SqlMap> MyInstance = new Lazy<SqlMap>(() => new SqlMap());

		private readonly Dictionary<string, string> _keyValues = new Dictionary<string, string>();

		public string SpliceParameter { get; set; } = "#";
		public string IdentityName { get; set; } = "id";
		public string ScopeName { get; set; } = "scope";

		public static SqlMap Instance => MyInstance.Value;

		private SqlMap()
		{
		}

		public string this[string scope, string key]
		{
			get
			{
				var scopyKey = $"{scope}:{key}";
				return _keyValues.ContainsKey(scopyKey) ? _keyValues[scopyKey] : null;
			}
		}

		public void Load(Stream stream)
		{
			_keyValues.Clear();

			var document = new XmlDocument();
			document.Load(stream);
			var scope = document.DocumentElement.Attributes?[ScopeName]?.Value;
			if (string.IsNullOrWhiteSpace(scope))
			{
				throw new ArgumentException("Scope attribute is unfound.");
			}
			LoadChildren(scope, document.DocumentElement.ChildNodes);

			SpliceSql(scope);
		}

		private void SpliceSql(string scope)
		{
			var regex = new Regex($"^{SpliceParameter}\\w+(\\s|,)");

			foreach (var key in _keyValues.Keys.ToList())
			{
				var value = _keyValues[key];
				if (!string.IsNullOrWhiteSpace(value))
				{
					foreach (Match match in regex.Matches(value))
					{
						var replaceKey = $"{scope}:{match.Value.Replace(SpliceParameter, "").Replace(",", "").Trim()}";
						if (_keyValues.ContainsKey(replaceKey))
						{
							value = value.Replace(match.Value.Trim(), _keyValues[replaceKey]);
							_keyValues[key] = value;
						}
					}
				}
			}
		}

		private void LoadChildren(string scope, XmlNodeList children)
		{
			if (children.Count == 0)
			{
				return;
			}
			for (int i = 0; i < children.Count; ++i)
			{
				var child = children[i];
				if (child.Attributes == null)
				{
					continue;
				}
				var key = child.Attributes[IdentityName]?.Value;
				var scopyKey = $"{scope}:{key}";
				if (!string.IsNullOrWhiteSpace(key) && !_keyValues.ContainsKey(scopyKey))
				{
					var vs = child.SelectSingleNode("./text()");
					_keyValues.Add(scopyKey, vs.InnerText.Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim());
				}
				LoadChildren(scope, child.ChildNodes);
			}
		}
	}
}
