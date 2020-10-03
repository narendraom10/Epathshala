using System.Collections;
using System.Data;

/// <summary>
/// Summary description for Forum_BAL
/// </summary>
public class Forum_BAL
{
    DataAccess oDataHelper;
    ArrayList arrParameter;

    public Forum_BAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Forum_Insert(Forum Forum)
    {
        this.oDataHelper = new DataAccess();
        this.arrParameter = new ArrayList();

        this.arrParameter.Add(new parameter("Post", Forum.Post));
        this.arrParameter.Add(new parameter("PostedBy", Forum.PostedBy));

        return this.oDataHelper.DAL_InsertUpdateWithStatus("Forum_Insert", this.arrParameter);
    }

    public DataSet Forum_Select_All(Forum Forum)
    {
        oDataHelper = new DataAccess();
        arrParameter = new ArrayList();

        arrParameter.Add(new parameter("PostedBy", Forum.PostedBy));
        
        return oDataHelper.DAL_Select("Forum_Select_ByPostedBy", arrParameter);
    }

}