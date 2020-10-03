using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Forum
/// </summary>
public class Forum
{
	public Forum()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    string post;

    public string Post
    {
        get { return post; }
        set { post = value; }
    }

    int postedby;

    public int PostedBy
    {
        get { return postedby; }
        set { postedby = value; }
    }
}