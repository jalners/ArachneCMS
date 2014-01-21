///TODO:
using System;
using System.Web;
using System.Collections.Generic;

namespace WWW.ViewModels
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class PageModel
    {
        private HttpContextBase _HttpContext = null;
        /// <summary>
        /// TODO:
        /// </summary>
        public HttpContextBase HttpContext
        {
            get
            {
                return _HttpContext;
            }
        }

        private PageMetaModel _Meta = null;
        /// <summary>
        /// TODO:
        /// </summary>
        public PageMetaModel Meta
        {
            get
            {
                if (_Meta == null)
                {
                    _Meta = new PageMetaModel();
                }

                return _Meta;
            }
        }

        private bool? _IsGlobalSite = null;
        /// <summary>
        /// TODO:
        /// </summary>
        public bool IsGlobalSite
        {
            get
            {
                if (_IsGlobalSite == null)
                {
                    _IsGlobalSite = _HttpContext.Request.Url.Host
                        .EndsWith("arachne-cms.com", StringComparison.InvariantCultureIgnoreCase)
                    ;
                }

                return _IsGlobalSite.Value;
            }
        }

        private string _BrowserCss = null;
        public string BrowserCss
        {
            get
            {
                if (_BrowserCss == null)
                {
                    var caps = _HttpContext.Request.Browser;
                    if (caps != null)
                    {
                        _BrowserCss = string.Concat(caps.Browser.ToLower(), " ", caps.Browser.ToLower(), caps.MajorVersion);
                    }
                    else
                    {
                        _BrowserCss = string.Empty;
                    }
                }

                return _BrowserCss;
            }
        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="context"></param>
        public PageModel(HttpContextBase context)
        {
            _HttpContext = context;
        }
    }
}
