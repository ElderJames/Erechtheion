using DNIC.Erechtheion.Core.Validations;
using DNIC.Erechtheion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DNIC.Erechtheion.Tests
{
	public class ChannelTests
	{
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

		[Fact(DisplayName = "Channel_Create_Test")]
		public void Channel_Create_Test()
		{
			var channel = new Channel(name, description, icon, bgColor, slug, order, link, @class, imageClass, parentId);

			// Assert
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

		[Fact(DisplayName = "Channel_Change_Test")]
		public void Channel_Change_Test()
		{
			var name = "channel";
			var description = "description";
			var icon = "icon";
			var bgColor = "bgColor";
			var slug = "slug";
			var order = 1;
			var link = "link";
			var @class = "class";
			var imageClass = "imageClass";
			var parentId = 1;

			var channel = new Channel(name, description, icon, bgColor, slug, order, link, @class, imageClass, parentId);

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

			// Assert
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

		[Fact(DisplayName = "Channel_Validate_Name_Test")]
		public void Channel_Validate_Name_Required_Test()
		{
			var name = "";
			var channel = new Channel(name, description, icon, bgColor, slug, order, link, @class, imageClass, parentId);
			var validationResultCollection = DataAnnotationValidation.Validate(channel);

			Assert.Equal(1, validationResultCollection.Count);
			Assert.Equal("The Name field is required.", validationResultCollection.First().ErrorMessage);
		}

		[Fact(DisplayName = "Channel_Validate_Name_Range_Test")]
		public void Channel_Validate_Name_Range_Test()
		{
			var name = "2";
			var channel = new Channel(name, description, icon, bgColor, slug, order, link, @class, imageClass, parentId);
			var validationResultCollection = DataAnnotationValidation.Validate(channel);

			Assert.Equal(1, validationResultCollection.Count);
			Assert.Equal("The field Name must be a string or array type with a minimum length of '2'.", validationResultCollection.First().ErrorMessage);

			name = "2222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222";
			channel.Change(name, description, icon, bgColor, slug, order, link, @class, imageClass, parentId);

			validationResultCollection = DataAnnotationValidation.Validate(channel);
			Assert.Equal(1, validationResultCollection.Count);
			Assert.Equal("The field Name must be a string with a maximum length of 50.", validationResultCollection.First().ErrorMessage);
		}
	}
}
