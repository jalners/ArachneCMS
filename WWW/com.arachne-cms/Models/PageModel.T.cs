///TODO:
using System;
using System.Web;
using System.Collections.Generic;

namespace WWW.ViewModels
{
    /// <summary>
    /// TODO:
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageModel<T> : WWW.ViewModels.PageModel
    {
        private T _Data = default(T);
        /// <summary>
        /// TODO:
        /// </summary>
        public T Data
        {
            get
            {
                return _Data;
            }
        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="context"></param>
        /// <param name="data"></param>
        public PageModel(HttpContextBase context, T data)
            : base(context)
        {
            _Data = data;
        }
    }
}
