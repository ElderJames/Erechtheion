using System;
using DNIC.Erechtheion.Core.Domain;
using DNIC.Erechtheion.Core.Domain.Entities;
using DNIC.Erechtheion.Core.EnumTypes;

namespace DNIC.Erechtheion.Domain.Entities
{
	public class Topic : AbstractContent, IDisable
	{
		#region ctor

		public Topic(string title, string slug,
			ContentType contentType, string content, ContentState state) : base(title, slug, contentType, content, state)
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

		#endregion

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