using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DNIC.Erechtheion.Tests.Repository
{
	public class ChannelTests : TestBase
	{
		private ChannelRepository GetReopsitory()
		{
			return new ChannelRepository(GetDbContext("ContentChannels"));
		}

		string name = "c";
		string description = "description";
		string icon = "icon";
		string bgColor = "bgColor";
		string slug = "slug";
		int order = 1;
		string link = "link";
		string @class = "class";
		string imageClass = "imageClass";
		int parentId = 1;

		[Fact(DisplayName = "Channel_Create_To_Repository_Test")]
		public void Channel_Create_Test()
		{
			var repository = GetReopsitory();

			var channel = new Channel(name, description, icon, bgColor, slug, order, link, @class, imageClass, parentId);
			repository.Insert(channel);
			repository.DbContext.SaveChanges();

			var channels = repository.GetAllList();

			// Assert
			Assert.Single(channels);
			channel = channels.First();

			Assert.Equal(name, channel.Name);
			Assert.Equal(description, channel.Description);
			Assert.Equal(icon, channel.Icon);
			Assert.Equal(bgColor, channel.BgColor);
			Assert.Equal(slug, channel.Slug);
			Assert.Equal(order, channel.Order);
			Assert.Equal(link, channel.Link);
			Assert.Equal(@class, channel.Class);
			Assert.Equal(imageClass, channel.ImageClass);
			Assert.Equal(parentId, channel.ParentId);
			Assert.True(channel.IsRoot);
		}
	}
}
