using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DNIC.Erechtheion.Core.Domain;
using DNIC.Erechtheion.Core.EnumTypes;
using DNIC.Erechtheion.Domain.ValueObjects;

namespace DNIC.Erechtheion.Domain.Entities
{
	[Table("Topic")]
	public class Topic : AbstractContent, IDisable
	{
		#region ctor

		public Topic(Guid aggregateId, string title, string slug, ICollection<ContentChannels> channels, ContentType contentType, string content, ContentState state) : base(aggregateId, channels, title, slug, contentType, content, state)
		{
			this.Title = title;
			this.Slug = slug;
			this.ContentType = contentType;
			this.Content = content;
			this.State = state;
		}

		protected Topic()
		{
		}

		#endregion ctor

		#region prop

		/// <summary>
		/// 是否锁定
		/// </summary>
		public bool Locked { get; private set; }

		/// <summary>
		/// 是否启用
		/// </summary>
		public bool Enabled { get; private set; }

		#endregion prop

		#region disbable

		public void Enable()
		{
			if (Enabled)
			{
				return;
			}

			Enabled = true;
		}

		public void Disable()
		{
			if (!Enabled)
			{
				return;
			}

			Enabled = false;
		}

		#endregion disbable

		#region actions

		public void Change(string title, string slug, ContentType contentType, string content, ContentState state)
		{
			this.Title = title;
			this.Slug = slug;
			this.ContentType = contentType;
			this.Content = content;
			this.State = state;
		}

		#endregion actions
	}
}