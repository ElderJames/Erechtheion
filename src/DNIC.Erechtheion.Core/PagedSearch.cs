using System;

namespace DNIC.Erechtheion.Core
{
    public class PagedSearch
    {
        private int pageSize = 15;
        private int pageNow = 1;

        /// <summary>
        /// 索引开始
        /// </summary>
        public virtual int StartIndex => (pageNow - 1) * pageSize;

        /// <summary>
        /// 索引结束
        /// </summary>
        public virtual int EndIndex => pageNow * pageSize;

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize
        {
            get => pageSize;
            set => pageSize = value;
        }

        /// <summary>
        /// 第几页
        /// </summary>
        public int PageNow
        {
            get => pageNow;
            set => pageNow = value;
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
}