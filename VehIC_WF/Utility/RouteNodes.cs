namespace VehIC_WF.Utility
{
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Windows.Forms;
    using VehIC_BL.Utility;
    using VehIC_WF.CommonService;

    public class RouteNodes : CollectionBase
    {
        public int InvCount = 0;

        public void Add(RouteNode sigle)
        {
            base.List.Add(sigle);
        }

        public void Add(RouteNode[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                base.List.Add(list[i]);
            }
            this.InvCount++;
        }

        public bool ContainCurDoorWorkPoint(string wpcode)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].wctype == RouteNodeType.door)
                {
                    for (int j = 0; j < this[i].wclist.Length; j++)
                    {
                        if (this[i].wclist[j].Trim() == wpcode)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool ContainGoodsSite()
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].wctype == RouteNodeType.goodssite)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainWeigh()
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (this[i].wctype == RouteNodeType.scales)
                {
                    return true;
                }
            }
            return false;
        }

        public void Merge(bool needweigh)
        {
            int num2;
            RouteNode node;
            if (needweigh)
            {
                if (this.InvCount > 1)
                {
                    bool flag = false;
                    int invXH = -1;
                    for (num2 = base.Count - 1; num2 > 0; num2--)
                    {
                        node = this[num2];
                        if (invXH == -1)
                        {
                            invXH = node.InvXH;
                        }
                        if (node.InvXH != invXH)
                        {
                            flag = false;
                            invXH = node.InvXH;
                        }
                        if (node.wctype == RouteNodeType.scales)
                        {
                            if (!flag)
                            {
                                flag = true;
                            }
                            else
                            {
                                this.Remove(num2);
                                flag = false;
                            }
                        }
                    }
                    for (num2 = base.Count - 2; num2 > 0; num2--)
                    {
                        node = this[num2];
                        if ((node.wctype == RouteNodeType.door) && (this[num2 + 1].wctype == RouteNodeType.door))
                        {
                            int num3 = base.Count - 1;
                            this[0].wclist = VehIC_BL.Utility.Common.Merge(this[0].wclist, this[num2].wclist);
                            this[num3].wclist = VehIC_BL.Utility.Common.Merge(this[num3].wclist, this[num2 + 1].wclist);
                            this.Remove(num2 + 1);
                            this.Remove(num2);
                        }
                    }
                }
            }
            else if (this.InvCount > 1)
            {
                for (num2 = base.Count - 2; num2 > 0; num2--)
                {
                    node = this[num2];
                    if ((node.wctype == RouteNodeType.door) && (this[num2 + 1].wctype == RouteNodeType.door))
                    {
                        this[base.Count - 1].wclist = VehIC_BL.Utility.Common.Merge(this[base.Count - 1].wclist, this[num2 + 1].wclist);
                        this[0].wclist = VehIC_BL.Utility.Common.Merge(this[0].wclist, this[num2].wclist);
                        this.Remove(num2 + 1);
                        this.Remove(num2);
                    }
                }
                for (num2 = base.Count - 3; num2 > 1; num2--)
                {
                    if (VehIC_BL.Utility.Common.Equal(this[num2].wclist, this[num2 + 1].wclist))
                    {
                        this.Remove(num2 + 1);
                        this[num2].InvCode = string.Empty;
                        this[num2].InvName = string.Empty;
                    }
                }
            }
        }

        public void Remove(int index)
        {
            if ((index > (base.Count - 1)) || (index < 0))
            {
                MessageBox.Show("删除对象时索引无效！");
            }
            else
            {
                base.List.RemoveAt(index);
            }
        }

        public RouteNode this[int index]
        {
            get
            {
                return (RouteNode) base.List[index];
            }
            set
            {
                base.List[index] = value;
            }
        }
    }
}

