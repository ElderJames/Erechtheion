using DNIC.Erechtheion.QuerySerivces.QueryServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DNIC.Erechtheion.Tests.Query
{
	public class TopicQuerySerivceTest : TestBase
	{
		[Fact(DisplayName = "Topic_Query_All")]
		public void QueryAll()
		{
			var topicQuerySerivce = ServiceProvider.GetRequiredService<ITopicQuerySerivce>();
			var a = topicQuerySerivce.GetAll();
		}
	}
}
