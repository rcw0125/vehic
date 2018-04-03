using DevExpress.XtraGrid.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehIC_WF.Utility
{
    public class XtraGridLocalizer : GridLocalizer
    {
        public override string Language
        {
            get
            {
                return "Chinese";
            }
        }
        public override string GetLocalizedString(GridStringId id)
        {
            switch (id)
            {
                case GridStringId.FileIsNotFoundError:  return "文件{0}没有找到";
                case GridStringId.ColumnViewExceptionMessage: return "是否确定修改？";
                case GridStringId.CustomizationCaption:  return "自定义显示字段";
                case GridStringId.CustomizationColumns:   return "列";
                case GridStringId.CustomizationBands:
                    return "分区";
                case GridStringId.PopupFilterAll:
                    return "(所有)";
                case GridStringId.PopupFilterCustom:
                    return "(自定义)";
                case GridStringId.PopupFilterBlanks:
                    return "(空值)";
                case GridStringId.PopupFilterNonBlanks:
                    return "(非空值)";
                case GridStringId.CustomFilterDialogFormCaption:
                    return "自定义筛选条件";
                case GridStringId.CustomFilterDialogCaption:
                    return "条件为:";
                case GridStringId.CustomFilterDialogRadioAnd:
                    return "并且";
                case GridStringId.CustomFilterDialogRadioOr:
                    return "或者";
                case GridStringId.CustomFilterDialogOkButton:
                    return "确定(&O)";
                case GridStringId.CustomFilterDialogClearFilter:
                    return "清除筛选条件(&L)";
                case GridStringId.CustomFilterDialog2FieldCheck:
                    return "字段";
                case GridStringId.CustomFilterDialogCancelButton:
                    return "取消(&C)";
                case GridStringId.MenuFooterSum:
                    return "合计";
                case GridStringId.MenuFooterMin:
                    return "最小";
                case GridStringId.MenuFooterMax:
                    return "最大";
                case GridStringId.MenuFooterCount:
                    return "计数";
                case GridStringId.MenuFooterAverage:
                    return "平均";
                case GridStringId.MenuFooterNone:
                    return "空";
                case GridStringId.MenuFooterSumFormat:
                    return "合计={0:#.##}";
                case GridStringId.MenuFooterMinFormat:
                    return "最小={0}";
                case GridStringId.MenuFooterMaxFormat:
                    return "最大={0}";
                case GridStringId.MenuFooterCountFormat:
                    return "{0}";
                case GridStringId.MenuFooterAverageFormat:
                    return "平均={0:#.##}";
                case GridStringId.MenuColumnSortAscending:
                    return ";升序排序";
                case GridStringId.MenuColumnSortDescending:
                    return ";降序排序";
                case GridStringId.MenuColumnGroup:
                    return ";按此列分组";
                case GridStringId.MenuColumnUnGroup:
                    return ";取消分组";
                case GridStringId.MenuColumnColumnCustomization:
                    return ";显示/隐藏字段";
                case GridStringId.MenuColumnBestFit:
                    return ";自动调整字段宽度";
                case GridStringId.MenuColumnFilter:
                    return ";筛选";
                case GridStringId.MenuColumnClearFilter:
                    return ";清除筛选条件";
                case GridStringId.MenuColumnBestFitAllColumns:
                    return ";自动调整所有字段宽度";
                case GridStringId.MenuGroupPanelFullExpand:
                    return ";展开全部分组";
                case GridStringId.MenuGroupPanelFullCollapse:
                    return ";收缩全部分组";
                case GridStringId.MenuGroupPanelClearGrouping:
                    return ";清除所有分组";
                case GridStringId.PrintDesignerGridView:
                    return ";打印设置(表格模式)";
                case GridStringId.PrintDesignerCardView:
                    return ";打印设置(卡片模式)";
                case GridStringId.PrintDesignerBandedView:
                    return ";打印设置(区域模式)";
                case GridStringId.PrintDesignerBandHeader:
                    return ";区标题";
                case GridStringId.MenuColumnGroupBox:
                    return ";显示/隐藏分组区";
                case GridStringId.CardViewNewCard:
                    return ";新卡片";
                case GridStringId.CardViewQuickCustomizationButton:
                    return ";自定义格式";
                case GridStringId.CardViewQuickCustomizationButtonFilter:
                    return ";筛选";
                case GridStringId.CardViewQuickCustomizationButtonSort:
                    return ";排序:";
                case GridStringId.GridGroupPanelText:
                    return "拖动列标题到这进行分组";
                case GridStringId.GridNewRowText:
                    return "新增资料";
                case GridStringId.GridOutlookIntervals:
                    return "一个月以上;上个月;三周前;两周前;上周;;;;;;;;昨天;今天;明天; ;;;;;;;下周;两周后;三周后;下个月;一个月之后;";
                case GridStringId.PrintDesignerDescription:
                    return "为当前视图设置不同的打印选项.";
                case GridStringId.MenuFooterCustomFormat:
                    return "自定={0}";
                case GridStringId.MenuFooterCountGroupFormat:
                    return "计数={0}";
                case GridStringId.MenuColumnClearSorting:
                    return "清除排序";
                case GridStringId.FilterPanelCustomizeButton:
                    return "自定义";
                case GridStringId.FindControlClearButton:
                    return "清空";
                case GridStringId.FindControlFindButton:
                    return "查找";
                default:
                    break;
            }
            return base.GetLocalizedString(id);
        }
    }
}
