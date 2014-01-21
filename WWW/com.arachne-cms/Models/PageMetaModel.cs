///TODO:
using System;
using System.Text;

namespace WWW.ViewModels
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class PageMetaModel
    {
        /// <summary>
        /// TODO:
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// TODO:
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// TODO:
        /// </summary>
        public string Keywords
        {
            get;
            set;
        }

        /// <summary>
        /// TODO:
        /// </summary>
        public bool RobotIndex
        {
            get;
            set;
        }

        /// <summary>
        /// TODO:
        /// </summary>
        public bool RobotFollow
        {
            get;
            set;
        }

        /// <summary>
        /// TODO:
        /// </summary>
        public bool HasDescription
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.Description);
            }
        }

        /// <summary>
        /// TODO:
        /// </summary>
        public bool HasKeywords
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.Keywords);
            }
        }

        /// <summary>
        /// TODO:
        /// </summary>
        public bool HasRobots
        {
            get
            {
                return !(this.RobotIndex && this.RobotFollow);
            }
        }

        /// <summary>
        /// TODO:
        /// </summary>
        public string Robots
        {
            get
            {
                StringBuilder result = new StringBuilder(64);

                if (!this.RobotIndex)
                {
                    result.Append("noindex");
                }

                if (!this.RobotFollow)
                {
                    if (result.Length > 0)
                    {
                        result.Append(", ");
                    }

                    result.Append("nofollow");
                }

                return result.ToString();
            }
        }

        /// <summary>
        /// TODO:
        /// </summary>
        public PageMetaModel()
        {
            this.RobotIndex = true;
            this.RobotFollow = true;
        }
    }
}
