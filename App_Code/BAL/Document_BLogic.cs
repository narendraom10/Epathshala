using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Xml;

/// <summary>
/// Summary description for Document_BLogic
/// </summary>
public class Document_BLogic
{
    /// <summary>
    /// Create and save new xml file on document path with {title}.xml name.
    /// </summary>
    /// <param name="oDocument"></param>
    /// <returns></returns>
    public bool BAL_Document_Insert(MailDocument oDocument)
    {
        string DocumentPath = string.Empty;
        bool IsInsertSuccess = false;
        try
        {
            DocumentPath = Path.Combine(oDocument.Documentpath, Convert.ToString(AppSessions.SchoolID));
            if (!Directory.Exists(DocumentPath))
                Directory.CreateDirectory(DocumentPath);

            using (XmlWriter writer = XmlWriter.Create(Path.Combine(DocumentPath, oDocument.Title + ".xml")))
            {
                writer.WriteStartElement("Document");
                writer.WriteElementString("title", oDocument.Title);
                writer.WriteElementString("body", oDocument.Body);
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

    /// <summary>
    /// Update existing {title}.xml file.
    /// </summary>
    /// <param name="oDocument"></param>
    /// <returns></returns>
    public bool BAL_Document_Update(MailDocument oDocument)
    {
        string DocumentPath = string.Empty;
        bool IsUpdateSuccess = false;
        try
        {
            DocumentPath = Path.Combine(oDocument.Documentpath, Convert.ToString(AppSessions.SchoolID));

            using (XmlWriter writer = XmlWriter.Create(Path.Combine(DocumentPath, oDocument.Title + ".xml")))
            {
                writer.WriteStartElement("Document");
                writer.WriteElementString("title", oDocument.Title);
                writer.WriteElementString("body", oDocument.Body);
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

    /// <summary>
    /// Delete {title}.xml file
    /// </summary>
    /// <param name="oDocument"></param>
    /// <returns></returns>
    public bool BAL_Document_Delete(MailDocument oDocument)
    {
        string DocumentPath = string.Empty;
        bool IsDeleteSuccess = false;
        try
        {
            DocumentPath = Path.Combine(oDocument.Documentpath, Convert.ToString(AppSessions.SchoolID));
            if (File.Exists(Path.Combine(DocumentPath, oDocument.Title + ".xml")))
                File.Delete(Path.Combine(DocumentPath, oDocument.Title + ".xml"));
            IsDeleteSuccess = true;
        }
        catch (Exception ex)
        {
            IsDeleteSuccess = false;
        }
        return IsDeleteSuccess;
    }

    /// <summary>
    /// Select Document Datatable from {title}.xml file.
    /// </summary>
    /// <param name="oDocument"></param>
    /// <returns></returns>
    public DataTable BAL_Document_Select(MailDocument oDocument)
    {
        string Templatepath = string.Empty;
        DataTable oTable = new DataTable();

        oTable.Columns.Add("title", typeof(string));
        oTable.Columns.Add("body", typeof(string));

        Templatepath = Path.Combine(oDocument.Documentpath, Convert.ToString(AppSessions.SchoolID));

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Path.Combine(Templatepath, oDocument.Title + ".xml"));

        XmlNode oNode = xmlDoc.DocumentElement;

        oTable.Rows.Add(oNode.SelectSingleNode("title").InnerText, oNode.SelectSingleNode("body").InnerText);

        return oTable;
    }

    /// <summary>
    /// Get List of All {title}.xml file from document path.
    /// </summary>
    /// <param name="oDocument"></param>
    /// <returns></returns>
    public DataTable BAL_Document_SelectALL(MailDocument oDocument)
    {
        string Templatepath = string.Empty;
        DataTable oTable = new DataTable();

        oTable.Columns.Add("title", typeof(string));
        oTable.Columns.Add("templetpath", typeof(string));

        Templatepath = Path.Combine(oDocument.Documentpath, Convert.ToString(AppSessions.SchoolID));
        if (!Directory.Exists(Templatepath))
            Directory.CreateDirectory(Templatepath);

        foreach (string file in Directory.GetFiles(Templatepath, "*.xml", SearchOption.AllDirectories))
        {
            oTable.Rows.Add(Path.GetFileNameWithoutExtension(file), file);
        }
        return oTable;
    }

    /// <summary>
    /// return true if {title}.xml file exists on document path
    /// </summary>
    /// <param name="oDocument"></param>
    /// <returns></returns>
    public bool BAL_Document_CheckExists(MailDocument oDocument)
    {
        string DocumentPath = Path.Combine(oDocument.Documentpath, Convert.ToString(AppSessions.SchoolID));
        if (!Directory.Exists(DocumentPath))
            Directory.CreateDirectory(DocumentPath);

        if (File.Exists(Path.Combine(DocumentPath, oDocument.Title + ".xml")))
            return true;
        else
            return false;
    }
}