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
	public class ChannelRepositoryTest : TestBase
	{
		private ChannelRepository GetReopsitory(string name)
		{
			return new ChannelRepository(GetDbContext(name));
		}

		string name = "channel";
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
			var repository = GetReopsitory("Channel_Create_Test");

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

		[Fact(DisplayName = "Channel_Change_To_Repository_Test")]
		public void Channel_Change_Test()
		{
			var repository = GetReopsitory("Channel_Change_Test");

			var channel = new Channel(name, description, icon, bgColor, slug, order, link, @class, imageClass, parentId);
			repository.Insert(channel);
			repository.DbContext.SaveChanges();

			var nameNew = "channelNew";
			var descriptionNew = "descriptionNew";
			var iconNew = "iconNew";
			var bgColorNew = "bgColorNew";
			var slugNew = "slugNew";
			var orderNew = 2;
			var linkNew = "linkNew";
			var @classNew = "classNew";
			var imageClassNew = "imageClassNew";
			var parentIdNew = 2;

			channel.Change(nameNew, descriptionNew, iconNew, bgColorNew, slugNew, orderNew, linkNew, @classNew, imageClassNew, parentIdNew);
			repository.Update(channel);
			repository.DbContext.SaveChanges();

			var channels = repository.GetAllList();
			// Assert
			Assert.Single(channels);
			channel = channels.First();

			Assert.Equal(nameNew, channel.Name);
			Assert.Equal(descriptionNew, channel.Description);
			Assert.Equal(iconNew, channel.Icon);
			Assert.Equal(bgColorNew, channel.BgColor);
			Assert.Equal(slugNew, channel.Slug);
			Assert.Equal(orderNew, channel.Order);
			Assert.Equal(linkNew, channel.Link);
			Assert.Equal(@classNew, channel.Class);
			Assert.Equal(imageClassNew, channel.ImageClass);
			Assert.Equal(parentIdNew, channel.ParentId);
			Assert.True(channel.IsRoot);
		}
	}
}
