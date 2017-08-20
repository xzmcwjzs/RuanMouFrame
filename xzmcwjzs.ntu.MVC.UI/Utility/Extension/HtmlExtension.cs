﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace xzmcwjzs.ntu.MVC.UI.Utility.Extension
{
    public static class HtmlExtension
    {
        /// <summary>
        /// 自定义一个@html.Submit()
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="value">value属性</param>
        /// <param name="defaultClass">预设的class</param>
        /// <returns></returns>
        public static MvcHtmlString Submit(this HtmlHelper helper, string value, string defaultClass = "btn btn-default")
        {
            var builder = new TagBuilder("input");
            builder.MergeAttribute("type", "submit");
            builder.MergeAttribute("value", value);
            builder.MergeAttribute("class", defaultClass);
            builder.ToString(TagRenderMode.EndTag);
            return MvcHtmlString.Create(builder.ToString());
        }

        /// <summary>
        /// 换行
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static MvcHtmlString Br(this HtmlHelper helper)
        {
            var builder = new TagBuilder("br");

            //builder.ToString(TagRenderMode.SelfClosing);//生成<br><br>
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string src, string alt, string title, object htmlAttributes, string defaultClass = "btn btn-default")
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", alt);
            builder.MergeAttribute("title", title);
            builder.MergeAttribute("class", defaultClass);
            builder.MergeAttributes<string, object>(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Link(this HtmlHelper helper, string href, string linkText, string defaultClass = "btn btn-default")
        {
            var builder = new TagBuilder("a");
            builder.MergeAttribute("href", href);
            builder.SetInnerText(linkText);
            builder.MergeAttribute("class", defaultClass);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string id, string text, string onClick = null)
        {
            var builder = new TagBuilder("input");
            builder.GenerateId(id);
            builder.MergeAttribute("type", "button");
            builder.MergeAttribute("value", text);
            if (!string.IsNullOrWhiteSpace(onClick)) builder.MergeAttribute("onclick", onClick);
            builder.MergeAttribute("id", id);
            builder.MergeAttribute("name", id);
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}