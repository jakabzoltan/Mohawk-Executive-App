using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Web.Models
{
	public class CommentListModel
	{
	    public Guid OpportunityId { get; set; }
	    public IEnumerable<Comment> Comments { get; set; }
        public CommentListModel()
        {
            Comments = new List<CommentViewModel>();
        }

	    public CommentListModel(Guid opportunityId, IEnumerable<Comment> comments) : this()
	    {
	        OpportunityId = opportunityId;
	        Comments = comments;
	    }
	    
		
	}
}