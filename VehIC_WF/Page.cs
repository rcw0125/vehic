namespace VehIC_WF
{
    using System;

    public enum Page
    {
        zpgz,
        Head,
        Locked,
        DeviceManage,
        RFBarcode,
        RFBarcodeEx,
        ICCard_Registry,
        ICCard_Oper,
        ICCard_MatVeh,
        ICCard_MatVehEx,
        ICCard_Multi,
        WP_Door,
        WP_GoodsSiteEx,
        WP_Sampling,
        WP_JFSampling,
        WP_HYSampling,
        WP_HYZYSampling,
    
        WP_Scales,
        WP_ScalesEx,
        Search,
        Login,
        WP_Tbzd,
        WP_Hcqy,
        /// <summary>
        /// 组批
        /// </summary> 
        WP_WKzupi,
        WP_ZuPi,
        WP_JFZuPi,
        WP_HJZuPi,
        WP_RJZuPi,
        WP_SZZuPi,
        WP_JTZuPi,
        SP_AddCheckItem,
        /// <summary>
        /// 制样
        /// </summary>
        WP_ZhiYang,
        WP_JFZhiYang,
        WP_WKZhiYang,
        WP_HJZhiYang,
        WP_RJZhiYang,
        WP_SZZhiYang,
        WP_JTZhiYang,
        /// <summary>
        /// 化验
        /// </summary>
        WP_HuaYan,
        /// <summary>
        /// 精粉化验
        /// </summary>
        WP_JFHuaYan,
        WP_WKHuaYan,
        WP_HJHuaYan,
        WP_HYHuaYan,
        /// <summary>
        /// 审核
        /// </summary>
        WP_HuaYanShenHe,
        WP_JFHuaYanShenHe,
        WP_WKHuaYanShenHe,
        WP_HJHuaYanShenHe,
        WP_HYHuaYanShenHe,
        /// <summary>
        /// 判定
        /// </summary>
        WP_PanDing,
        SP_CheckGroup,
        SP_CheckItem,
        SP_MatStandard,
        SP_QualityRule,
        SP_ICReg,
        /// <summary>
        /// 抽样
        /// </summary>
        SP_ExamineSample,
        /// <summary>
        /// 判定
        /// </summary>
        SP_QualityJudge,
        SP_JFQualityJudge,
        SP_WKQualityJudge,
        SP_HJQualityJudge,
        SP_SZQualityJudge,
        SP_RJQualityJudge,
        SP_JTQualityJudge,
        SP_HYQualityJudge,
        /// <summary>
        /// 加假样
        /// </summary>
        SP_VerifSample,
        /// <summary>
        /// 检验路径
        /// </summary>
        SP_WpRoute,
        /// <summary>
        /// 管理抽样
        /// </summary>
        SP_ManageExamineSample,
        /// <summary>
        /// 复检
        /// </summary>
        SP_ReCheck,
        /// <summary>
        /// 管理查询
        /// </summary>
        SR_Manage,
        /// <summary>
        /// 取样查询
        /// </summary>
        SR_QuYang,
        /// <summary>
        /// 制样查询
        /// </summary>
        SR_ZhiYang,
        /// <summary>
        /// 化验查询
        /// </summary>
        SR_HuaYan,
        /// <summary>
        /// 审核查询
        /// </summary>
        SR_ShenHe,
        /// <summary>
        /// 采购查询
        /// </summary>
        SR_Caigou,
        /// <summary>
        /// 综合科查询
        /// </summary>
        SR_ZongHeKe,
        /// <summary>
        /// 修改查询
        /// </summary>
        SR_Hbcx,
        SR_Xiugai,
        SR_Shangchuan,
        SR_YingGuang,
        SR_Pdyj,
        SR_Qyxx,
        SR_QYCX,
        None
    }
}

