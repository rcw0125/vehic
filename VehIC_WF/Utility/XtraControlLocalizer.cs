using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehIC_WF.Utility
{
    class XtraControlLocalizer : Localizer
    {
        public override string Language
        {
            get
            {
                return "Chinese";
            }
        }
        public override string GetLocalizedString(StringId id)
        {
            switch (id)
            {
                case StringId.Apply: return "应用"; //Apply 
                case StringId.CalcButtonBack: return "后退"; //Back 
                case StringId.CalcButtonC: return "C"; //C 
                case StringId.CalcButtonCE: return "CE"; //CE 
                case StringId.CalcButtonMC: return "MC"; //MC 
                case StringId.CalcButtonMR: return "MR"; //MR 
                case StringId.CalcButtonMS: return "MS"; //MS 
                case StringId.CalcButtonMx: return "M+"; //M+ 
                case StringId.CalcButtonSqrt: return "平方根"; //sqrt 
                case StringId.CalcError: return "计算错误"; //Calculation Error 
                case StringId.Cancel: return "取消"; //Cancel 
                case StringId.CaptionError: return "错误"; //Error 
                case StringId.CheckChecked: return "已经选取"; //Checked 
                case StringId.CheckIndeterminate: return "不确定"; //Indeterminate 
                case StringId.CheckUnchecked: return "非选取"; //Unchecked 
                case StringId.ColorTabCustom: return "自定义"; //Custom 
                case StringId.ColorTabSystem: return "系统"; //System 
                case StringId.ColorTabWeb: return "网页"; //Web 
                case StringId.ContainerAccessibleEditName: return "编辑控件"; //Editing control 
                case StringId.DataEmpty: return "没有图像数据"; //No image data 
                case StringId.DateEditClear: return "清除"; //Clear 
                case StringId.DateEditToday: return "今天"; //Today 
                case StringId.DefaultBooleanDefault: return "默认"; //Default 
                case StringId.DefaultBooleanFalse: return "虚假"; //False 
                case StringId.DefaultBooleanTrue: return "真实"; //True 
                case StringId.FieldListName: return "字段列表 ({0})"; //Field List ({0}) 
                case StringId.FilterAggregateAvg: return "平均"; //Avg 
                case StringId.FilterAggregateCount: return "计数"; //Count 
                case StringId.FilterAggregateExists: return "存在"; //Exists 
                case StringId.FilterAggregateMax: return "最大值"; //Max 
                case StringId.FilterAggregateMin: return "最小值"; //Min 
                case StringId.FilterAggregateSum: return "求和"; //Sum 
                case StringId.FilterClauseAnyOf: return "是下列任一项"; //Is any of 
                case StringId.FilterClauseBeginsWith: return "开头是"; //Begins with 
                case StringId.FilterClauseBetween: return "介于"; //Is between 
                case StringId.FilterClauseBetweenAnd: return "和"; //and 
                case StringId.FilterClauseContains: return "包含"; //Contains 
                case StringId.FilterClauseDoesNotContain: return "不包含"; //Does not contain 
                case StringId.FilterClauseDoesNotEqual: return "不等于"; //Does not equal 
                case StringId.FilterClauseEndsWith: return "结尾是"; //Ends with 
                case StringId.FilterClauseEquals: return "等于"; //Equals 
                case StringId.FilterClauseGreater: return "大于"; //Is greater than 
                case StringId.FilterClauseGreaterOrEqual: return "大于或等于"; //Is greater than or equal to 
                case StringId.FilterClauseIsNotNull: return "不为空"; //Is not null 
                case StringId.FilterClauseIsNotNullOrEmpty: return "不为空"; //Is not blank 
                case StringId.FilterClauseIsNull: return "为空"; //Is null 
                case StringId.FilterClauseIsNullOrEmpty: return "为空"; //Is blank 
                case StringId.FilterClauseLess: return "是少于"; //Is less than 
                case StringId.FilterClauseLessOrEqual: return "小于或等于"; //Is less than or equal to 
                case StringId.FilterClauseLike: return "包含"; //Is like 
                case StringId.FilterClauseNoneOf: return "都不是"; //Is none of 
                case StringId.FilterClauseNotBetween: return "不介于"; //Is not between 
                case StringId.FilterClauseNotLike: return "不包含"; //Is not like 
                case StringId.FilterCriteriaInvalidExpression: return "指定的表达式包含无效的符号（行 {0}，字符 {1}）。"; //The specified expression contains invalid symbols (line {0}, character {1}). 
                case StringId.FilterCriteriaInvalidExpressionEx: return "指定的表达式是无效的。"; //The specified expression is invalid. 
                case StringId.FilterCriteriaToStringBetween: return "介于"; //Between 
                case StringId.FilterCriteriaToStringBinaryOperatorBitwiseAnd: return "&"; //& 
                case StringId.FilterCriteriaToStringBinaryOperatorBitwiseOr: return "//"; //// 
                case StringId.FilterCriteriaToStringBinaryOperatorBitwiseXor: return "^"; //^ 
                case StringId.FilterCriteriaToStringBinaryOperatorDivide: return "/"; /// 
                case StringId.FilterCriteriaToStringBinaryOperatorEqual: return "="; //= 
                case StringId.FilterCriteriaToStringBinaryOperatorGreater: return "> "; //> 
                case StringId.FilterCriteriaToStringBinaryOperatorGreaterOrEqual: return ">="; //>= 
                case StringId.FilterCriteriaToStringBinaryOperatorLess: return "< "; //< 
                case StringId.FilterCriteriaToStringBinaryOperatorLessOrEqual: return "<="; //<= 
                case StringId.FilterCriteriaToStringBinaryOperatorLike: return "Like"; //Like 
                case StringId.FilterCriteriaToStringBinaryOperatorMinus: return "-"; //- 
                case StringId.FilterCriteriaToStringBinaryOperatorModulo: return "%"; //% 
                case StringId.FilterCriteriaToStringBinaryOperatorMultiply: return "*"; //* 
                case StringId.FilterCriteriaToStringBinaryOperatorNotEqual: return "<> "; //<> 
                case StringId.FilterCriteriaToStringBinaryOperatorPlus: return "+"; //+ 
                case StringId.FilterCriteriaToStringFunctionAbs: return "Abs"; //Abs 
                case StringId.FilterCriteriaToStringFunctionAcos: return "Acos"; //Acos 
                case StringId.FilterCriteriaToStringFunctionAddDays: return "添加天"; //Add days 
                case StringId.FilterCriteriaToStringFunctionAddHours: return "添加时间"; //Add hours 
                case StringId.FilterCriteriaToStringFunctionAddMilliSeconds: return "添加毫秒为单位）"; //Add milliseconds 
                case StringId.FilterCriteriaToStringFunctionAddMinutes: return "添加分钟"; //Add minutes 
                case StringId.FilterCriteriaToStringFunctionAddMonths: return "添加几个月"; //Add months 
                case StringId.FilterCriteriaToStringFunctionAddSeconds: return "增加秒数"; //Add seconds 
                case StringId.FilterCriteriaToStringFunctionAddTicks: return "添加刻度"; //Add ticks 
                case StringId.FilterCriteriaToStringFunctionAddTimeSpan: return "添加时间跨度"; //Add time span 
                case StringId.FilterCriteriaToStringFunctionAddYears: return "添加年"; //Add years 
                case StringId.FilterCriteriaToStringFunctionAscii: return "Ascii"; //Ascii 
                case StringId.FilterCriteriaToStringFunctionAsin: return "Asin"; //Asin 
                case StringId.FilterCriteriaToStringFunctionAtn: return "Atn"; //Atn 
                case StringId.FilterCriteriaToStringFunctionAtn2: return "Atn2"; //Atn2 
                case StringId.FilterCriteriaToStringFunctionBigMul: return "多大"; //Big mul 
                case StringId.FilterCriteriaToStringFunctionCeiling: return "上限"; //Ceiling 
                case StringId.FilterCriteriaToStringFunctionChar: return "字符"; //Char 
                case StringId.FilterCriteriaToStringFunctionCharIndex: return "字符索引"; //Char index 
                case StringId.FilterCriteriaToStringFunctionConcat: return "合并字符"; //Concat 
                case StringId.FilterCriteriaToStringFunctionContains: return "包含"; //Contains 
                case StringId.FilterCriteriaToStringFunctionCos: return "Cos"; //Cos 
                case StringId.FilterCriteriaToStringFunctionCosh: return "Cosh"; //Cosh 
                case StringId.FilterCriteriaToStringFunctionCustom: return "自定义"; //Custom 
                case StringId.FilterCriteriaToStringFunctionCustomNonDeterministic: return "非确定性的自定义"; //Custom non deterministic 
                case StringId.FilterCriteriaToStringFunctionDateDiffDay: return "日期比较天"; //Date diff day 
                case StringId.FilterCriteriaToStringFunctionDateDiffHour: return "日期比较小时"; //Date diff hour 
                case StringId.FilterCriteriaToStringFunctionDateDiffMilliSecond: return "日期比较毫秒"; //Date diff millisecond 
                case StringId.FilterCriteriaToStringFunctionDateDiffMinute: return "日期比较分钟"; //Date diff minute 
                case StringId.FilterCriteriaToStringFunctionDateDiffMonth: return "日期比较月"; //Date diff month 
                case StringId.FilterCriteriaToStringFunctionDateDiffSecond: return "第二日期比较"; //Date diff second 
                case StringId.FilterCriteriaToStringFunctionDateDiffTick: return "日期比较刻度线"; //Date diff tick 
                case StringId.FilterCriteriaToStringFunctionDateDiffYear: return "日期比较年"; //Date diff year 
                case StringId.FilterCriteriaToStringFunctionEndsWith: return "结尾是"; //Ends with 
                case StringId.FilterCriteriaToStringFunctionExp: return "Exp"; //Exp 
                case StringId.FilterCriteriaToStringFunctionFloor: return "下限"; //Floor 
                case StringId.FilterCriteriaToStringFunctionGetDate: return "获取日期"; //Get date 
                case StringId.FilterCriteriaToStringFunctionGetDay: return "天"; //Get day 
                case StringId.FilterCriteriaToStringFunctionGetDayOfWeek: return "获取一周中的天"; //Get day of week 
                case StringId.FilterCriteriaToStringFunctionGetDayOfYear: return "得到一年的一天"; //Get day of year 
                case StringId.FilterCriteriaToStringFunctionGetHour: return "获取小时"; //Get hour 
                case StringId.FilterCriteriaToStringFunctionGetMilliSecond: return "获取毫秒"; //Get millisecond 
                case StringId.FilterCriteriaToStringFunctionGetMinute: return "获取分钟"; //Get minute 
                case StringId.FilterCriteriaToStringFunctionGetMonth: return "一个月"; //Get month 
                case StringId.FilterCriteriaToStringFunctionGetSecond: return "获得秒"; //Get second 
                case StringId.FilterCriteriaToStringFunctionGetTimeOfDay: return "获取一天的时间"; //Get time of day 
                case StringId.FilterCriteriaToStringFunctionGetYear: return "获取一年"; //Get year 
                case StringId.FilterCriteriaToStringFunctionIif: return "Iif"; //Iif 
                case StringId.FilterCriteriaToStringFunctionInsert: return "插入"; //Insert 
                case StringId.FilterCriteriaToStringFunctionIsNull: return "IsNull"; //IsNull 
                case StringId.FilterCriteriaToStringFunctionIsNullOrEmpty: return "为 null 或空"; //Is null or empty 
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalBeyondThisYear: return "超出了本年度"; //Is beyond this year 
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalEarlierThisMonth: return "本月早些时候"; //Is earlier this month 
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalEarlierThisWeek: return "本周早些时候"; //Is earlier this week 
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalEarlierThisYear: return "今年早些时候"; //Is earlier this year 
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLastWeek: return "是上个星期"; //Is last week 
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLaterThisMonth: return "本月晚些时候"; //Is later this month 
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLaterThisWeek: return "是本周晚些时候"; //Is later this week 
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLaterThisYear: return "今年晚些时候"; //Is later this year 
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalNextWeek: return "下周"; //Is next week 
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalPriorThisYear: return "今年是事先"; //Is prior this year 
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalToday: return "今天是"; //Is today 
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalTomorrow: return "明天是"; //Is tomorrow 
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalYesterday: return "昨天是"; //Is yesterday 
                case StringId.FilterCriteriaToStringFunctionLen: return "Len"; //Len 
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeDayAfterTomorrow: return "后天"; //Day after tomorrow 
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeLastWeek: return "上个星期"; //Last week 
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeNextMonth: return "下个月"; //Next month 
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeNextWeek: return "下个 星期"; //Next week 
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeNextYear: return "明年"; //Next year 
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeNow: return "现在"; //Now 
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeThisMonth: return "本月"; //This month 
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeThisWeek: return "这一周"; //This week 
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeThisYear: return "这一年"; //This year 
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeToday: return "今天"; //Today 
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeTomorrow: return "明天"; //Tomorrow 
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeTwoWeeksAway: return "两周"; //Two weeks away 
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeYesterday: return "昨天"; //Yesterday 
                case StringId.FilterCriteriaToStringFunctionLog: return "Log"; //Log 
                case StringId.FilterCriteriaToStringFunctionLog10: return "Log10"; //Log10 
                case StringId.FilterCriteriaToStringFunctionLower: return "较低"; //Lower 
                case StringId.FilterCriteriaToStringFunctionMax: return "最大值"; //Max 
                case StringId.FilterCriteriaToStringFunctionMin: return "最小值"; //Min 
                case StringId.FilterCriteriaToStringFunctionNone: return "无"; //None 
                case StringId.FilterCriteriaToStringFunctionNow: return "现在"; //Now 
                case StringId.FilterCriteriaToStringFunctionPadLeft: return "左垫"; //Pad left 
                case StringId.FilterCriteriaToStringFunctionPadRight: return "右垫"; //Pad right 
                case StringId.FilterCriteriaToStringFunctionPower: return "电源"; //Power 
                case StringId.FilterCriteriaToStringFunctionRemove: return "删除"; //Remove 
                case StringId.FilterCriteriaToStringFunctionReplace: return "替换"; //Replace 
                case StringId.FilterCriteriaToStringFunctionReverse: return "反向"; //Reverse 
                case StringId.FilterCriteriaToStringFunctionRnd: return "Rnd"; //Rnd 
                case StringId.FilterCriteriaToStringFunctionRound: return "Round"; //Round 
                case StringId.FilterCriteriaToStringFunctionSign: return "Sign"; //Sign 
                case StringId.FilterCriteriaToStringFunctionSin: return "Sin"; //Sin 
                case StringId.FilterCriteriaToStringFunctionSinh: return "Sinh"; //Sinh 
                case StringId.FilterCriteriaToStringFunctionSqr: return "Sqr"; //Sqr 
                case StringId.FilterCriteriaToStringFunctionStartsWith: return "开头"; //Starts with 
                case StringId.FilterCriteriaToStringFunctionSubstring: return "子字符串"; //Substring 
                case StringId.FilterCriteriaToStringFunctionTan: return "Tan"; //Tan 
                case StringId.FilterCriteriaToStringFunctionTanh: return "Tanh"; //Tanh 
                case StringId.FilterCriteriaToStringFunctionToday: return "今天"; //Today 
                case StringId.FilterCriteriaToStringFunctionToDecimal: return "To decimal"; //To decimal 
                case StringId.FilterCriteriaToStringFunctionToDouble: return "To double"; //To double 
                case StringId.FilterCriteriaToStringFunctionToFloat: return "To float"; //To float 
                case StringId.FilterCriteriaToStringFunctionToInt: return "To int"; //To int 
                case StringId.FilterCriteriaToStringFunctionToLong: return "To long"; //To long 
                case StringId.FilterCriteriaToStringFunctionToStr: return "To str"; //To str 
                case StringId.FilterCriteriaToStringFunctionTrim: return "Trim"; //Trim 
                case StringId.FilterCriteriaToStringFunctionUpper: return "Upper"; //Upper 
                case StringId.FilterCriteriaToStringFunctionUtcNow: return "Utc now"; //Utc now 
                case StringId.FilterCriteriaToStringGroupOperatorAnd: return "并且"; //And 
                case StringId.FilterCriteriaToStringGroupOperatorOr: return "或"; //Or 
                case StringId.FilterCriteriaToStringIn: return "在中"; //In 
                case StringId.FilterCriteriaToStringIsNotNull: return "不为空"; //Is Not Null 
                case StringId.FilterCriteriaToStringNotLike: return "不相似"; //Not Like 
                case StringId.FilterCriteriaToStringUnaryOperatorBitwiseNot: return "~"; //~ 
                case StringId.FilterCriteriaToStringUnaryOperatorIsNull: return "为空"; //Is Null 
                case StringId.FilterCriteriaToStringUnaryOperatorMinus: return "-"; //- 
                case StringId.FilterCriteriaToStringUnaryOperatorNot: return "不是"; //Not 
                case StringId.FilterCriteriaToStringUnaryOperatorPlus: return "+"; //+ 
                case StringId.FilterDateTextAlt: return "Show all//Show Empty//Filter by a specific date,//Beyond//////Next week//Today//This week//This month//Earlier//{0,yyyy}, {0,MMMM}"; //Show all//Show Empty//Filter by a specific date,//Beyond//////Next week//Today//This week//This month//Earlier//{0,yyyy}, {0,MMMM} 
                case StringId.FilterDateTimeConstantMenuCaption: return "日期时间常数"; //Date and time constants 
                case StringId.FilterDateTimeOperatorMenuCaption: return "日期时间操作"; //Date and time operators 
                case StringId.FilterEditorTabText: return "文本"; //Text 
                case StringId.FilterEditorTabVisual: return "可见"; //Visual 
                case StringId.FilterEmptyEnter: return "< 输入值 >"; //<enter a value> 
                case StringId.FilterEmptyParameter: return "< 输入参数 >"; //<enter a parameter> 
                case StringId.FilterEmptyValue: return "<empty>"; //<empty> 
                case StringId.FilterFunctionsMenuCaption: return ""; // 
                case StringId.FilterGroupAnd: return "And"; //And 
                case StringId.FilterGroupNotAnd: return "Not And"; //Not And 
                case StringId.FilterGroupNotOr: return "Not Or"; //Not Or 
                case StringId.FilterGroupOr: return "Or"; //Or 
                case StringId.FilterMenuAddNewParameter: return "添加一个新的参数..."; //Add a new parameter ... 
                case StringId.FilterMenuClearAll: return "全部清除"; //Clear All 
                case StringId.FilterMenuConditionAdd: return "添加条件"; //Add Condition 
                case StringId.FilterMenuGroupAdd: return "添加组"; //Add Group 
                case StringId.FilterMenuRowRemove: return "删除组"; //Remove Group 
                case StringId.FilterOutlookDateText: return "显示全部//Show Empty//依下列日期筛选://除今年之外//晚于今年//晚于本月//下周//晚于本周//明天//今天//昨天//本周之前//上周//本月之前//今年之前//去年"; //Show all//Show Empty//Filter by a specific date,//Beyond this year//Later this year//Later this month//Next week//" + "Later this week//Tomorrow//Today//Yesterday//Earlier this week//Last week//Earlier this month//Earlier this year//" + "Prior to this year 
                case StringId.FilterShowAll: return "（选择所有）"; //(Select All) 
                case StringId.FilterToolTipElementAdd: return "将新项添加到列表中"; //Adds a new item to the list 
                case StringId.FilterToolTipKeysAdd: return "（使用插入或添加键）"; //(Use the Insert or Add key) 
                case StringId.FilterToolTipKeysRemove: return "（使用删除或减去键）"; //(Use the Delete or Subtract key) 
                case StringId.FilterToolTipNodeAction: return "行动"; //Actions 
                case StringId.FilterToolTipNodeAdd: return "向该组添加一个新的条件"; //Adds a new condition to this group 
                case StringId.FilterToolTipNodeRemove: return "删除此条件"; //Removes this condition 
                case StringId.FilterToolTipValueType: return "比较值 / 另一个字段的值"; //Compare with a value / another field//s value 
                case StringId.ImagePopupEmpty: return "(空)"; //(Empty) 
                case StringId.ImagePopupPicture: return "(图像)"; //(Picture) 
                case StringId.InvalidValueText: return "无效值"; //Invalid Value 
                case StringId.LookUpColumnDefaultName: return "名称"; //Name 
                case StringId.LookUpEditValueIsNull: return "[编辑值为空]"; //[EditValue is null] 
                case StringId.LookUpInvalidEditValueType: return "无效的 LookUpEdit 编辑值类型。"; //Invalid LookUpEdit EditValue type. 
                case StringId.MaskBoxValidateError: return "输入值不完整,是否修正? 是 - 返回编辑器,修正该值. 否 -保留该值. 取消 - 重设为原来的值. "; //The entered value is incomplete. Do you want to correct it?\r\n\r\n" +"Yes - to the editor and correct the value.\r\n" +"No - leave the value as is.\r\n" +"Cancel - reset to the previous value.\r\n 
                case StringId.NavigatorAppendButtonHint: return "追加"; //Append 
                case StringId.NavigatorCancelEditButtonHint: return "取消编辑"; //Cancel Edit 
                case StringId.NavigatorEditButtonHint: return "编辑"; //Edit 
                case StringId.NavigatorEndEditButtonHint: return "结束编辑"; //End Edit 
                case StringId.NavigatorFirstButtonHint: return "第一个"; //First 
                case StringId.NavigatorLastButtonHint: return "最后一个"; //Last 
                case StringId.NavigatorNextButtonHint: return "下一个"; //Next 
                case StringId.NavigatorNextPageButtonHint: return "下一页"; //Next Page 
                case StringId.NavigatorPreviousButtonHint: return "前一个"; //Previous 
                case StringId.NavigatorPreviousPageButtonHint: return "前一页"; //Previous Page 
                case StringId.NavigatorRemoveButtonHint: return "删除"; //Delete 
                case StringId.NavigatorTextStringFormat: return "第{0}行({1})"; //Record {0} of {1} 
                case StringId.None: return ""; // 
                case StringId.NotValidArrayLength: return "无效的数组长度。"; //Not valid array length. 
                case StringId.OK: return "确定(&O)"; //OK 
                case StringId.PictureEditCopyImageError: return "无法复制图像"; //Could not copy image 
                case StringId.PictureEditMenuCopy: return "复制"; //Copy 
                case StringId.PictureEditMenuCut: return "剪切"; //Cut 
                case StringId.PictureEditMenuDelete: return "删除"; //Delete 
                case StringId.PictureEditMenuFitImage: return "图像尺寸调整"; //Fit Image 
                case StringId.PictureEditMenuFullSize: return "全尺寸"; //Full Size 
                case StringId.PictureEditMenuLoad: return "调用"; //Load 
                case StringId.PictureEditMenuPaste: return "粘贴"; //Paste 
                case StringId.PictureEditMenuSave: return "保存"; //Save 
                case StringId.PictureEditMenuZoom: return "缩放"; //Zoom 
                case StringId.PictureEditMenuZoomIn: return "放大"; //Zoom In 
                case StringId.PictureEditMenuZoomOut: return "缩小"; //Zoom Out 
                case StringId.PictureEditMenuZoomTo: return "缩放到"; //Zoom to 
                case StringId.PictureEditMenuZoomToolTip: return "{0}%"; //{0}% 
                case StringId.PictureEditOpenFileError: return "错误的图像格式"; //Wrong picture format 
                case StringId.PictureEditOpenFileErrorCaption: return "打开错误"; //Open error 
                case StringId.PictureEditOpenFileFilter: return "Bitmap Files (*.bmp)|*.bmp//" + "Graphics Interchange Format (*.gif)|*.gif//" + "JPEG File Interchange Format (*.jpg;*.jpeg)|*.jpg;*.jpeg//" + "Icon Files (*.ico)|*.ico//" + "All Picture Files; //*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif//" + "All Files; //*.*"; //Bitmap Files (*.bmp)|*.bmp//" +"Graphics Interchange Format (*.gif)|*.gif//" +"JPEG File Interchange Format (*.jpg;*.jpeg)|*.jpg;*.jpeg//" +"Icon Files (*.ico)|*.ico//" +"All Picture Files; //*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif//" +"All Files; //*.* 
                case StringId.PictureEditOpenFileTitle: return "打开"; //Open 
                case StringId.PictureEditSaveFileFilter: return "Bitmap Files (*.bmp)|*.bmp//" + "Graphics Interchange Format (*.gif)|*.gif//" + "JPEG File Interchange Format (*.jpg)|*.jpg"; //Bitmap Files (*.bmp)|*.bmp//" +"Graphics Interchange Format (*.gif)|*.gif//" +"JPEG File Interchange Format (*.jpg)|*.jpg 
                case StringId.PictureEditSaveFileTitle: return "另存为"; //Save As 
                case StringId.PreviewPanelText: return "预览"; //Preview 
                case StringId.ProgressCancel: return "取消"; //Cancel 
                case StringId.ProgressCancelPending: return "取消挂起"; //Cancel pending 
                case StringId.ProgressCreateDocument: return "创建文档"; //Creating document 
                case StringId.ProgressExport: return "导出"; //Exporting 
                case StringId.ProgressLoadingData: return "加载数据"; //Loading data 
                case StringId.ProgressPrinting: return "打印"; //Printing 
                case StringId.RestoreLayoutDialogFileFilter: return "XML files (*.xml)|*.xml//All files//*.*"; //XML files (*.xml)|*.xml//All files//*.* 
                case StringId.RestoreLayoutDialogTitle: return "恢复布局"; //Restore Layout 
                case StringId.SaveLayoutDialogFileFilter: return "XML files (*.xml)|*.xml"; //XML files (*.xml)|*.xml 
                case StringId.SaveLayoutDialogTitle: return "保存布局"; //Save Layout 
                case StringId.TabHeaderButtonClose: return "关闭"; //Close 
                case StringId.TabHeaderButtonNext: return "向右滚动"; //Scroll Right 
                case StringId.TabHeaderButtonPrev: return "向左滚动"; //Scroll Left 
                case StringId.TabHeaderSelectorButton: return "显示窗口列表"; //Show Window List 
                case StringId.TextEditMenuCopy: return "复制(&C)"; //&Copy 
                case StringId.TextEditMenuCut: return "剪切(&t)"; //Cu&t 
                case StringId.TextEditMenuDelete: return "删除(&D)"; //&Delete 
                case StringId.TextEditMenuPaste: return "粘贴(&P)"; //&Paste 
                case StringId.TextEditMenuSelectAll: return "全选(&A)"; //Select &All 
                case StringId.TextEditMenuUndo: return "撤销(&U)"; //&Undo 
                case StringId.TransparentBackColorNotSupported: return "此控件不支持透明背景色"; //This control does not support transparent background colors 
                case StringId.UnknownPictureFormat: return "未知的图形格式"; //Unknown picture format 
                case StringId.XtraMessageBoxAbortButtonText: return "中断(&A)"; //&Abort 
                case StringId.XtraMessageBoxCancelButtonText: return "取消"; //&Cancel 
                case StringId.XtraMessageBoxIgnoreButtonText: return "忽略(&I)"; //&Ignore 
                case StringId.XtraMessageBoxNoButtonText: return "否(&N)"; //&No 
                case StringId.XtraMessageBoxOkButtonText: return "确定(&O)"; //&OK 
                case StringId.XtraMessageBoxRetryButtonText: return "重试(&R)"; //&Retry 
                case StringId.XtraMessageBoxYesButtonText: return "是(&Y)"; //&Yes 
            }
            return base.GetLocalizedString(id);
        }
    }
}
