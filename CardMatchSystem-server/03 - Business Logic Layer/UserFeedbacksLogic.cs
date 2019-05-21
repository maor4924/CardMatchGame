using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch
{
    public class UserFeedbacksLogic : BaseLogic
    {
        //Get List of all Feedbacks
        public List<UserFeedbackModel> GetAllFeedbacks()
        {

            var query = from f in DB.UsersFeedbacks
                        select new UserFeedbackModel
                        {
                            id = f.FeedbackID,
                            userId = f.UserID,
                            fbDateTime = f.FeedbackDateTime,
                            fbText = f.FeedbackText


                        };
            return query.ToList();
        }


        //Add new Feedback
        public UserFeedbackModel AddFeedback(UserFeedbackModel feedbackModel)
        {
            UsersFeedback userfeedback = new UsersFeedback
            {


                UserID = feedbackModel.userId,
                FeedbackDateTime = DateTime.Now,
                FeedbackText = feedbackModel.fbText
            };
            DB.UsersFeedbacks.Add(userfeedback);
            DB.SaveChanges();
            feedbackModel.id = userfeedback.FeedbackID;
            return feedbackModel;
        }
    }
}
