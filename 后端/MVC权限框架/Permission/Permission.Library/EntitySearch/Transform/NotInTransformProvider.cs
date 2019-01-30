﻿namespace Permission.Library.EntitySearch.Transform
{
    using System;
    using System.Collections.Generic;

    public class NotInTransformProvider : ITransformProvider
    {
        public bool Match(SearchItem item, Type type)
        {
            return item.Method == SearchMethod.NotIn;
        }

        public IEnumerable<SearchItem> Transform(SearchItem item, Type type)
        {
            var arr = (item.Value as Array);
            if (arr == null)
            {
                var arrStr = item.Value.ToString();
                if (!string.IsNullOrEmpty(arrStr))
                {
                    arr = arrStr.Split(',');
                }
            }
            return new[] { new SearchItem(item.Field, SearchMethod.StdNotIn, arr) };
        }
    }
}