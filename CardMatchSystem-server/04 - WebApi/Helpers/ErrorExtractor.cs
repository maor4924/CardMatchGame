using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace CardMatch
{
    //in this class we create a list of all porperties defined with validation and all errors for each propery.
    //In userdetails: we have definded 3 valdations for inserting data(full name,user name and password).
    //So the server will return a list of all properties and all errors for each.
    public static class ErrorExtractor
    {
        //the ModelStateDictionary holds all validation errors.
        public static List<PropErrors> ExtractError(ModelStateDictionary modelState)
        {
            List<PropErrors> errorList = new List<PropErrors>();

            //all properties  which fail in validation
            foreach (var item in modelState)
            {
                PropErrors propErrors = new PropErrors();

                propErrors.property = item.Key;

                //another foreach to get all errors of each propery
                foreach (var err in item.Value.Errors)
                {
                    propErrors.errors.Add(err.ErrorMessage);
                }
                errorList.Add(propErrors);
            }
            return errorList;
        }
    }
}