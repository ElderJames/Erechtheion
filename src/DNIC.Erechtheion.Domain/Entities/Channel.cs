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
	/// <summary>
	/// 频道、分类
	/// </summary>
	[Serializable]
	public class Channel : AuditedEntity, ITree<Channel, int>, IDisable, ISoftDelete
	{
		/// <summary>
		/// 是否根节点
		/// </summary>
		public bool IsRoot => ParentNode == null;

		/// <summary>
		/// 是否叶子节点
		/// </summary>
		public bool IsLeaf => !ChildNodes.Any();

		/// <summary>
		/// 父节点编号
		/// </summary>
		public virtual int ParentId { get; private set; }

		/// <summary>
		/// 父节点对象
		/// </summary>
		public virtual Channel ParentNode { get; }

		/// <summary>
		/// 子节点
		/// </summary>
		public virtual ICollection<Channel> ChildNodes { get; }

		/// <summary>
		/// 频道名称
		/// </summary>
		[Required]
		[MinLength(2)]
		[StringLength(50)]
		public virtual string Name { get; private set; }

		/// <summary>
		/// 频道描述
		/// </summary>
		[StringLength(500)]
		public virtual string Description { get; private set; }

		/// <summary>
		/// 频道在UI上的ICON
		/// </summary>
		[StringLength(100)]
		public virtual string Icon { get; private set; }

		/// <summary>
		/// 频道在UI上的背景色
		/// </summary>
		[StringLength(100)]
		public virtual string BgColor { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		[StringLength(100)]
		public virtual string Slug { get; private set; }

		/// <summary>
		/// 频道排序
		/// </summary>
		public virtual int Order { get; private set; }

		/// <summary>
		/// 频道链接
		/// </summary>
		[StringLength(100)]
		public virtual string Link { get; private set; }

		/// <summary>
		/// 频道在UI上 Css 的 Class
		/// </summary>
		[StringLength(100)]
		public virtual string Class { get; private set; }

		/// <summary>
		/// 频道图标在UI上C ss 的 Class
		/// </summary>
		[StringLength(100)]
		public virtual string ImageClass { get; private set; }

		/// <summary>
		/// 频道的所有内容
		/// </summary>
		public virtual IEnumerable<AbstractContent> Contents { get; }

		/// <summary>
		/// 是否启用
		/// </summary>
		public virtual bool Enabled { get; private set; }

		/// <summary>
		/// 是否删除
		/// </summary>
		public virtual bool Deleted { get; private set; }

		/// <summary>
		/// 删除时间
		/// </summary>
		public DateTime? DeletionTime { get; private set; }

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
			if (Deleted)
			{
				return;
			}

			Deleted = true;
			DeletionTime = DateTime.Now;
		}

		#endregion

		public Channel() { }

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

		public void Change(
			string name,
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
	}
}