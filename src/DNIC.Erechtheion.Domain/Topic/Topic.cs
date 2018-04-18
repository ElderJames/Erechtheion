using DNIC.Erechtheion.Core.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace DNIC.Erechtheion.Domain.Topic
{
	public class Topic : PlainEntity
	{
		private Topic()
		{
		}

		public Topic(string name)
		{
			if (string.IsNullOrEmpty(name))
				return;

			Name = name;
		}

		[Required]
		[StringLength(32)]
		public string Name { get; private set; }

		public void Change(string name)
		{
			if (string.IsNullOrEmpty(name) || Name == name)
				return;

			Name = name;
		}
	}
}