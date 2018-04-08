using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DNIC.Erechtheion.Domain.Entities
{
	public class Topic : AuditedEntity<long>
	{
		[Required]
		[StringLength(32)]
		public virtual string Name { get; set; }
	}
}
