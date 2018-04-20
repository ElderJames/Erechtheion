using DNIC.Erechtheion.Core.CustomExceptions;
using DNIC.Erechtheion.Core.Domain;
using DNIC.Erechtheion.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DNIC.Erechtheion.Domain.Entities
{
	[Serializable]
	public class Channel : AuditedAggregateRoot, ITree<Channel, int>, IDisable, ISoftDelete
	{
		public bool IsRoot => ParentNode == null;

		public bool IsLeaf => !ChildNodes.Any();

		public virtual int ParentId { get; private set; }

		public virtual Channel ParentNode { get; }

		public virtual ICollection<Channel> ChildNodes { get; }

		[Required]
		[MinLength(2)]
		[StringLength(50)]
		public virtual string Name { get; private set; }

		[StringLength(500)]
		public virtual string Description { get; private set; }

		[StringLength(100)]
		public virtual string Icon { get; private set; }

		[StringLength(100)]
		public virtual string BgColor { get; private set; }

		[StringLength(100)]
		public virtual string Slug { get; private set; }

		public virtual int Order { get; private set; }

		[StringLength(100)]
		public virtual string Link { get; private set; }

		[StringLength(100)]
		public virtual string Class { get; private set; }

		[StringLength(100)]
		public virtual string ImageClass { get; private set; }

		/// <summary>
		/// 是否启用
		/// </summary>
		public bool Enabled { get; private set; }

		/// <summary>
		/// 是否删除
		/// </summary>
		public bool IsDeleted { get; private set; }

		/// <summary>
		/// 删除时间
		/// </summary>
		public DateTime? DeletionTime { get; private set; }

		public Channel(string name,
			string description,
			string icon,
			string bgColor,
			string slug,
			int order,
			string link,
			string @class,
			string imageClass,
			int parentId)
		{

			Name = name;
			Description = description;
			Icon = icon;
			BgColor = bgColor;
			Slug = slug;
			Order = order;
			Link = link;
			Class = @class;
			ImageClass = imageClass;
			ParentId = parentId;
		}

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

		#region soft delete

		public void Delete()
		{
			if (IsDeleted)
			{
				return;
			}

			IsDeleted = true;
			DeletionTime = DateTime.Now;
		}

		#endregion

		public void Change(
			[Required, MinLength(2), StringLength(50)]string name,
			[MaxLength(100)]string description,
			string icon,
			string bgColor,
			string slug,
			int order,
			string link,
			string @class,
			string imageClass,
			int parentId)
		{
			Validator.ValidateProperty(name, new ValidationContext(this));
			Name = name;
			Description = description;
			Icon = icon;
			BgColor = bgColor;
			Slug = slug;
			Order = order;
			Link = link;
			Class = @class;
			ImageClass = imageClass;
			ParentId = parentId;
		}
	}
}