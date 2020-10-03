using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Xml;
using System.IO;

/// <summary>
/// Summary description for Template_BLogic
/// </summary>
public class Template_BLogic
{
    //Add xml file concept instead of database suggest by VP sir

    public bool BAL_Template_Insert(Template oTemplate)
    {
        string Templatepath = string.Empty;
        bool IsInsertSuccess = false;
        try
        {
            Templatepath = Path.Combine(oTemplate.Templatepath, Convert.ToString(AppSessions.SchoolID));
            if (!Directory.Exists(Templatepath))
                Directory.CreateDirectory(Templatepath);

            using (XmlWriter writer = XmlWriter.Create(Path.Combine(Templatepath, oTemplate.Title + ".xml")))
            {
                writer.WriteStartElement("Template");
                writer.WriteElementString("title", oTemplate.Title);
                writer.WriteElementString("subject", oTemplate.Subject);
                writer.WriteElementString("body", oTemplate.Body);
                writer.WriteEndElement();
                writer.Flush();
            }
            IsInsertSuccess = true;
        }
        catch (Exception ex)
        {
            IsInsertSuccess = false;
        }
        return IsInsertSuccess;
    }

    public bool BAL_Template_Update(Template oTemplate)
    {
        string Templatepath = string.Empty;
        bool IsUpdateSuccess = false;
        try
        {
            Templatepath = Path.Combine(oTemplate.Templatepath, Convert.ToString(AppSessions.SchoolID));

            using (XmlWriter writer = XmlWriter.Create(Path.Combine(Templatepath, oTemplate.Title + ".xml")))
            {
                writer.WriteStartElement("Template");
                writer.WriteElementString("title", oTemplate.Title);
                writer.WriteElementString("subject", oTemplate.Subject);
                writer.WriteElementString("body", oTemplate.Body);
                writer.WriteEndElement();
                writer.Flush();
            }
            IsUpdateSuccess = true;
        }
        catch (Exception ex)
        {
            IsUpdateSuccess = false;
        }
        return IsUpdateSuccess;
    }

    public bool BAL_Template_Delete(Template oTemplate)
    {
        string Templatepath = string.Empty;
        bool IsDeleteSuccess = false;
        try
        {
            Templatepath = Path.Combine(oTemplate.Templatepath, Convert.ToString(AppSessions.SchoolID));
            if (File.Exists(Path.Combine(Templatepath, oTemplate.Title + ".xml")))
                File.Delete(Path.Combine(Templatepath, oTemplate.Title + ".xml"));
            IsDeleteSuccess = true;
        }
        catch (Exception ex)
        {
            IsDeleteSuccess = false;
        }
        return IsDeleteSuccess;
    }

    public DataTable BAL_Template_Select(Template oTemplate)
    {
        string Templatepath = string.Empty;
        DataTable oTable = new DataTable();

        oTable.Columns.Add("title", typeof(string));
        oTable.Columns.Add("subject", typeof(string));
        oTable.Columns.Add("body", typeof(string));

        Templatepath = Path.Combine(oTemplate.Templatepath, Convert.ToString(AppSessions.SchoolID));

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Path.Combine(Templatepath, oTemplate.Title + ".xml"));

        XmlNode oNode = xmlDoc.DocumentElement;

        oTable.Rows.Add(oNode.SelectSingleNode("title").InnerText, oNode.SelectSingleNode("subject").InnerText, oNode.SelectSingleNode("body").InnerText);

        return oTable;
    }

    public DataTable BAL_Template_SelectALL(Template oTemplate)
    {
        string Templatepath = string.Empty;
        DataTable oTable = new DataTable();

        oTable.Columns.Add("title", typeof(string));
        oTable.Columns.Add("templetpath", typeof(string));

        Templatepath = Path.Combine(oTemplate.Templatepath, Convert.ToString(AppSessions.SchoolID));
        if (!Directory.Exists(Templatepath))
            Directory.CreateDirectory(Templatepath);

        foreach (string file in Directory.GetFiles(Templatepath, "*.xml", SearchOption.AllDirectories))
        {
            oTable.Rows.Add(Path.GetFileNameWithoutExtension(file), file);
        }
        return oTable;
    }

    public bool BAL_Template_CheckExists(Template oTemplate)
    {
        string Templatepath = Path.Combine(oTemplate.Templatepath, Convert.ToString(AppSessions.SchoolID));
        if (!Directory.Exists(Templatepath))
            Directory.CreateDirectory(Templatepath);

        if (File.Exists(Path.Combine(Templatepath, oTemplate.Title + ".xml")))
            return true;
        else
            return false;
    }
}