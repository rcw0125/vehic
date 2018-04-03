using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Web;
using System.Net;
using System.Configuration;
using System.Reflection;
using System.Xml.Serialization;

namespace VehIC_WF.Sampling.Nc
{
    public class TelComm1
    {
        //public static string NCServer = @"http://192.168.2.36:80/service/XChangeServlet?account=001&receiver=101";
         //public static string NCServer = @"http://192.168.27.15:80/service/XChangeServlet?account=1&receiver=101";
          
        public static string NCServer = @"http://192.168.2.68:80/service/XChangeServlet?account=1&receiver=101";
        public static string TranslateDataSetToNC(string strxslt, DataSet data)
        {
            System.Xml.Xsl.XslCompiledTransform trans = new System.Xml.Xsl.XslCompiledTransform();
            trans.Load(strxslt);
            string strTmpDir = Path.GetTempPath();
            //string strLogDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DataSent");
            string strLogDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string strDataFile = Path.Combine(strTmpDir, "MES_Data.xml");
            string strXmlFile = Path.Combine(strLogDir, string.Format("{0}.xml", "MES_Data"));
            data.WriteXml(strDataFile);
            trans.Transform(strDataFile, strXmlFile);
            return strXmlFile;
        }

        public static string XmlGetElement(XmlDocument doc, string value)
        {
            XmlNode root = doc.DocumentElement.FirstChild;
            IEnumerator ienum = root.GetEnumerator();
            XmlElement book = null;
            while (ienum.MoveNext())
            {
                book = (XmlElement)ienum.Current;
                if (book.Name.Equals(value))
                {                   
                    break;
                }

            }

            return (book != null) ? book.InnerText : null;
        }

        public static string TransferXML(string strXML)
        {

            //System.IO.FileStream file = new System.IO.FileStream(strXML, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            // file.Seek(0, System.IO.SeekOrigin.Begin);

            // int iLen = (int)file.Length;
            // byte[] data = new byte[iLen];
            // file.Read(data, 0, iLen);
            // file.Close();


            byte[] data = Encoding.GetEncoding("gb2312").GetBytes(strXML);
            string strURI = NCServer;
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strURI);
            if (request == null)
            {
                throw new Exception("连接NC服务器失败");
            }

            request.Method = "POST";
            request.ContentType = "text/xml; charset=gb2312";
            request.ContentLength = data.Length;
            request.Timeout = 500000; // 500秒

            System.IO.Stream postDataStream = request.GetRequestStream();
            postDataStream.Write(data, 0, data.Length);
            postDataStream.Close();

            //Get answer
            System.Net.HttpWebResponse resp = (HttpWebResponse)request.GetResponse();

            Stream rcvStream = resp.GetResponseStream();
            byte[] respBytes = new byte[1024];
            int byteCount;
            MemoryStream ms = new MemoryStream();
     
          //  StringBuilder builder = new StringBuilder();
            do
            {
                byteCount = rcvStream.Read(respBytes, 0, 1024);
                if (byteCount > 0)
                {
                    ms.Write(respBytes, 0, byteCount);
                }
            } while (byteCount > 0);
           
            System.Text.Encoding encoding = Encoding.UTF8;// Encoding.GetEncoding("gb2312");
            string xmlRet = encoding.GetString(ms.ToArray());
           // builder.Append(inputString);

            XmlDocument doc = new XmlDocument();
          //  string xmlRet = builder.ToString();
            int iPos = xmlRet.IndexOf(@"</ufinterface>");
            xmlRet = xmlRet.Substring(0, iPos + ((string)@"</ufinterface>").Length);
            doc.LoadXml(xmlRet);

            string tok = XmlGetElement(doc, "resultcode");
            string resultCont = XmlGetElement(doc, "resultdescription");
            string content = XmlGetElement(doc, "content");

            resultCont = resultCont.Replace("\r\n", "");
            resultCont = resultCont.Replace("\t", "");
            resp.Close();
            rcvStream.Close();

            File.AppendAllText(@".\log\log.txt", xmlRet + Environment.NewLine, Encoding.GetEncoding("gb2312"));
            //返回正确写日志，否则丢弃
            if (tok.Equals("1"))
            {
                if (content.StartsWith("YY"))
                {
                    return content.Substring(2, content.Length - 2);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static string ErrorTransferXML(string strXML)
        {
            try
            {
                System.IO.FileStream file = new System.IO.FileStream(strXML, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                file.Seek(0, System.IO.SeekOrigin.Begin);
                int iLen = (int)file.Length;
                byte[] data = new byte[iLen];
                file.Read(data, 0, iLen);
                file.Close();

                string strURI = NCServer;
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strURI);
                if (request == null)
                    return "连接NC服务器失败";
                request.Method = "POST";
                request.ContentType = "text/xml; charset=gb2312";
                request.ContentLength = iLen;

                try
                {
                    System.IO.Stream postDataStream = request.GetRequestStream();
                    postDataStream.Write(data, 0, iLen);
                    postDataStream.Close();
                }
                catch (Exception e)
                {

                    return e.Message.ToString();
                }

                //Get answer
                System.Net.HttpWebResponse resp;
                try
                {
                    resp = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException err)
                {
                   
                    resp = (HttpWebResponse)err.Response;
                    if (resp == null)
                    {
                        return err.Message.ToString(); ;
                    }
                }
                catch (Exception err)
                {
                
                    return err.Message.ToString(); ;
                }


                Stream rcvStream = resp.GetResponseStream();
                byte[] respBytes = new byte[256];
                int byteCount;

                StringBuilder builder = new StringBuilder();
                do
                {
                    byteCount = rcvStream.Read(respBytes, 0, 256);
                    System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                    string inputString = encoding.GetString(respBytes);
                    builder.Append(inputString);

                } while (byteCount > 0);

                XmlDocument doc = new XmlDocument();
                string xmlRet = builder.ToString();
                int iPos = xmlRet.IndexOf(@"</ufinterface>");
                xmlRet = xmlRet.Substring(0, iPos + ((string)@"</ufinterface>").Length);
                doc.LoadXml(xmlRet);

                string tok = XmlGetElement(doc, "resultcode");
                string resultCont = XmlGetElement(doc, "resultdescription");
                resultCont = resultCont.Replace("\r\n", "");
                resultCont = resultCont.Replace("\t", "");
                resp.Close();
                rcvStream.Close();

                //返回正确写日志，否则丢弃
                if (!tok.Equals("1"))
                {
                    return resultCont;
                }
                else
                {
                    return "1";
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public static bool deleteXml()
        {
            string strLogDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DataSent");
            string strFileName = Path.Combine(strLogDir, string.Format("{0}.xml", "MES_Data"));
            try
            {
                File.Delete(strFileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string Serialize<T>(T t)
        {
            Encoding encode = Encoding.GetEncoding("gb2312");
            MemoryStream ms = new MemoryStream();

            XmlTextWriter textWriter = new XmlTextWriter(ms, encode);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer xz = new XmlSerializer(t.GetType());
            xz.Serialize(textWriter, t, ns);

            ms.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(ms, encode);
            string xmlMessage = sr.ReadToEnd();
            return xmlMessage;
        }
    }
}
