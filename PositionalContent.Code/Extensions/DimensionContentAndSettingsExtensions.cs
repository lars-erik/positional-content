﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Umbraco.Web;

using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Hifi.PositionalContent
{

    public static class DimensionContentAndSettingsExtensions
    {
        
        //Dimemsion Content
        public static IList<IPublishedContent> GetContents(this PositionalContentItemDimension dimension, Guid dtdGuid)
        {
            var contents = dimension.Content<List<IPublishedContent>>(dtdGuid);
            if (contents == null)
                return new List<IPublishedContent>() { dimension.Content<IPublishedContent>(dtdGuid) }.Where(x => x != null).ToList();
            else
                return contents;
        }

        public static IPublishedContent GetContent(this PositionalContentItemDimension dimension, Guid dtdGuid)
        {
            return dimension.GetContents(dtdGuid).FirstOrDefault();
        }

        public static IList<IPublishedContent> GetContents(this PositionalContentItemDimension dimension, PositionalContentModel model)
        {
            return dimension.GetContents(model.DtdGuid);
        }

        public static IPublishedContent GetContent(this PositionalContentItemDimension dimension, PositionalContentModel model)
        {
            return dimension.GetContent(model.DtdGuid);
        }

        public static IEnumerable<E> GetContents<E>(this PositionalContentItemDimension dimension, PositionalContentModel model)
        where E : PublishedContentModel
        {
            var content = dimension.GetContents(model);
            return content.Select(x => x.ToModel<E>());
        }

        public static E GetContent<E>(this PositionalContentItemDimension dimension, PositionalContentModel model)
            where E : PublishedContentModel
        {
            var content = dimension.GetContent(model);
            return content.ToModel<E>();
        }

        //Dimemsion Settings
        public static IList<IPublishedContent> GetSettings(this PositionalContentItemDimension dimension, Guid dtdGuid)
        {
            var settings = dimension.Settings<List<IPublishedContent>>(dtdGuid);
            if (settings == null)
                return new List<IPublishedContent>() { dimension.Settings<IPublishedContent>(dtdGuid) }.Where(x => x != null).ToList();
            else
                return settings;
        }

        public static IPublishedContent GetSetting(this PositionalContentItemDimension dimension, Guid dtdGuid)
        {
            return dimension.GetSettings(dtdGuid).FirstOrDefault();
        }

        public static IList<IPublishedContent> GetSettings(this PositionalContentItemDimension dimension, PositionalContentModel model)
        {
            return dimension.GetSettings(model.DtdGuid);
        }

        public static IPublishedContent GetSetting(this PositionalContentItemDimension dimension, PositionalContentModel model)
        {
            return dimension.GetSetting(model.DtdGuid);
        }

        public static IEnumerable<E> GetSettings<E>(this PositionalContentItemDimension dimension, PositionalContentModel model)
        where E : PublishedContentModel
        {
            var content = dimension.GetSettings(model);
            return content.Select(x => x.ToModel<E>());
        }

        public static E GetSetting<E>(this PositionalContentItemDimension dimension, PositionalContentModel model)
            where E : PublishedContentModel
        {
            var content = dimension.GetSetting(model);
            return content.ToModel<E>();
        }

    }

}

