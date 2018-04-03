namespace VehIC_WF
{
    using System;
    using VehIC_BL;

    public class WorkPointInfo
    {
        public string Code = string.Empty;
        /// <summary>
        /// 启用
        /// </summary>
        public bool Enable = true;

        public string Name = string.Empty;
        /// <summary>
        /// 审核
        /// </summary>
        public bool SH = false;

        public RouteNodeType type;
        public string TypeCode = string.Empty;
        public string TypeDesc = string.Empty;

        public bool Available()
        {
            return (this.SH && this.Enable);
        }

    }
}

